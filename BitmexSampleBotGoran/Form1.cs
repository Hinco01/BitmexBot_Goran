using BitMEX;
using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using System.Globalization;

// feees in Bitmex  Total Fees = 100 [leverage] x $1,000 [Margin] x 0.00075 [Rate for Market order] x 2 [Entry + Exit] = $150
// 5 * real btc * 0,0005 = limit + market + 5x

namespace BitmexSampleBotGoran
{
    public partial class Form1 : Form
    {

       // private static string TestbitmexKey = "test";
       // private static string TestbitmexSecret = "test";
        private static string TestbitmexDomain = "https://testnet.bitmex.com";

      //  private static string bitmexKey = "test";
       // private static string bitmexSecret = "test";
        private static string bitmexDomain = "https://www.bitmex.com";

        string WebSocketAPIKey = "";
        string WebSocketAPISecret = "";

        bool FirstINITNET = true;
        bool FirstINTICNDL = true;

        bool UpStop = false;
        bool DownStop = false;

        int WBFaliedTimes = 0;

        int TPTimerLimit = 150;

        string SLside;

        BitMEXApi bitmex;
        List<OrderBook> CurrentBook = new List<OrderBook>();
        List<Instrument> ActiveInstruments = new List<Instrument>();
        Instrument ActiveInstrument = new Instrument();
        List<Candle> Candles = new List<Candle>();
        List<Candle1h> Candles1h = new List<Candle1h>();
        List<Candle1d> Candles1d = new List<Candle1d>();
        //List<Candle> CandlesCHECK = new List<Candle>();
        //List<CandleDisplay> CandleDisplays = new List<CandleDisplay>();
        //List<CandleWeb> CandlesWebS = new List<CandleWeb>();

        //string ActiveOrderID = null;
        string CurrentOrderID = null;

        //string ActiveOrderStatus = null;
        //string CurrentOrderStatus = null;

        bool ProcessOrderWS = true;
        bool FirstOrderProcess = true;


        bool PositionChange = false;
        bool OrderChange = false;


        bool Running = false;
        string Mode = "Wait";
        List<Position> OpenPositions = new List<Position>();
        List<Order> OpenOrders = new List<Order>();

        decimal? PositionCloseValue = 0;

        // Bolinger Bands BB
        int BBLength = 20;
        double BBMultiplier = 2;

        // EMA 
        int EMA1Period = 26; // Slow MACD EMA
        int EMA2Period = 12; // Fast MACD EMA
        int EMA3Period = 9;

        // For MACD
        int MACDEMAPeriod = 9;  // MACD smoothing period

        // For ATR
        int ATR1Period = 5;
        int ATR2Period = 20;

        //ATR Trailing Stop
        double ATRMultip = 3.5;

        // For RSI
        int RSIPeriod = 14;

        // For Stochastic (STOCH)
        int STOCHLookbackPeriod = 14;
        int STOCHDPeriod = 3;


        //1h
        // Bolinger Bands BB
        int BBLength1h = 20;
        double BBMultiplier1h = 2;

        // EMA 
        int EMA1Period1h = 26; // Slow MACD EMA
        int EMA2Period1h = 12; // Fast MACD EMA
        int EMA3Period1h = 9;

        // For MACD
        int MACDEMAPeriod1h = 9;  // MACD smoothing period

        // For ATR
        int ATR1Period1h = 7;
        int ATR2Period1h = 20;

        // For RSI
        int RSIPeriod1h = 14;

        // For Stochastic (STOCH)
        int STOCHLookbackPeriod1h = 14;
        int STOCHDPeriod1h = 3;


        //1d
        // Bolinger Bands BB
        int BBLength1d = 20;
        double BBMultiplier1d = 2;

        // EMA 
        int EMA1Period1d = 26; // Slow MACD EMA
        int EMA2Period1d = 12; // Fast MACD EMA
        int EMA3Period1d = 9;

        // For MACD
        int MACDEMAPeriod1d = 9;  // MACD smoothing period

        // For ATR
        int ATR1Period1d = 7;
        int ATR2Period1d = 20;

        // For RSI
        int RSIPeriod1d = 14;

        // For Stochastic (STOCH)
        int STOCHLookbackPeriod1d = 14;
        int STOCHDPeriod1d = 3;



        WebSocket ws;
        DateTime WebScocketLastMessage = new DateTime();
        Dictionary<string, decimal> Prices = new Dictionary<string, decimal>();


        List<OrderBook> OrderBookTopAsks = new List<OrderBook>();
        List<OrderBook> OrderBookTopBids = new List<OrderBook>();
        Position SymbolPosition = new Position();
        Candle CandlesWebSocket = new Candle();
        Order SymbolOrder = new Order();
        //OrderBook SymbolOrderBook = new OrderBook();

        decimal OBBuyPriceValue = 0;
        String OBBuySideValue;

        decimal OBSellPriceValue = 0;
        String OBBSellSideValue;

        decimal Balance = 0;
        decimal WalletBalance = 0;
        decimal AvaliableMargin = 0;

        decimal StopLossStartPer = 0;
        decimal StopLossExecutePer = 0;
        decimal StopLossStartPrice = 0;
        decimal StopLossExecutePrice = 0;
        decimal StopLossCancelPer = 0;
        decimal StopLossCancel = 0;
        bool StopLossActivate = false;
        bool NotStopLoss = false;

        decimal? StopPriceCheck = null;
        decimal? PriceCheck = null;
        decimal? PositionPriceCheck = null;

        decimal TrailingProfitStartPer = 0;
        decimal TrailingProfitStartPrice = 0;
        decimal TrailingProfitExecutePer = 0;
        decimal TrailingProfitExecutePrice = 0;
        string TPSide;
        bool TrailigProfitOrderOpen = false;
        bool FirstTimeTPStrat = true;

        bool FirstLoadPrice = true;
        decimal FirstPriceLoad = 0;

        int Dblcheck = 0;
        int DblcheckSell = 0;

        bool APIValid = false;
        bool CandlesFirstTime = false;

        bool HourCandleFiratTime = true;
        bool DayCandleFiratTime = true;

        bool FirstDCA = true;
        int DCAAutoReOrderSec = 0;
        String DCASide;
        decimal DCATriggerPrice = 0;
        decimal DCALimitPrice = 0;
        decimal DCAOrderPriceOld = 0;
        bool DCARunning = false;
        bool DCAOrderPriceCheck = false;
        bool DCALiquidationLimitReached = true;
        decimal DCALowCheckPercent = Convert.ToDecimal(0.0026);


        public Form1()
        {
            InitializeComponent();
            InitializeDropdownsAndSettings();            
            InitializeAPI();
            InitializeCandleArea();            

            InitializeWebSocket();
            InitializeSymbolSpecificData(true);
            InitializeWalletWebSocket(true);            
        }

        private void InitializeDropdownsAndSettings()
        {            
            ddNetwork.SelectedIndex = 0;
            ddOrderType.SelectedIndex = 1;
            ddlCandleTimes.SelectedIndex = 0;
            ddlAutoOrderType.SelectedIndex = 1;
            ddlStrategyType.SelectedIndex = 0;
            ddlDCA.SelectedIndex = 0;

            LoadAPISettings();
        }

        private void LoadAPISettings()
        {
            switch (ddNetwork.SelectedItem.ToString())
            {
                case "TestNet":
                    txtAPIKey.Text = Properties.Settings.Default.TestAPIKey;
                    txtAPISecret.Text = Properties.Settings.Default.TestAPISecret;

                    WebSocketAPIKey = Properties.Settings.Default.TestAPIKey;
                    WebSocketAPISecret = Properties.Settings.Default.TestAPISecret;

                    break;
                case "RealNet":
                    txtAPIKey.Text = Properties.Settings.Default.APIKey;
                    txtAPISecret.Text = Properties.Settings.Default.APISecret;

                    WebSocketAPIKey = Properties.Settings.Default.APIKey;
                    WebSocketAPISecret = Properties.Settings.Default.APISecret;
                    break;
            }
        }


        private void InitializeCandleArea ()
        {
            UpdateCandles1h();
            UpdateCandles1d();
            UpdateCandles();
            tmrCandleUpdater.Start();
            tmrCandleUpdaterhd.Start();
        }

        private void InitializeAPI()
        {
            switch(ddNetwork.SelectedItem.ToString())
            {
                //case "TestNet":
                //    bitmex = new BitMEXApi(TestbitmexKey, TestbitmexSecret, TestbitmexDomain);
                //    WebSocketAPIKey = TestbitmexKey;
                //    WebSocketAPISecret = TestbitmexSecret;
                //    break;
                //case "RealNet":
                //    bitmex = new BitMEXApi(bitmexKey, bitmexSecret, bitmexDomain);
                //    WebSocketAPIKey = bitmexKey;
                //    WebSocketAPISecret = bitmexSecret;
                //    break;

                case "TestNet":
                    bitmex = new BitMEXApi(txtAPIKey.Text, txtAPISecret.Text, TestbitmexDomain);
                    break;
                case "RealNet":
                    bitmex = new BitMEXApi(txtAPIKey.Text, txtAPISecret.Text, bitmexDomain);
                    break;
            }
            Heartbeat.Start();
            // We must do this in case symbols are different on test and real net
            InitializeSymbolInformation();
            GetAPIValidity();
        }

        private void GetAPIValidity()
        {
            try // Code is simple, if we get our account balance without an error the API is valid, if not, it will throw an error and API will be marked not valid.
            {

                WalletBalance = bitmex.GetAccountBalance();
                if (WalletBalance >= 0)
                {
                    APIValid = true;
                    lblApiValidity.Text = "API keys are valid";
                    
                }
                else
                {
                    APIValid = false;
                    lblApiValidity.Text = "API keys are invalid";
                    
                }
            }
            catch (Exception ex)
            {
                APIValid = false;
                lblApiValidity.Text = "API keys are invalid";
                
            }
        }

        private void InitializeSymbolInformation()
        {
            ActiveInstruments = bitmex.GetActiveInstruments().OrderByDescending(a => a.Volume24H).ToList();
            ddlSymbol.DataSource = ActiveInstruments;
            ddlSymbol.DisplayMember = "Symbol";
            ddlSymbol.SelectedIndex = 0;
            ActiveInstrument = ActiveInstruments[0];

            

            //foreach(Instrument i in ActiveInstruments)
            // {
            //     Prices.Add(i.Symbol, 0); //just setting up the item, 0 is fine here
            // }
        }       
        private void InitializeWebSocket ()
        {          
            //if (ws != null)
            //{
             //   ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"trade:" + "XBTUSD" + "\"]}");                
            //}
            switch (ddNetwork.SelectedItem.ToString())
            {
                case "TestNet":                    
                    ws = new WebSocket("wss://testnet.bitmex.com/realtime");
                    break;
                case "RealNet":                    
                    ws = new WebSocket("wss://www.bitmex.com/realtime");
                    break;
            }
            ws.OnMessage += (sender, e) =>
            {
                WebScocketLastMessage = DateTime.UtcNow;
                try
                {
                    JObject Message = JObject.Parse(e.Data);
                    if (Message.ContainsKey("table"))
                    {
                        if ((string)Message["table"] == "tradeBin5m")
                        {
                            if (Message.ContainsKey("data"))
                            {
                                JArray TD = (JArray)Message["data"];
                                if (TD.Any())
                                {
                                    if (TD.Children().LastOrDefault()["timestamp"] != null)
                                    {
                                        CandlesWebSocket.TimeStamp = (DateTime)TD.Children().LastOrDefault()["timestamp"];
                                    }
                                    if (TD.Children().LastOrDefault()["open"] != null)
                                    {
                                        CandlesWebSocket.Open = (double?)TD.Children().LastOrDefault()["open"];
                                    }
                                    if (TD.Children().LastOrDefault()["high"] != null)
                                    {
                                        CandlesWebSocket.High = (double?)TD.Children().LastOrDefault()["high"];

                                    }
                                    if (TD.Children().LastOrDefault()["low"] != null)
                                    {
                                        CandlesWebSocket.Low = (double?)TD.Children().LastOrDefault()["low"];

                                    }
                                    if (TD.Children().LastOrDefault()["close"] != null)
                                    {
                                        CandlesWebSocket.Close = (double?)TD.Children().LastOrDefault()["close"];

                                    }
                                    if (TD.Children().LastOrDefault()["trades"] != null)
                                    {
                                        CandlesWebSocket.Trades = (int)TD.Children().LastOrDefault()["trades"];
                                    }
                                    if (TD.Children().LastOrDefault()["volume"] != null)
                                    {
                                        CandlesWebSocket.Volume = (double?)TD.Children().LastOrDefault()["volume"];

                                    }
                                    //if (CandlesFirstTime == true)
                                    //{
                                    //    NewWSCandle();
                                    //    UpdateCandles();
                                    //}
                                }
                            }
                        }

                        else if ((string)Message["table"] == "trade")
                        {
                            if (Message.ContainsKey("data"))
                            {
                                JArray TD = (JArray)Message["data"];
                                if (TD.Any())
                                {
                                    decimal Price = (decimal)TD.Children().LastOrDefault()["price"];
                                    string Symbol = (string)TD.Children().LastOrDefault()["symbol"];
                                    Prices[Symbol] = Price;                                    

                                    //if (CandlesFirstTime == true)
                                    //{
                                    //    Candles[0].Close = Convert.ToDouble(Price);
                                    //    if (Candles[0].Low > Convert.ToDouble(Price))
                                    //    {
                                    //        Candles[0].Low = Convert.ToDouble(Price);
                                    //    }
                                    //    if (Candles[0].High < Convert.ToDouble(Price))
                                    //    {
                                    //        Candles[0].High = Convert.ToDouble(Price);
                                    //    }
                                    //    UpdateCandles();
                                    //}
                                }
                            }
                        }

                        else if ((string)Message["table"] == "orderBook10")
                        {
                            if (Message.ContainsKey("data"))
                            {
                                JArray TD = (JArray)Message["data"];
                                if (TD.Any())
                                {
                                    JArray TDBids = (JArray)TD[0]["bids"];
                                    if (TDBids.Any())
                                    {
                                        List<OrderBook> OB = new List<OrderBook>();
                                        List<OrderBook> OBBuy = new List<OrderBook>();
                                        foreach (JArray i in TDBids)
                                        {
                                            OrderBook OBI = new OrderBook();
                                            OBI.Price = (decimal)i[0];
                                            OBI.Size = (int)i[1];
                                            OBI.Side = "Buy";
                                            OB.Add(OBI);
                                            OBBuy.Add(OBI);
                                        }

                                        OrderBookTopBids = OB;
                                        OBBuyPriceValue = OBBuy[0].Price;
                                        OBBuySideValue = OBBuy[0].Side;
                                    }

                                    JArray TDAsks = (JArray)TD[0]["asks"];
                                    if (TDAsks.Any())
                                    {
                                        List<OrderBook> OB = new List<OrderBook>();
                                        List<OrderBook> OBSell = new List<OrderBook>();
                                        foreach (JArray i in TDAsks)
                                        {
                                            OrderBook OBI = new OrderBook();
                                            OBI.Price = (decimal)i[0];
                                            OBI.Size = (int)i[1];
                                            OBI.Side = "Sell";
                                            OB.Add(OBI);
                                            OBSell.Add(OBI);
                                        }

                                        OrderBookTopAsks = OB;
                                        OBSellPriceValue = OBSell[0].Price;
                                        OBBSellSideValue = OBSell[0].Side;
                                    }
                                }
                            }
                        }
                        else if ((string)Message["table"] == "position")
                        {
                            // PARSE
                            if (Message.ContainsKey("data"))
                            {
                                JArray TD = (JArray)Message["data"];
                                if (TD.Any())
                                {

                                    if (TD.Children().LastOrDefault()["avgEntryPrice"] != null)
                                    {
                                        PositionPriceCheck = (decimal?)TD.Children().LastOrDefault()["avgEntryPrice"];

                                    }
                                    if (TD.Children().LastOrDefault()["isOpen"] != null || PositionPriceCheck != SymbolPosition.AvgEntryPrice)
                                    {
                                        PositionChange = true;
                                        TPTimerLimit = 0;
                                        txtTPTimer.Text = "TPTimer: " + TPTimerLimit.ToString();
                                    }
                                    //if (TD.Children().LastOrDefault()["isOpen"] != null && (string)TD.Children().LastOrDefault()["isOpen"] == "true")
                                    //{

                                    if (TD.Children().LastOrDefault()["symbol"] != null)
                                    {
                                        SymbolPosition.Symbol = (string)TD.Children().LastOrDefault()["symbol"];
                                    }
                                    if (TD.Children().LastOrDefault()["currentQty"] != null)
                                    {
                                        SymbolPosition.CurrentQty = (int?)TD.Children().LastOrDefault()["currentQty"];

                                    }
                                    if (TD.Children().LastOrDefault()["avgEntryPrice"] != null)
                                    {
                                        SymbolPosition.AvgEntryPrice = (decimal?)TD.Children().LastOrDefault()["avgEntryPrice"];

                                    }
                                    if (TD.Children().LastOrDefault()["markPrice"] != null)
                                    {
                                        SymbolPosition.MarkPrice = (decimal?)TD.Children().LastOrDefault()["markPrice"];

                                    }
                                    if (TD.Children().LastOrDefault()["liquidationPrice"] != null)
                                    {
                                        SymbolPosition.LiquidationPrice = (decimal?)TD.Children().LastOrDefault()["liquidationPrice"];
                                    }
                                    if (TD.Children().LastOrDefault()["leverage"] != null)
                                    {
                                        SymbolPosition.Leverage = (decimal?)TD.Children().LastOrDefault()["leverage"];

                                    }
                                    if (TD.Children().LastOrDefault()["unrealisedPnl"] != null)
                                    {
                                        SymbolPosition.UnrealisedPnl = (decimal?)TD.Children().LastOrDefault()["unrealisedPnl"];
                                    }
                                    if (TD.Children().LastOrDefault()["unrealisedPnlPcnt"] != null)
                                    {
                                        SymbolPosition.UnrealisedPnlPcnt = (decimal?)TD.Children().LastOrDefault()["unrealisedPnlPcnt"];

                                    }

                                    if (TD.Children().LastOrDefault()["openOrderBuyQty"] != null)
                                    {
                                        SymbolPosition.OpenOrderBuyQty = (decimal?)TD.Children().LastOrDefault()["openOrderBuyQty"];
                                    }

                                    if (TD.Children().LastOrDefault()["openOrderBuyCost"] != null)
                                    {
                                        SymbolPosition.OpenOrderBuyCost = (decimal?)TD.Children().LastOrDefault()["openOrderBuyCost"];
                                    }

                                    if (TD.Children().LastOrDefault()["openOrderSellQty"] != null)
                                    {
                                        SymbolPosition.OpenOrderSellQty = (decimal?)TD.Children().LastOrDefault()["openOrderSellQty"];
                                    }

                                    if (TD.Children().LastOrDefault()["openOrderSellCost"] != null)
                                    {
                                        SymbolPosition.OpenOrderSellCost = (decimal?)TD.Children().LastOrDefault()["openOrderSellCost"];
                                    }

                                    if (TD.Children().LastOrDefault()["isOpen"] != null)
                                    {
                                        SymbolPosition.IsOpen = (bool)TD.Children().LastOrDefault()["isOpen"];
                                    }

                                    //}
                                }
                            }
                        }
                        else if ((string)Message["table"] == "margin")
                        {
                            if (Message.ContainsKey("data"))
                            {
                                JArray TD = (JArray)Message["data"];
                                if (TD.Any())
                                {
                                    try
                                    {
                                        Balance = ((decimal)TD.Children().LastOrDefault()["walletBalance"] / 100000000);
                                        AvaliableMargin = ((decimal)TD.Children().LastOrDefault()["availableMargin"] / 100000000);
                                        if (FirstLoadPrice == true)
                                        {
                                            FirstPriceLoad = Balance;
                                            FirstLoadPrice = false;
                                        }

                                        UpdateBalanceAndTime();

                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                        }
                        else if ((string)Message["table"] == "order")
                        {

                            if (Message.ContainsKey("data"))
                            {
                                JArray TD = (JArray)Message["data"];
                                if (TD.Any())
                                {
                                    

                                    //if (TD.Children().LastOrDefault()["orderID"] != null && ActiveOrderID == null)
                                    //{
                                    //    ActiveOrderID = (string)TD.Children().LastOrDefault()["orderID"];
                                    //    ProcessOrderWS = true;
                                    //}

                                    //if (TD.Children().LastOrDefault()["ordStatus"] != null && ActiveOrderStatus == null)
                                    //{
                                    //    ActiveOrderStatus = (string)TD.Children().LastOrDefault()["ordStatus"];
                                    //    ProcessOrderWS = true;
                                    //}

                                    if (TD.Children().LastOrDefault()["orderID"] != null && FirstOrderProcess == false)
                                    {
                                        CurrentOrderID = (string)TD.Children().LastOrDefault()["orderID"];
                                    }

                                    //if (TD.Children().LastOrDefault()["ordStatus"] != null && FirstOrderProcess == false)
                                    //{
                                    //    CurrentOrderStatus = (string)TD.Children().LastOrDefault()["ordStatus"];
                                    //}

                                    if (FirstOrderProcess == false)
                                    {
                                        if (CurrentOrderID == SymbolOrder.OrderId)
                                        {
                                            ProcessOrderWS = true;
                                        }
                                        else if (SymbolOrder.OrdStatus != "New" && SymbolOrder.OrdStatus != "PartiallyFilled" && CurrentOrderID != SymbolOrder.OrderId)
                                        {
                                            ProcessOrderWS = true;
                                        }
                                        else
                                        {
                                            ProcessOrderWS = false;
                                        }
                                    }
                                 


                                    if (ProcessOrderWS == true)
                                    {

                                        if (TD.Children().LastOrDefault()["price"] != null)
                                        {
                                            PriceCheck = (decimal?)TD.Children().LastOrDefault()["price"];
                                        }
                                        if (TD.Children().LastOrDefault()["stopPx"] != null)
                                        {                                           
                                            StopPriceCheck = (decimal?)TD.Children().LastOrDefault()["stopPx"];
                                        }

                                        if (TD.Children().LastOrDefault()["ordStatus"] != null || SymbolOrder.StopPx != StopPriceCheck || SymbolOrder.Price != PriceCheck)
                                        {
                                            OrderChange = true;
                                        }



                                        if (TD.Children().LastOrDefault()["symbol"] != null)
                                        {
                                            SymbolOrder.Symbol = (string)TD.Children().LastOrDefault()["symbol"];
                                        }
                                        if (TD.Children().LastOrDefault()["orderQty"] != null)
                                        {
                                            SymbolOrder.OrderQty = (int?)TD.Children().LastOrDefault()["orderQty"];

                                        }
                                        if (TD.Children().LastOrDefault()["ordType"] != null)
                                        {
                                            SymbolOrder.OrdType = (string)TD.Children().LastOrDefault()["ordType"];

                                        }
                                        if (TD.Children().LastOrDefault()["ordStatus"] != null)
                                        {
                                            SymbolOrder.OrdStatus = (string)TD.Children().LastOrDefault()["ordStatus"];

                                        }
                                        if (TD.Children().LastOrDefault()["orderID"] != null)
                                        {
                                            SymbolOrder.OrderId = (string)TD.Children().LastOrDefault()["orderID"];
                                        }
                                        if (TD.Children().LastOrDefault()["side"] != null)
                                        {
                                            SymbolOrder.Side = (string)TD.Children().LastOrDefault()["side"];

                                        }
                                        if (TD.Children().LastOrDefault()["price"] != null)
                                        {
                                            SymbolOrder.Price = (decimal?)TD.Children().LastOrDefault()["price"];
                                            PriceCheck = (decimal?)TD.Children().LastOrDefault()["price"];
                                        }
                                        if (TD.Children().LastOrDefault()["displayQty"] != null)
                                        {
                                            SymbolOrder.DisplayQty = (int?)TD.Children().LastOrDefault()["displayQty"];

                                        }

                                        if (TD.Children().LastOrDefault()["workingIndicator"] != null)
                                        {
                                            SymbolOrder.WorkingIndicator = (bool?)TD.Children().LastOrDefault()["workingIndicator"];
                                        }

                                        if (TD.Children().LastOrDefault()["stopPx"] != null)
                                        {
                                            SymbolOrder.StopPx = (decimal?)TD.Children().LastOrDefault()["stopPx"];
                                            StopPriceCheck = (decimal?)TD.Children().LastOrDefault()["stopPx"];
                                        }

                                        if (TD.Children().LastOrDefault()["timeInForce"] != null)
                                        {
                                            SymbolOrder.TimeInForce = (string)TD.Children().LastOrDefault()["timeInForce"];
                                        }

                                        if (TD.Children().LastOrDefault()["leavesQty"] != null)
                                        {
                                            SymbolOrder.LeavesQty = (int?)TD.Children().LastOrDefault()["leavesQty"];
                                        }
                                        if (TD.Children().LastOrDefault()["cumQty"] != null)
                                        {
                                            SymbolOrder.CumQty = (int?)TD.Children().LastOrDefault()["cumQty"];
                                        }
                                        if (TD.Children().LastOrDefault()["timestamp"] != null)
                                        {
                                            SymbolOrder.TimeStamp = (DateTime)TD.Children().LastOrDefault()["timestamp"];
                                        }

                                        FirstOrderProcess = false;

                                    }
                                }
                            }


                        }
                        
                    }
                    else if (Message.ContainsKey("info") && Message.ContainsKey("docs"))
                    {
                        string WebSocketInfo = "Websocket Info: " + Message["info"].ToString() + " " + Message["docs"].ToString();
                        UpdateWebSocketInfo(WebSocketInfo);
                    }

                
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            };
            ws.OnError += (sender, e) =>
            {
            };

            ws.Connect();

            // Assamble our price dictionary
            //foreach (Instrument i in ActiveInstruments)
            //{
            //    ws.Send("{\"op\": \"subscribe\", \"args\": [\"trade:" + i.Symbol + "\"]}");
            //}
            //ws.Send("{\"op\": \"subscribe\", \"args\": [\"trade:" + ActiveInstrument.Symbol + "\"]}");
            if (APIValid == true)
            {
                string APIExpires = bitmex.GetExpiresArg();
                string Signature = bitmex.GetWebSocketSignatureString(WebSocketAPISecret, APIExpires);
                ws.Send("{\"op\": \"authKeyExpires\", \"args\": [\"" + WebSocketAPIKey + "\", " + APIExpires + ", \"" + Signature + "\"]}");
            }
        }


        private void InitializeSymbolSpecificData(bool FirstLoad = false)
        {
            if (!FirstLoad)
            {
                // Unsubscribe from old orderbook
                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"orderBook10:" + ActiveInstrument.Symbol + "\"]}");
                OrderBookTopAsks = new List<OrderBook>();
                OrderBookTopBids = new List<OrderBook>();

                // Unsubscribe from old instrument position
                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"position:" + ActiveInstrument.Symbol + "\"]}");

                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"order:" + ActiveInstrument.Symbol + "\"]}");

                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"trade:" + ActiveInstrument.Symbol + "\"]}");

                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"tradeBin5m:" + ActiveInstrument.Symbol + "\"]}");

                ActiveInstrument = bitmex.GetInstrument(((Instrument)ddlSymbol.SelectedItem).Symbol)[0];
            }

            ws.Send("{\"op\": \"subscribe\", \"args\": [\"tradeBin5m:" + ActiveInstrument.Symbol + "\"]}");
            ws.Send("{\"op\": \"subscribe\", \"args\": [\"order:" + ActiveInstrument.Symbol + "\"]}");
            // Subscribe to new orderbook
            ws.Send("{\"op\": \"subscribe\", \"args\": [\"orderBook10:" + ActiveInstrument.Symbol + "\"]}");
            // Subscribe to position for new symbol
            ws.Send("{\"op\": \"subscribe\", \"args\": [\"position:" + ActiveInstrument.Symbol + "\"]}");
            // Only subscribing to this symbol trade feed now, was too much at once before with them all.
            ws.Send("{\"op\": \"subscribe\", \"args\": [\"trade:" + ActiveInstrument.Symbol + "\"]}");
            UpdateFormsForTickSize(ActiveInstrument.TickSize, ActiveInstrument.DecimalPlacesInTickSize);

        }

        private void InitializeWalletWebSocket(bool FirstLoadWallet = false)
        {
            if (!FirstLoadWallet)
            {
                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"margin\"]}");
            }

            // Margin Connect - do this last so we already have the price.
            ws.Send("{\"op\": \"subscribe\", \"args\": [\"margin\"]}");
        }

        private decimal CalculateMarketOrderPrice(string Side)
        {
            //CurrentBook = bitmex.GetOrderBook(ActiveInstrument.Symbol, 1);

            decimal SellPrice = OBSellPriceValue;
            decimal BuyPrice = OBBuyPriceValue;

            decimal OrderPrice = 0;

            switch (Side)
            {
                case "Buy":
                    OrderPrice = BuyPrice;

                    if (BuyPrice + Convert.ToDecimal(ActiveInstrument.TickSize) >= SellPrice)
                    {
                        OrderPrice = BuyPrice;
                    }
                    else if (BuyPrice + Convert.ToDecimal(ActiveInstrument.TickSize) < SellPrice)
                    {
                        OrderPrice = BuyPrice + Convert.ToDecimal(ActiveInstrument.TickSize);
                    }
                    break;
                case "Sell":
                    OrderPrice = SellPrice;

                    if (SellPrice - Convert.ToDecimal(ActiveInstrument.TickSize) <= BuyPrice)
                    {
                        OrderPrice = SellPrice;
                    }
                    else if (SellPrice - Convert.ToDecimal(ActiveInstrument.TickSize) > BuyPrice)
                    {
                        OrderPrice = SellPrice - Convert.ToDecimal(ActiveInstrument.TickSize);
                    }
                    break;
            }
            return OrderPrice;

        }

        private void MakeOrder(string Side, int Qty, decimal Price = 0)
        {
            if (chkCancelWhileOrdering.Checked)
            {
                bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
            }
            switch (ddOrderType.SelectedItem)
            {
                case "Limit Post Only":
                    if (Price == 0)
                    {
                        Price = CalculateMarketOrderPrice(Side);
                    }
                    var MakerBuy = bitmex.PostOrderPostOnly(ActiveInstrument.Symbol, Side, Price, Qty);
                    break;
                case "Market":
                    bitmex.MarketOrder(ActiveInstrument.Symbol, Side, Qty);
                    break;
            }

        }

        private void AutoMakeOrder(string Side, int Qty, decimal Price = 0)
        {
            switch (ddlAutoOrderType.SelectedItem)
            {
                case "Limit Post Only":
                    if (Price == 0)
                    {
                        Price = CalculateMarketOrderPrice(Side);
                    }
                    var MakerBuy = bitmex.PostOrderPostOnly(ActiveInstrument.Symbol, Side, Price, Qty);
                    break;
                case "Market":
                    bitmex.MarketOrder(ActiveInstrument.Symbol, Side, Qty);
                    break;
            }

        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            MakeOrder("Buy", Convert.ToInt32(nupQty.Value));
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            MakeOrder("Sell", Convert.ToInt32(nupQty.Value));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        }

        private void ddOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ddNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (FirstINITNET != true)
            {
                if (ws != null)
                {
                    ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"position:" + ActiveInstrument.Symbol + "\"]}");
                    ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"order:" + ActiveInstrument.Symbol + "\"]}");
                    ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"margin\"]}");
                    ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"orderBook10:" + ActiveInstrument.Symbol + "\"]}");
                    ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"trade:" + ActiveInstrument.Symbol + "\"]}");
                    ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"tradeBin5m:" + ActiveInstrument.Symbol + "\"]}");
                    ws.Close(); // Make sure our websocket is closed.
                }
                LoadAPISettings();
                InitializeAPI();
                InitializeWebSocket();
                InitializeSymbolSpecificData();
                InitializeWalletWebSocket();
                UpdatePositionInfo();
                UpdateOrderInfo();
            }
            else
            {
                FirstINITNET = false;
            }
        }

        private void ddlSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveInstrument = bitmex.GetInstrument(((Instrument)ddlSymbol.SelectedItem).Symbol)[0];
        }

        private void UpdateWebSocketInfo(string WebSocketInfo)
        {
            txtSettingsWebsocketInfo.Text = WebSocketInfo;
        }

        private void UpdateFormsForTickSize(decimal TickSize, int Decimals)
        {            
            nudCurrentPrice.DecimalPlaces = Decimals;
            nudCurrentPrice.Increment = TickSize;
            nudCurrentPrice.Controls[0].Enabled = false;
            nudCurrentPrice.Value = Math.Round(nudCurrentPrice.Value, Decimals);            
        }

        private void UpdateBalanceAndTime()
        {
            int HoursInFuture = 0;
            try
            {
                string USDValue = (Prices["XBTUSD"] * Balance).ToString("C", new CultureInfo("en-US"));
                lblBalanceAndTime.Invoke(new Action(() => lblBalanceAndTime.Text = "Balance: " + Math.Round(Balance, 8).ToString() + " | " + USDValue + "     " + DateTime.UtcNow.ToShortDateString() + " " + DateTime.UtcNow.AddHours(HoursInFuture).ToLongTimeString()));
                AutoQuantityCheck();
                txtBalanceStart.Text = Math.Round(FirstPriceLoad, 8).ToString();
                txtCurrentBalance.Text = Math.Round(Balance, 8).ToString();
                txtBTCEarned.Text = Math.Round((Math.Round(Balance, 8) - Math.Round(FirstPriceLoad, 8)), 8).ToString();
                txtPercentBTCEarned.Text = Math.Round((Math.Round((Math.Round(Balance, 8) - Math.Round(FirstPriceLoad, 8)), 8) / Math.Round(FirstPriceLoad, 8) * 100), 2).ToString();
            }
            catch (Exception ex)
            {
                lblBalanceAndTime.Invoke(new Action(() => lblBalanceAndTime.Text = "Balance: Error     " + DateTime.UtcNow.ToShortDateString() + " " + DateTime.UtcNow.AddHours(HoursInFuture).ToLongTimeString()));
                txtBalanceStart.Text = "";
                txtCurrentBalance.Text = "";
                txtBTCEarned.Text = "";
                txtPercentBTCEarned.Text = "";
            
            }            
        }

        private void NewWSCandle()
        {

            if (CandlesFirstTime == true)
            {                
                for (int i = 499; i > 1; i--)
                {
                    Candles[i].TimeStamp = Candles[i - 1].TimeStamp;
                    Candles[i].Open = Candles[i - 1].Open;
                    Candles[i].Close = Candles[i - 1].Close;
                    Candles[i].High = Candles[i - 1].High;
                    Candles[i].Low = Candles[i - 1].Low;
                    Candles[i].Volume = Candles[i - 1].Volume;
                    Candles[i].Trades = Candles[i - 1].Trades;
                    Candles[i].PCC = Candles[i - 1].PCC;
                    Candles[i].TDUoD = Candles[i - 1].TDUoD;
                    Candles[i].TDSeq = Candles[i - 1].TDSeq;
                    Candles[i].MACDHistorgram = Candles[i - 1].MACDHistorgram;
                    Candles[i].RSI = Candles[i - 1].RSI;
                    Candles[i].MA1 = Candles[i - 1].MA1;
                    Candles[i].MA2 = Candles[i - 1].MA2;
                    Candles[i].BBUpper = Candles[i - 1].BBUpper;
                    Candles[i].BBMiddle = Candles[i - 1].BBMiddle;
                    Candles[i].BBLower = Candles[i - 1].BBLower;
                    Candles[i].EMA1 = Candles[i - 1].EMA1;
                    Candles[i].EMA2 = Candles[i - 1].EMA2;
                    Candles[i].EMA3 = Candles[i - 1].EMA3;
                    Candles[i].MACDLine = Candles[i - 1].MACDLine;
                    Candles[i].MACDSignalLine = Candles[i - 1].MACDSignalLine;
                    Candles[i].STOCHK = Candles[i - 1].STOCHK;
                    Candles[i].STOCHD = Candles[i - 1].STOCHD;
                    Candles[i].TR = Candles[i - 1].TR;
                    Candles[i].ATR1 = Candles[i - 1].ATR1;
                    Candles[i].ATR2 = Candles[i - 1].ATR2;
                    //Candles[i].SetTR = Candles[i - 1].SetTR;
                    //Candles[i].GainOrLoss = Candles[i - 1].GainOrLoss;
                    Candles[i].RS = Candles[i - 1].RS;
                    Candles[i].AVGGain = Candles[i - 1].AVGGain;
                    Candles[i].AVGLoss = Candles[i - 1].AVGLoss;
                }

                Candles[1].TimeStamp = CandlesWebSocket.TimeStamp;
                Candles[1].Open = CandlesWebSocket.Open;
                Candles[1].Close = CandlesWebSocket.Close;
                Candles[1].High = CandlesWebSocket.High;
                Candles[1].Low = CandlesWebSocket.Low;
                Candles[1].Volume = CandlesWebSocket.Volume;
                Candles[1].Trades = CandlesWebSocket.Trades;

                Candles[0].TimeStamp = Candles[1].TimeStamp.AddMinutes(5);
                Candles[0].Open = Candles[1].Open;
                Candles[0].Close = Candles[1].Open;
                Candles[0].High = Candles[1].Open;
                Candles[0].Low = Candles[1].Open;
                Candles[0].Volume = null;
                Candles[0].Trades = 0;
                Candles[0].PCC = 0;
                Candles[0].TDUoD = null;
                Candles[0].TDSeq = 0;
                Candles[0].MACDHistorgram = null;
                Candles[0].RSI = null;
                Candles[0].MA1 = null;
                Candles[0].MA2 = null;
                Candles[0].BBUpper = null;
                Candles[0].BBMiddle = null;
                Candles[0].BBLower = null;
                Candles[0].EMA1 = null;
                Candles[0].EMA2 = null;
                Candles[0].EMA3 = null;
                Candles[0].MACDLine = null;
                Candles[0].MACDSignalLine = null;
                Candles[0].STOCHK = null;
                Candles[0].STOCHD = null;
                Candles[0].TR = null;
                Candles[0].ATR1 = null;
                Candles[0].ATR2 = null;
                //Candles[i].SetTR = Candles[i - 1].SetTR;
                //Candles[i].GainOrLoss = Candles[i - 1].GainOrLoss;
                Candles[0].RS = null;
                Candles[0].AVGGain = null;
                Candles[0].AVGLoss = null;

            }




        }

        private void UpdateCandles ()
        {

            #region ORIGINAL CANDLES
            // Get Candles

            //if (CandlesFirstTime == false)
            //{
                Candles = bitmex.GetCandleHistory(ActiveInstrument.Symbol, 500, ddlCandleTimes.SelectedItem.ToString());
            //}

           


            Candles = Candles.OrderBy(a => a.TimeStamp).ToList();

            

            // For TD Sequential
            int TimeFrameTDSeq = 0;
            string UpOrDown = "Down";
            int UpValue = 1;
            int DownValue = 1;

            //  Set indicator info
            foreach (Candle c in Candles)
            {
                c.PCC = Candles.Where(a => a.TimeStamp < c.TimeStamp).Count();
                
                #region TDSeq

                if (c.PCC >= 4)
                {                        
                    
                    double? FourCandlesBefore = Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(TimeFrameTDSeq).Close;
                    if (FourCandlesBefore < c.Close)
                    {
                        UpOrDown = "Up";
                        DownValue = 1;
                        c.TDSeq = UpValue;
                        c.TDUoD = UpOrDown;
                        UpValue++;
                    }
                    else if (FourCandlesBefore > c.Close)
                    {
                        UpOrDown = "Down";
                        UpValue = 1;
                        c.TDSeq = DownValue;
                        c.TDUoD = UpOrDown;
                        DownValue++;
                    }
                    else if (FourCandlesBefore == c.Close)
                    {
                        UpValue = 1;
                        DownValue = 1;
                        c.TDUoD = "Equal";
                        c.TDSeq = 0;
                    }
                                  
                    TimeFrameTDSeq = TimeFrameTDSeq + 1;
                }

                #endregion TDSeq



                int MA1Period = Convert.ToInt32(nudMA1.Value);
                int MA2Period = Convert.ToInt32(nudMA2.Value);

                if (c.PCC >= MA1Period)
                {
                    // Get the moving average over the last x periods using closing ** Includes current candle **
                    c.MA1 = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MA1Period).Average(a => a.Close);
                    // With not enough candles, we don't set to 0, we leave it null
                    if (c.MA1 != null) { c.MA1 = Math.Round(Convert.ToDouble(c.MA1), 4); }                    
                }

                if (c.PCC >= MA2Period)
                {
                        // Get the moving average over the last x periods using closing ** Includes current candle **
                        c.MA2 = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MA2Period).Average(a => a.Close);
                        // With not enough candles, we don't set to 0, we leave it null
                        if (c.MA2 != null) { c.MA2 = Math.Round(Convert.ToDouble(c.MA2), 4); }
                }

                if (c.PCC >= BBLength)
                {
                        // BBMiddle is just a 20 period moving average
                        c.BBMiddle = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength).Average(a => a.Close);

                        // Calcualting Standard Deviation
                        double total_squared = 0;
                        double total_for_average = Convert.ToDouble(Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength).Sum(a => a.Close));
                        foreach (Candle cb in Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength).ToList())
                        {
                            total_squared += Math.Pow(Convert.ToDouble(cb.Close), 2);
                        }
                        double stdev = Math.Sqrt((total_squared - (Math.Pow(total_for_average, 2) / BBLength)) / BBLength);
                        c.BBUpper = c.BBMiddle + (stdev * BBMultiplier);
                        c.BBLower = c.BBMiddle - (stdev * BBMultiplier);

                        if (c.BBMiddle != null) { c.BBMiddle = Math.Round(Convert.ToDouble(c.BBMiddle), 4); }
                        if (c.BBUpper != null) { c.BBUpper = Math.Round(Convert.ToDouble(c.BBUpper), 4); }
                        if (c.BBLower != null) { c.BBLower = Math.Round(Convert.ToDouble(c.BBLower), 4); }
                }

                if (c.PCC >= EMA1Period)
                {
                        double p1 = EMA1Period + 1;
                        double EMAMultiplier = Convert.ToDouble(2 / p1);

                        if (c.PCC == EMA1Period)
                        {
                            // This is our seed EMA, using SMA of EMA1 period for EMA 1
                            c.EMA1 = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA1Period).Average(a => a.Close);
                        }
                        else
                        {
                            double? LastEMA = Candles.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA1;
                            c.EMA1 = ((c.Close - LastEMA) * EMAMultiplier) + LastEMA;
                        }
                        if (c.EMA1 != null) { c.EMA1 = Math.Round(Convert.ToDouble(c.EMA1), 4); }
                }

                if (c.PCC >= EMA2Period)
                {
                        double p1 = EMA2Period + 1;
                        double EMAMultiplier = Convert.ToDouble(2 / p1);

                        if (c.PCC == EMA2Period)
                        {
                            // This is our seed EMA, using SMA
                            c.EMA2 = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA2Period).Average(a => a.Close);
                        }
                        else
                        {
                            double? LastEMA = Candles.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA2;
                            c.EMA2 = ((c.Close - LastEMA) * EMAMultiplier) + LastEMA;
                        }
                    if (c.EMA2 != null) { c.EMA2 = Math.Round(Convert.ToDouble(c.EMA2), 4); }
                }

                if (c.PCC >= EMA3Period)
                {
                        double p1 = EMA3Period + 1;
                        double EMAMultiplier = Convert.ToDouble(2 / p1);

                        if (c.PCC == EMA3Period)
                        {
                            // This is our seed EMA, using SMA
                            c.EMA3 = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA3Period).Average(a => a.Close);
                        }
                        else
                        {
                            double? LastEMA = Candles.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA3;
                            c.EMA3 = ((c.Close - LastEMA) * EMAMultiplier) + LastEMA;
                        }
                    if (c.EMA3 != null) { c.EMA3 = Math.Round(Convert.ToDouble(c.EMA3), 4); }
                }

                // MACD
                // We can only do this if we have the longest EMA period, EMA1
                if (c.PCC >= EMA1Period)
                {

                        double p1 = MACDEMAPeriod + 1;
                        double MACDEMAMultiplier = Convert.ToDouble(2 / p1);

                        c.MACDLine = (c.EMA2 - c.EMA1); // default is 12EMA - 26EMA
                        if (c.PCC == EMA1Period + MACDEMAPeriod)
                        {
                            // Set this to SMA of MACDLine to seed it
                            c.MACDSignalLine = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MACDEMAPeriod).Average(a => (a.MACDLine));
                        }
                        else if (c.PCC > EMA1Period + MACDEMAPeriod)
                        {
                            // We can calculate this EMA based off past candle EMAs
                            double? LastMACDSignalLine = Candles.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().MACDSignalLine;
                            c.MACDSignalLine = ((c.MACDLine - LastMACDSignalLine) * MACDEMAMultiplier) + LastMACDSignalLine;
                        }
                        c.MACDHistorgram = c.MACDLine - c.MACDSignalLine;

                        if (c.MACDSignalLine != null) { c.MACDSignalLine = Math.Round(Convert.ToDouble(c.MACDSignalLine), 4); }
                        if (c.MACDLine != null) { c.MACDLine = Math.Round(Convert.ToDouble(c.MACDLine), 4); }
                        if (c.MACDHistorgram != null) { c.MACDHistorgram = Math.Round(Convert.ToDouble(c.MACDHistorgram), 4); }

                }


                #region ATR

                    ATR1Period = Convert.ToInt32(nudATRPeriod.Value);
                // ATR, setting TR
                    if (c.PCC == 0)
                    {
                        c.SetTR(c.High);
                    }
                    else if (c.PCC > 0)
                    {
                        c.SetTR(Candles.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().Close);
                    }

                // Setting ATRs
                    
                    if (c.PCC == ATR1Period - 1)
                    {
                        c.ATR1 = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(ATR1Period).Average(a => a.TR);
                    }
                    else if (c.PCC > ATR1Period - 1)
                    {
                        double p1 = ATR1Period + 1;
                        double ATR1Multiplier = Convert.ToDouble(2 / p1);
                        double? LastATR1 = Candles.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().ATR1;
                        c.ATR1 = ((c.TR - LastATR1) * ATR1Multiplier) + LastATR1;
                    }
                    

                    if (c.PCC == ATR2Period - 1)
                    {
                        c.ATR2 = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(ATR2Period).Average(a => a.TR);
                    }
                    else if (c.PCC > ATR2Period - 1)
                    {
                        double p1 = ATR2Period + 1;
                        double ATR2Multiplier = Convert.ToDouble(2 / p1);
                        double? LastATR2 = Candles.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().ATR2;
                        c.ATR2 = ((c.TR - LastATR2) * ATR2Multiplier) + LastATR2;
                    }
                    if (c.TR != null) { c.TR = Math.Round(Convert.ToDouble(c.TR), 4); }
                    if (c.ATR1 != null) { c.ATR1 = Math.Round(Convert.ToDouble(c.ATR1), 4); }
                    if (c.ATR2 != null) { c.ATR2 = Math.Round(Convert.ToDouble(c.ATR2), 4); }
                #endregion ATR

                #region ATR Trailing Stop


                ATRMultip = Convert.ToDouble(nudATRMultiplier.Value);

                if (c.PCC == ATR1Period - 1)
                {
                    double NLoss = Convert.ToDouble(c.ATR1) * ATRMultip;

                    if (c.Close > 0 && Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC-1).Close > 0 )
                    {
                        c.ATRTrailingStop = Math.Max(0, Convert.ToDouble(c.Close) - NLoss);
                    }
                    else if(c.Close < 0 && Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < 0)
                    {
                        c.ATRTrailingStop = Math.Min(0, Convert.ToDouble(c.Close) + NLoss);
                    }
                    else if(c.Close > 0)
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) - NLoss;
                    }
                    else
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) + NLoss;
                    }

                    if (Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < 0 && c.Close > 0)
                    {
                        c.ATRTrailingStopPOS = 1;
                    }
                    else if (Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close > 0 && c.Close < 0)
                    {
                        c.ATRTrailingStopPOS = -1;
                    }
                    else
                    {
                        c.ATRTrailingStopPOS = 0;
                    }

                    if (c.ATRTrailingStopPOS == -1)
                    {
                        c.ATRTS = "Down";
                    }
                    else if (c.ATRTrailingStopPOS == 1)
                    {
                        c.ATRTS = "Up";
                    }
                    else
                    {
                        c.ATRTS = "Blue";
                    }

                }
                else if (c.PCC > ATR1Period - 1)
                {
                    double NLoss = Convert.ToDouble(c.ATR1) * ATRMultip;

                    if (c.Close > Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close > Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStop = Math.Max(Convert.ToDouble(Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop), Convert.ToDouble(c.Close) - NLoss);
                    }
                    else if(c.Close < Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStop = Math.Min(Convert.ToDouble(Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop), Convert.ToDouble(c.Close) + NLoss);
                    }
                    else if (c.Close > Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) - NLoss;
                    }
                    else
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) + NLoss;
                    }



                    if (Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && c.Close > Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStopPOS = 1;
                    }
                    else if (Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close > Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && c.Close < Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStopPOS = -1;
                    }
                    else
                    {
                        c.ATRTrailingStopPOS = Candles.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStopPOS;
                    }



                    if (c.ATRTrailingStopPOS == -1)
                    {
                        c.ATRTS = "Down";
                    }
                    else if (c.ATRTrailingStopPOS == 1)
                    {
                        c.ATRTS = "Up";
                    }
                    else
                    {
                        c.ATRTS = "Blue";
                    }

                }
                    #endregion ATR Trailing Stop

                    #region RSI
                    // For RSI
                    if (c.PCC == RSIPeriod - 1)
                    {
                        // AVG Gain is average of just gains, for all periods, (14), not just periods with gains.  Same goes for losses but with losses.
                        c.AVGGain = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Where(a => a.GainOrLoss > 0).Take(RSIPeriod).Sum(a => a.GainOrLoss) / RSIPeriod;
                        c.AVGLoss = (Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Where(a => a.GainOrLoss < 0).Take(RSIPeriod).Sum(a => a.GainOrLoss) / RSIPeriod) * -1;

                        c.RS = c.AVGGain / c.AVGLoss; // Only like this on first one (seeding it)
                        c.RSI = 100 - (100 / (1 + c.RS));
                    }
                    else if (c.PCC > RSIPeriod - 1)
                    {
                        double? LastAVGGain = Candles.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().AVGGain;
                        double? LastAVGLoss = Candles.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().AVGLoss;
                        double? Gain = 0;
                        double? Loss = 0;

                        if (c.GainOrLoss > 0)
                        {
                            Gain = c.GainOrLoss;
                        }
                        else if (c.GainOrLoss < 0)
                        {
                            Loss = c.GainOrLoss * -1;
                        }

                        c.AVGGain = (((LastAVGGain * (RSIPeriod - 1)) + Gain) / RSIPeriod);
                        c.AVGLoss = (((LastAVGLoss * (RSIPeriod - 1)) + Loss) / RSIPeriod);

                        c.RS = c.AVGGain / c.AVGLoss;
                        c.RSI = 100 - (100 / (1 + c.RS));
                    }
                    if (c.AVGGain != null) { c.AVGGain = Math.Round(Convert.ToDouble(c.AVGGain), 4); }
                    if (c.AVGLoss != null) { c.AVGLoss = Math.Round(Convert.ToDouble(c.AVGLoss), 4); }
                    if (c.RSI != null) { c.RSI = Math.Round(Convert.ToDouble(c.RSI), 4); }
                    if (c.RS != null) { c.RS = Math.Round(Convert.ToDouble(c.RS), 4); }
                #endregion RSI

                    #region StochRSI

                    // For STOCH
                    if (c.PCC >= STOCHLookbackPeriod - 1)
                    {
                        double? HighInLookback = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(STOCHLookbackPeriod).Max(a => a.High);
                        double? LowInLookback = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(STOCHLookbackPeriod).Min(a => a.Low);

                        c.STOCHK = ((c.Close - LowInLookback) / (HighInLookback - LowInLookback)) * 100;
                    }
                    if (c.PCC >= STOCHLookbackPeriod - 1 + STOCHDPeriod) // difference of -1 and 2 is 3, to allow for the 3 period SMA required for STOCH
                    {
                        c.STOCHD = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(STOCHDPeriod).Average(a => a.STOCHK);
                    }

                    if (c.STOCHK != null) { c.STOCHK = Math.Round(Convert.ToDouble(c.STOCHK), 4); }
                    if (c.STOCHD != null) { c.STOCHD = Math.Round(Convert.ToDouble(c.STOCHD), 4); }
                    #endregion StochRSI

            }

            Candles = Candles.OrderByDescending(a => a.TimeStamp).ToList();

                // Show Candles
            dgvCandles.DataSource = Candles;

            dgvCandles.Columns["MA1"].Visible = false;
            dgvCandles.Columns["MA2"].Visible = false;
            dgvCandles.Columns["EMA1"].Visible = false;
            dgvCandles.Columns["EMA2"].Visible = false;
            dgvCandles.Columns["EMA3"].Visible = false;
            dgvCandles.Columns["ATRTrailingStop"].Visible = false;
            dgvCandles.Columns["ATRTrailingStopPOS"].Visible = false;
            // dgvCandles.Columns["MACDLine"].Visible = false;
            //  dgvCandles.Columns["MACDSignalLine"].Visible = false;
            dgvCandles.Columns["STOCHK"].Visible = false;
            dgvCandles.Columns["STOCHD"].Visible = false;
            dgvCandles.Columns["TR"].Visible = false;
            dgvCandles.Columns["ATR1"].Visible = false;
            dgvCandles.Columns["ATR2"].Visible = false;
            dgvCandles.Columns["RS"].Visible = false;
            dgvCandles.Columns["AVGGain"].Visible = false;
            dgvCandles.Columns["AVGLoss"].Visible = false;
            dgvCandles.Columns["GainOrLoss"].Visible = false;


            #endregion ORIGINAL CANDLES

            #region ORIGINAL CANDLES CHECK
            //// Get Candles

            //string ddlCandleTimesCheck = "1d";

            //if (Convert.ToString(ddlCandleTimes.SelectedItem) == "1m")
            //{
            //    ddlCandleTimesCheck = "5m";
            //}
            //else if (Convert.ToString(ddlCandleTimes.SelectedItem) == "5m")
            //{
            //    ddlCandleTimesCheck = "1h";
            //}
            //else if (Convert.ToString(ddlCandleTimes.SelectedItem) == "1h")
            //{
            //    ddlCandleTimesCheck = "1d";
            //}

            //CandlesCHECK = bitmex.GetCandleHistory(ActiveInstrument.Symbol, 500, ddlCandleTimesCheck);

            //CandlesCHECK = CandlesCHECK.OrderBy(a => a.TimeStamp).ToList();

            ////  Set indicator info
            //foreach (Candle c in CandlesCHECK)
            //{
            //    c.PCC = CandlesCHECK.Where(a => a.TimeStamp < c.TimeStamp).Count();

            //    int MA1Period = Convert.ToInt32(nudMA1.Value);
            //    int MA2Period = Convert.ToInt32(nudMA2.Value);

            //    if (c.PCC >= MA1Period)
            //    {
            //        // Get the moving average over the last x periods using closing ** Includes current candle **
            //        c.MA1 = CandlesCHECK.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MA1Period).Average(a => a.Close);
            //        // With not enough candles, we don't set to 0, we leave it null
            //    }

            //    if (c.PCC >= MA2Period)
            //    {
            //        // Get the moving average over the last x periods using closing ** Includes current candle **
            //        c.MA2 = CandlesCHECK.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MA2Period).Average(a => a.Close);
            //        // With not enough candles, we don't set to 0, we leave it null
            //    }

            //    if (c.PCC >= BBLength)
            //    {
            //        // BBMiddle is just a 20 period moving average
            //        c.BBMiddle = CandlesCHECK.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength).Average(a => a.Close);

            //        // Calcualting Standard Deviation
            //        double total_squared = 0;
            //        double total_for_average = Convert.ToDouble(CandlesCHECK.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength).Sum(a => a.Close));
            //        foreach (Candle cb in CandlesCHECK.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength).ToList())
            //        {
            //            total_squared += Math.Pow(Convert.ToDouble(cb.Close), 2);
            //        }
            //        double stdev = Math.Sqrt((total_squared - (Math.Pow(total_for_average, 2) / BBLength)) / BBLength);
            //        c.BBUpper = c.BBMiddle + (stdev * BBMultiplier);
            //        c.BBLower = c.BBMiddle - (stdev * BBMultiplier);
            //    }

            //    if (c.PCC >= EMA1Period)
            //    {
            //        double p1 = EMA1Period + 1;
            //        double EMAMultiplier = Convert.ToDouble(2 / p1);

            //        if (c.PCC == EMA1Period)
            //        {
            //            // This is our seed EMA, using SMA of EMA1 period for EMA 1
            //            c.EMA1 = CandlesCHECK.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA1Period).Average(a => a.Close);
            //        }
            //        else
            //        {
            //            double? LastEMA = CandlesCHECK.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA1;
            //            c.EMA1 = ((c.Close - LastEMA) * EMAMultiplier) + LastEMA;
            //        }
            //    }

            //    if (c.PCC >= EMA2Period)
            //    {
            //        double p1 = EMA2Period + 1;
            //        double EMAMultiplier = Convert.ToDouble(2 / p1);

            //        if (c.PCC == EMA2Period)
            //        {
            //            // This is our seed EMA, using SMA
            //            c.EMA2 = CandlesCHECK.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA2Period).Average(a => a.Close);
            //        }
            //        else
            //        {
            //            double? LastEMA = CandlesCHECK.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA2;
            //            c.EMA2 = ((c.Close - LastEMA) * EMAMultiplier) + LastEMA;
            //        }
            //    }

            //    if (c.PCC >= EMA3Period)
            //    {
            //        double p1 = EMA3Period + 1;
            //        double EMAMultiplier = Convert.ToDouble(2 / p1);

            //        if (c.PCC == EMA3Period)
            //        {
            //            // This is our seed EMA, using SMA
            //            c.EMA3 = CandlesCHECK.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA3Period).Average(a => a.Close);
            //        }
            //        else
            //        {
            //            double? LastEMA = CandlesCHECK.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA3;
            //            c.EMA3 = ((c.Close - LastEMA) * EMAMultiplier) + LastEMA;
            //        }
            //    }

            //    // MACD
            //    // We can only do this if we have the longest EMA period, EMA1
            //    if (c.PCC >= EMA1Period)
            //    {

            //        double p1 = MACDEMAPeriod + 1;
            //        double MACDEMAMultiplier = Convert.ToDouble(2 / p1);

            //        c.MACDLine = (c.EMA2 - c.EMA1); // default is 12EMA - 26EMA
            //        if (c.PCC == EMA1Period + MACDEMAPeriod)
            //        {
            //            // Set this to SMA of MACDLine to seed it
            //            c.MACDSignalLine = CandlesCHECK.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MACDEMAPeriod).Average(a => (a.MACDLine));
            //        }
            //        else if (c.PCC > EMA1Period + MACDEMAPeriod)
            //        {
            //            // We can calculate this EMA based off past candle EMAs
            //            double? LastMACDSignalLine = CandlesCHECK.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().MACDSignalLine;
            //            c.MACDSignalLine = ((c.MACDLine - LastMACDSignalLine) * MACDEMAMultiplier) + LastMACDSignalLine;
            //        }
            //        c.MACDHistorgram = c.MACDLine - c.MACDSignalLine;
            //    }
            //}

            //CandlesCHECK = CandlesCHECK.OrderByDescending(a => a.TimeStamp).ToList();

            //// Show Candles
            ////dgvCandles.DataSource = Candles;

            #endregion ORIGINAL CANDLES CHECK

            AutoButtonCheck();

            // Determin the bot Mode based on MAs, trades happen or another timer
            if (Running) // We could set this up to also ignore setting bot mode if we've already reviewed current candles
                            // However, if you wanted to use info from most current candle, that wouldn't work well
            {                    
                SetBotMode(); // We only need to set bot mode if bot is running
                btnAutomatedTrading.Text = "Stop - " + Mode; // So we can see what the mode of the bot is while running
            }
            //CandlesFirstTime = true;

        }
        
        private void SetBotMode ()
        {
            // This is where we determine what mode bot is in

            switch (ddlStrategyType.SelectedItem.ToString())
            {
                case "Strat1":

                if (rdoBuy.Checked)
                {

                    #region OldBuyCheck
                    //if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 <= Candles[2].MA2)) // Most recent closed candle crossed over up
                    //{
                    //    // Did the last full candle have MA1 cross above MA2?  We'll need to buy now
                    //    Mode = "Buy";
                    //}
                    //else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 >= Candles[2].MA2))
                    //{
                    //    // Did the last full candle have MA1 cross below MA2?  We'll need to close any open position.
                    //    Mode = "CloseAndWait";
                    //}
                    //else if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 > Candles[2].MA2))
                    //{
                    //    // If no crossover, is MA1 still above MA2?  We'll need to leave our position open.
                    //    Mode = "Wait";
                    //}
                    //else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 < Candles[2].MA2))
                    //{
                    //    // If no crossover, is MA1 still below MA2?  We'll need to make sure we don't have a position open.
                    //    Mode = "CloseAndWait";
                    //}

                    // MACD Example
                    //if ((Candles[0].MACDLine > Candles[0].MACDSignalLine) && (Candles[1].MACDLine <= Candles[1].MACDSignalLine) && (Candles[0].Close < Candles[0].BBUpper)) // Most recently closed candle crossed over up
                    #endregion OldBuyCheck

                    if ((Candles[0].TDUoD == "Up") && (Candles[0].TDSeq == 1) && (Candles[1].TDUoD == "Down") && (Candles[1].TDSeq == 1))
                    {
                        Mode = "Wait";
                        Dblcheck = 0;
                        DblcheckSell = 0;
                    }
                    else if ((Candles[0].TDUoD == "Up") && (Candles[0].TDSeq == 2) && (Candles[2].TDUoD == "Down") && (Candles[2].TDSeq == 1))
                    {
                        Mode = "Wait";
                        Dblcheck = 0;
                        DblcheckSell = 0;
                    }
                    else if ((Candles[0].TDUoD == "Up") && (Candles[0].TDSeq == 1) && (Candles[0].Close < Candles[0].BBUpper) && (Candles[0].RSI <= (50 + Convert.ToInt32(nupRSIDifference.Value))))
                    {
                        // Did the last full candle have MACDLine cross above MACDSignalLine?  We'll need to buy now.
                        Dblcheck++;
                        DblcheckSell = 0;
                        if (ddlCandleTimes.SelectedItem.ToString() == "1m" && Dblcheck >= 16)
                        {
                            Mode = "Buy";
                        }
                        else if (ddlCandleTimes.SelectedItem.ToString() == "5m" && Dblcheck >= 80)
                        {
                            Mode = "Buy";
                        }
                        else if (ddlCandleTimes.SelectedItem.ToString() == "1h" && Dblcheck >= 960)
                        {
                            Mode = "Buy";
                        }
                        else
                        {
                            Mode = "Wait";
                        }

                    }
                    else if ((Candles[1].TDUoD == "Up") && (Candles[1].TDSeq == 1) && (Candles[0].TDUoD == "Up") && (Candles[0].TDSeq == 2) && (Candles[0].Close < Candles[0].BBUpper) && (Candles[0].RSI <= (50 + Convert.ToInt32(nupRSIDifference.Value))))
                    {
                        Mode = "Buy";
                        Dblcheck = 0;
                        DblcheckSell = 0;
                    }

                    #region OldSellCheck
                    //else if ((Candles[0].MACDLine < Candles[0].MACDSignalLine) && (Candles[1].MACDLine >= Candles[1].MACDSignalLine))
                    //{
                    //    // Did the last full candle have MACDLine cross below MACDSignalLine?  We'll need to close any open position.
                    //    Mode = "CloseAndWait";
                    //    Dblcheck = 0;
                    //    DblcheckSell = 0;
                    //}
                    //else if ((Candles[0].MACDLine > Candles[0].MACDSignalLine) && (Candles[1].MACDLine > Candles[1].MACDSignalLine))
                    //{
                    //    // If no crossover, is MACDLine still above MACDSignalLine? We'll need to leave our position open.
                    //    Mode = "Wait";
                    //    Dblcheck = 0;
                    //    DblcheckSell = 0;
                    //}
                    //else if ((Candles[0].MACDLine < Candles[0].MACDSignalLine) && (Candles[1].MACDLine < Candles[1].MACDSignalLine))
                    //{
                    //    // If no crossover, is MACDLine still below MACDSignalLine? We'll need to make sure we don't have a position open.
                    //    Mode = "CloseAndWait";
                    //    Dblcheck = 0;
                    //    DblcheckSell = 0;
                    //}
                    #endregion OldSellCheck
                    else
                    {
                        Mode = "Wait";
                        Dblcheck = 0;
                        DblcheckSell = 0;
                    }

                }
                else if(rdoSell.Checked)
                {
                    #region OldSellCheck2
                    //if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 <= Candles[2].MA2)) // Most recent closed candle crossed over up
                    //{
                    //    // Did the last full candle have MA1 cross above MA2?  We'll need to close any open position.
                    //    Mode = "CloseAndWait";
                    //}
                    //else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 >= Candles[2].MA2))
                    //{
                    //    // Did the last full candle have MA1 cross below MA2?  We'll need to sell now
                    //    Mode = "Sell";
                    //}
                    //else if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 > Candles[2].MA2))
                    //{
                    //    // If no crossover, is MA1 still above MA2?  We'll need to make sure we don't have a position open.
                    //    Mode = "CloseAndWait";
                    //}
                    //else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 < Candles[2].MA2))
                    //{
                    //    // If no crossover, is MA1 still below MA2?  We'll need to leave our position open.
                    //    Mode = "Wait";
                    //}


                    //if ((Candles[0].MACDLine > Candles[0].MACDSignalLine) && (Candles[1].MACDLine <= Candles[1].MACDSignalLine))// Most recent closed candle crossed over up
                    //{
                    //    // Did the last full candle have MA1 cross above MA2?  We'll need to close any open position.
                    //    Mode = "CloseAndWait";
                    //    DblcheckSell = 0;
                    //    Dblcheck = 0;
                    //}

                    //if ((Candles[0].MACDLine < Candles[0].MACDSignalLine) && (Candles[1].MACDLine >= Candles[1].MACDSignalLine) && (Candles[0].Close > Candles[0].BBLower))
                    #endregion OldSellCheck2

                    if ((Candles[0].TDUoD == "Down") && (Candles[0].TDSeq == 1) && (Candles[1].TDUoD == "Up") && (Candles[1].TDSeq == 1))
                    {
                        Mode = "Wait";
                        Dblcheck = 0;
                        DblcheckSell = 0;
                    }
                    else if ((Candles[0].TDUoD == "Down") && (Candles[0].TDSeq == 2) && (Candles[2].TDUoD == "Up") && (Candles[2].TDSeq == 1))
                    {
                        Mode = "Wait";
                        Dblcheck = 0;
                        DblcheckSell = 0;
                    }
                    else if ((Candles[0].TDUoD == "Down") && (Candles[0].TDSeq == 1) && (Candles[0].Close > Candles[0].BBLower) && (Candles[0].RSI >= (50 - Convert.ToInt32(nupRSIDifference.Value))))
                    {
                        // Did the last full candle have MA1 cross below MA2?  We'll need to sell now
                        DblcheckSell++;
                        Dblcheck = 0;
                    
                        if (ddlCandleTimes.SelectedItem.ToString() == "1m" && DblcheckSell >= 16)
                        {
                            Mode = "Sell";
                        }
                        else if (ddlCandleTimes.SelectedItem.ToString() == "5m" && DblcheckSell >= 80)
                        {
                            Mode = "Sell";
                        }
                        else if (ddlCandleTimes.SelectedItem.ToString() == "1h" && DblcheckSell >= 960)
                        {
                            Mode = "Sell";
                        }
                        else
                        {
                            Mode = "Wait";
                        }
                    }
                    else if ((Candles[1].TDUoD == "Down") && (Candles[1].TDSeq == 1) && (Candles[0].TDUoD == "Down") && (Candles[0].TDSeq == 2) && (Candles[0].Close > Candles[0].BBLower) && (Candles[0].RSI >= (50 - Convert.ToInt32(nupRSIDifference.Value))))
                    {
                        Mode = "Sell";
                        DblcheckSell = 0;
                        Dblcheck = 0;
                    }
                    #region OldSellCheck3
                    //else if ((Candles[0].MACDLine > Candles[0].MACDSignalLine) && (Candles[1].MACDLine > Candles[1].MACDSignalLine))
                    //{
                    //    // If no crossover, is MA1 still above MA2?  We'll need to make sure we don't have a position open.
                    //    Mode = "CloseAndWait";
                    //    DblcheckSell = 0;
                    //    Dblcheck = 0;
                    //}
                    //else if ((Candles[0].MACDLine < Candles[0].MACDSignalLine) && (Candles[1].MACDLine < Candles[1].MACDSignalLine))
                    //{
                    //    // If no crossover, is MA1 still below MA2?  We'll need to leave our position open.
                    //    Mode = "Wait";
                    //    DblcheckSell = 0;
                    //    Dblcheck = 0;
                    //}
                    #endregion OldSellCheck3
                    else
                    {
                        Mode = "Wait";
                        DblcheckSell = 0;
                        Dblcheck = 0;
                    }
                }

                    decimal HourDifference = Convert.ToDecimal(((Candles1h[0].High - Candles1h[0].Low) / Candles1h[0].High) * 100);
                    decimal HourDifferencePrevious = Convert.ToDecimal(((Candles1h[1].High - Candles1h[1].Low) / Candles1h[1].High) * 100);
                    if (HourDifference >= Convert.ToDecimal(2.5) || HourDifferencePrevious >= Convert.ToDecimal(2.5))
                    {
                        Mode = "Wait";
                        DblcheckSell = 0;
                        Dblcheck = 0;
                    }

                #region OldSwitchCheck
                //else if(rdoSwitch.Checked)
                //{
                //    if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 <= Candles[2].MA2)) // Most recent closed candle crossed over up
                //    {
                //        // Did the last full candle have MA1 cross above MA2?  Triggers a buy in switch setting.
                //        Mode = "Buy";
                //    }
                //    else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 >= Candles[2].MA2))
                //    {
                //        // Did the last full candle have MA1 cross below MA2?  Triggers a sell in switch setting.
                //        Mode = "Sell";
                //    }
                //    else if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 > Candles[2].MA2))
                //    {
                //        // If no crossover, is MA1 still above MA2?  Keep long positions open, close any shorts if they are still open.
                //        Mode = "CloseShortsAndWait";
                //    }
                //    else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 < Candles[2].MA2))
                //    {
                //        // If no crossover, is MA1 still below MA2?  Keep short positions open, close any longs if they are still open.
                //        Mode = "CloseLongsAndWait";
                //    }
                //}
                #endregion OldSwitchCheck

                break;

                case "Strat2":


                    if (rdoBuy.Checked)
                    {

                        if (ddlCandleTimes.SelectedIndex == 2)
                        {
                            if (Candles[0].TDUoD == "Up" && Candles[0].TDSeq <= 2)
                            {
                                Mode = "Buy";
                            }
                            else if(Candles[0].TDUoD == "Down" && Candles[0].TDSeq >= 9)
                            {
                                Mode = "Buy";
                            }
                            else
                            {
                                Mode = "Wait";
                            }
                        }
                        else
                        {
                            if (Candles1h[0].TDUoD == "Up" && Candles1h[0].TDSeq <= 2)
                            {
                                Mode = "Buy";
                            }
                            else if (Candles1h[0].TDUoD == "Down" && Candles1h[0].TDSeq >= 9)
                            {
                                Mode = "Buy";
                            }
                            else
                            {
                                Mode = "Wait";
                            }
                        }
                    }
                    else if (rdoSell.Checked)
                    {
                        if (ddlCandleTimes.SelectedIndex == 2)
                        {

                            if (Candles[0].TDUoD == "Down" && Candles[0].TDSeq <= 2)
                            {
                                Mode = "Sell";
                            }
                            else if (Candles[0].TDUoD == "Up" && Candles[0].TDSeq >= 9)
                            {
                                Mode = "Sell";
                            }
                            else
                            {
                                Mode = "Wait";
                            }
                        }
                        else
                        {
                            if (Candles1h[0].TDUoD == "Down" && Candles1h[0].TDSeq <= 2)
                            {
                                Mode = "Sell";
                            }
                            else if (Candles1h[0].TDUoD == "Up" && Candles1h[0].TDSeq >= 9)
                            {
                                Mode = "Sell";
                            }
                            else
                            {
                                Mode = "Wait";
                            }
                        }
                    }
                    else
                    {
                        Mode = "Wait";
                    }

                    decimal HourDifferencess = Convert.ToDecimal(((Candles1h[0].High - Candles1h[0].Low) / Candles1h[0].High) * 100);
                    decimal HourDifferencePreviousss = Convert.ToDecimal(((Candles1h[1].High - Candles1h[1].Low) / Candles1h[1].High) * 100);
                    if (HourDifferencess >= Convert.ToDecimal(2.5) || HourDifferencePreviousss >= Convert.ToDecimal(2.5))
                    {
                        Mode = "Wait";                        
                    }

                    break;

                case "Strat3":

                    if (rdoBuy.Checked)
                    {


                        //if ((Candles[0].TDUoD == "Up") && (Candles[0].TDSeq == 1) && (Candles[1].TDUoD == "Down") && (Candles[1].TDSeq == 1))
                        //{
                        //    Mode = "Wait";
                        //    Dblcheck = 0;
                        //    DblcheckSell = 0;
                        //}
                        //else if ((Candles[0].TDUoD == "Up") && (Candles[0].TDSeq == 2) && (Candles[2].TDUoD == "Down") && (Candles[2].TDSeq == 1))
                        //{
                        //    Mode = "Wait";
                        //    Dblcheck = 0;
                        //    DblcheckSell = 0;
                        //}
                        if ((Candles[1].TDUoD == "Up") && (Candles[1].TDSeq == 2) && (Candles[1].Close < Candles[1].BBUpper) && (Candles[1].RSI <= (50 + Convert.ToInt32(nupRSIDifferenceThree.Value))))
                        {
                           // Did the last full candle have MACDLine cross above MACDSignalLine?  We'll need to buy now.
                           // Dblcheck++;
                           // DblcheckSell = 0;
                           // if (ddlCandleTimes.SelectedItem.ToString() == "1m" && Dblcheck >= 16)
                           // {
                           //     Mode = "Buy";
                           // }
                           // else if (ddlCandleTimes.SelectedItem.ToString() == "5m" && Dblcheck >= 80)
                           // {
                           //     Mode = "Buy";
                           // }
                           // else if (ddlCandleTimes.SelectedItem.ToString() == "1h" && Dblcheck >= 960)
                           // {
                           //     Mode = "Buy";
                           // }
                           // else
                           // {
                           //     Mode = "Wait";
                           // }

                            Mode = "Buy";
                            Dblcheck = 0;
                            DblcheckSell = 0;

                        }
                        //else if ((Candles[1].TDUoD == "Up") && (Candles[1].TDSeq == 1) && (Candles[0].TDUoD == "Up") && (Candles[0].TDSeq == 2) && (Candles[0].Close < Candles[0].BBUpper) && (Candles[0].RSI <= (50 + Convert.ToInt32(nupRSIDifference.Value))))
                        //{
                        //    Mode = "Buy";
                        //    Dblcheck = 0;
                        //    DblcheckSell = 0;
                        //}

                        else
                        {
                            Mode = "Wait";
                            Dblcheck = 0;
                            DblcheckSell = 0;
                        }

                    }
                    else if (rdoSell.Checked)
                    {

                        //if ((Candles[0].TDUoD == "Down") && (Candles[0].TDSeq == 1) && (Candles[1].TDUoD == "Up") && (Candles[1].TDSeq == 1))
                        //{
                        //    Mode = "Wait";
                        //    Dblcheck = 0;
                        //    DblcheckSell = 0;
                        //}
                        //else if ((Candles[0].TDUoD == "Down") && (Candles[0].TDSeq == 2) && (Candles[2].TDUoD == "Up") && (Candles[2].TDSeq == 1))
                        //{
                        //    Mode = "Wait";
                        //    Dblcheck = 0;
                        //    DblcheckSell = 0;
                        //}
                        if ((Candles[1].TDUoD == "Down") && (Candles[1].TDSeq == 2) && (Candles[1].Close > Candles[1].BBLower) && (Candles[1].RSI >= (50 - Convert.ToInt32(nupRSIDifference.Value))))
                        {
                            // Did the last full candle have MA1 cross below MA2?  We'll need to sell now
                            //DblcheckSell++;
                            //Dblcheck = 0;

                            //if (ddlCandleTimes.SelectedItem.ToString() == "1m" && DblcheckSell >= 16)
                            //{
                            //    Mode = "Sell";
                            //}
                            //else if (ddlCandleTimes.SelectedItem.ToString() == "5m" && DblcheckSell >= 80)
                            //{
                            //    Mode = "Sell";
                            //}
                            //else if (ddlCandleTimes.SelectedItem.ToString() == "1h" && DblcheckSell >= 960)
                            //{
                            //    Mode = "Sell";
                            //}
                            //else
                            //{
                            //    Mode = "Wait";
                            //}

                            Mode = "Sell";
                            DblcheckSell = 0;
                            Dblcheck = 0;
                        }
                        //else if ((Candles[1].TDUoD == "Down") && (Candles[1].TDSeq == 1) && (Candles[0].TDUoD == "Down") && (Candles[0].TDSeq == 2) && (Candles[0].Close > Candles[0].BBLower) && (Candles[0].RSI >= (50 - Convert.ToInt32(nupRSIDifference.Value))))
                        //{
                        //    Mode = "Sell";
                        //    DblcheckSell = 0;
                        //    Dblcheck = 0;
                        //}
                        else
                        {
                            Mode = "Wait";
                            DblcheckSell = 0;
                            Dblcheck = 0;
                        }
                    }

                    //decimal HourDifferencet = Convert.ToDecimal(((Candles1h[0].High - Candles1h[0].Low) / Candles1h[0].High) * 100);
                    //decimal HourDifferencePrevioust = Convert.ToDecimal(((Candles1h[1].High - Candles1h[1].Low) / Candles1h[1].High) * 100);
                    //if (HourDifferencet >= Convert.ToDecimal(2.5) || HourDifferencePrevioust >= Convert.ToDecimal(2.5))
                    //{
                    //    Mode = "Wait";
                    //    DblcheckSell = 0;
                    //    Dblcheck = 0;
                    //}


                    break;
            }


        }

        private void tmrCandleUpdater_Tick(object sender, EventArgs e)
        {
            if (chkUpdateCandles.Checked)
            {
                UpdateCandles(); 
            }
        }

        private void chkUpdateCandles_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdateCandles.Checked)
            {
                tmrCandleUpdater.Start();
                tmrCandleUpdaterhd.Start();
            }
            else
            {
                tmrCandleUpdater.Stop();
                tmrCandleUpdaterhd.Stop();
            }
        }

        private void ddlCandleTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dblcheck = 0;
            DblcheckSell = 0;
            if (FirstINTICNDL != true)
            {
                UpdateCandles();
            }
            else
            {
                FirstINTICNDL = false;
            }
        }

        // Set Buy or Sell
        private void AutoButtonCheck()
        {

            switch (ddlStrategyType.SelectedItem.ToString())
            {
                case "Strat1":


                    if ((Candles[0].MACDHistorgram > 0 && Candles[1].MACDHistorgram > 0 && Candles[2].MACDHistorgram > 0 && Candles[3].MACDHistorgram > 0 && Candles[4].MACDHistorgram > 0) && Candles[0].RSI > 50)
                    {
                        rdoSell.Checked = true;
                        rdoBuy.Checked = false;
                    }
                    else if ((Candles[0].MACDHistorgram < 0 && Candles[1].MACDHistorgram < 0 && Candles[2].MACDHistorgram < 0 && Candles[3].MACDHistorgram < 0 && Candles[4].MACDHistorgram < 0) && Candles[0].RSI < 50)
                    {
                        rdoSell.Checked = false;
                        rdoBuy.Checked = true;
                    }

                    if (HourCandleFiratTime == false)
                    {
                        decimal HourDifference = (Convert.ToDecimal(Candles1h[0].High) - Convert.ToDecimal(Candles1h[0].Low)) / Convert.ToDecimal(Candles1h[0].High) * Convert.ToDecimal(100);
                        decimal HourDifferencePrevious = Convert.ToDecimal(((Candles1h[1].High - Candles1h[1].Low) / Candles1h[1].High) * 100);
                        if (HourDifference >= Convert.ToDecimal(2.5) || HourDifferencePrevious >= Convert.ToDecimal(2.5))
                        {
                            rdoSell.Checked = false;
                            rdoBuy.Checked = false;
                        }
                    }
                    break;

                case "Strat2":

                    if (ddlCandleTimes.SelectedIndex == 2)
                    { 

                        if (Candles1d[0].TDUoD == "Down" && Candles[0].TDUoD == "Down")
                        {
                            rdoSell.Checked = true;
                            rdoBuy.Checked = false;
                        }
                        else if (Candles1d[0].TDUoD == "Up" && Candles[0].TDUoD == "Up")
                        {
                            rdoSell.Checked = false;
                            rdoBuy.Checked = true;
                        }
                        else
                        {
                            rdoSell.Checked = false;
                            rdoBuy.Checked = false;
                        }

                        

                    }
                    else
                    {
                        if (Candles1d[0].TDUoD == "Down" && Candles1h[0].TDUoD == "Down")
                        {
                            rdoSell.Checked = true;
                            rdoBuy.Checked = false;
                        }
                        else if (Candles1d[0].TDUoD == "Up" && Candles1h[0].TDUoD == "Up")
                        {
                            rdoSell.Checked = false;
                            rdoBuy.Checked = true;
                        }
                        else
                        {
                            rdoSell.Checked = false;
                            rdoBuy.Checked = false;
                        }

                        
                    }


                    decimal HourDifferencesttwo = (Convert.ToDecimal(Candles1h[0].High) - Convert.ToDecimal(Candles1h[0].Low)) / Convert.ToDecimal(Candles1h[0].High) * Convert.ToDecimal(100);
                    decimal HourDifferencePrevioussttwo = Convert.ToDecimal(((Candles1h[1].High - Candles1h[1].Low) / Candles1h[1].High) * 100);
                    if (HourDifferencesttwo >= Convert.ToDecimal(2.5) || HourDifferencePrevioussttwo >= Convert.ToDecimal(2.5))
                    {
                        rdoSell.Checked = false;
                        rdoBuy.Checked = false;
                    }                   


                        break;

                case "Strat3":


                    if (Candles[0].MACDHistorgram > 0 && Candles[1].MACDHistorgram > 0 && Candles[2].MACDHistorgram > 0 && Candles[3].MACDHistorgram > 0 && Candles[4].MACDHistorgram > 0 && chkStrategyThreeShort.Checked == true)
                    {
                        rdoSell.Checked = true;
                        rdoBuy.Checked = false;
                    }
                    else if (Candles[0].MACDHistorgram < 0 && Candles[1].MACDHistorgram < 0 && Candles[2].MACDHistorgram < 0 && Candles[3].MACDHistorgram < 0 && Candles[4].MACDHistorgram < 0 && chkStrategyThreeLong.Checked == true)
                    {
                        rdoSell.Checked = false;
                        rdoBuy.Checked = true;
                    }
                    else
                    {
                        rdoSell.Checked = false;
                        rdoBuy.Checked = false;
                    }

                    //if (HourCandleFiratTime == false)
                    //{
                    //    decimal HourDifferencet = (Convert.ToDecimal(Candles1h[0].High) - Convert.ToDecimal(Candles1h[0].Low)) / Convert.ToDecimal(Candles1h[0].High) * Convert.ToDecimal(100);
                    //    decimal HourDifferencePrevioust = Convert.ToDecimal(((Candles1h[1].High - Candles1h[1].Low) / Candles1h[1].High) * 100);
                    //    if (HourDifferencet >= Convert.ToDecimal(2.5) || HourDifferencePrevioust >= Convert.ToDecimal(2.5))
                    //    {
                    //        rdoSell.Checked = false;
                    //        rdoBuy.Checked = false;
                    //    }
                    //}
                    break;
            }
        }

        private void btnAutomatedTrading_Click(object sender, EventArgs e)
        {
            if (SymbolPosition.IsOpen == true && SymbolPosition.CurrentQty > 0)
            {
                TrailingProfitStartPrice = 1000000;
                TrailingProfitExecutePrice = 999999;
            }

            if (SymbolPosition.IsOpen == true && SymbolPosition.CurrentQty < 0)
            {
                TrailingProfitStartPrice = 1;
                TrailingProfitExecutePrice = 2;
            }
            txtTPStart.Text = TrailingProfitStartPrice.ToString();
            txtTPExecute.Text = TrailingProfitExecutePrice.ToString();

            if (btnAutomatedTrading.Text == "Start")
            {
                tmrAutotradeExecution.Start();
                btnAutomatedTrading.Text = "Stop - " + Mode;
                btnAutomatedTrading.BackColor = Color.Red;
                Running = true;
                rdoBuy.Enabled = false;
                rdoSell.Enabled = false;
                rdoSwitch.Enabled = false;                
            }
            else
            {
                tmrAutotradeExecution.Stop();
                btnAutomatedTrading.Text = "Start";
                btnAutomatedTrading.BackColor = Color.LightGreen;
                Running = false;
                rdoBuy.Enabled = true;
                rdoSell.Enabled = true;
                rdoSwitch.Enabled = false;
            }            
        }      
            
        private void tmrAutotradeExecution_Tick(object sender, EventArgs e)
        {
            // OpenPositions = bitmex.GetOpenPositions(ActiveInstrument.Symbol);
            // OpenOrders = bitmex.GetOpenOrders(ActiveInstrument.Symbol);

            

            bool OpenOrdercheck = false;

            if (Candles[1].TDUoD == "Up" && Candles[1].TDSeq == 1 && Candles[0].TDUoD == "Down" && Candles[0].TDSeq >= 1)
            {
                UpStop = true;
                DownStop = false;
            }
            else if (Candles[1].TDUoD == "Up" && Candles[1].TDSeq == 2 && Candles[0].TDUoD == "Up" && Candles[0].TDSeq > 2)
            {
                UpStop = true;
                DownStop = false;
            }
            else if (Candles[1].TDUoD == "Up" && Candles[1].TDSeq == 2 && Candles[0].TDUoD == "Down" && Candles[0].TDSeq >= 1)
            {
                UpStop = true;
                DownStop = false;
            }
            else if (Candles[1].TDUoD == "Up" && Candles[1].TDSeq == 1 && Candles[0].TDUoD == "Equal")
            {
                UpStop = true;
                DownStop = false;
            }
            else if (Candles[1].TDUoD == "Up" && Candles[1].TDSeq == 2 && Candles[0].TDUoD == "Equal")
            {
                UpStop = true;
                DownStop = false;
            }
            else if (Candles[1].TDUoD == "Down" && Candles[1].TDSeq == 1 && Candles[0].TDUoD == "Up" && Candles[0].TDSeq >= 1)
            {
                DownStop = true;
                UpStop = false;
            }
            else if (Candles[1].TDUoD == "Down" && Candles[1].TDSeq == 2 && Candles[0].TDUoD == "Down" && Candles[0].TDSeq > 2)
            {
                DownStop = true;
                UpStop = false;
            }
            else if (Candles[1].TDUoD == "Down" && Candles[1].TDSeq == 2 && Candles[0].TDUoD == "Up" && Candles[0].TDSeq >= 1)
            {
                DownStop = true;
                UpStop = false;
            }
            else if (Candles[1].TDUoD == "Down" && Candles[1].TDSeq == 1 && Candles[0].TDUoD == "Equal")
            {
                DownStop = true;
                UpStop = false;
            }
            else if (Candles[1].TDUoD == "Down" && Candles[1].TDSeq == 2 && Candles[0].TDUoD == "Equal")
            {
                DownStop = true;
                UpStop = false;
            }
            else
            {
                DownStop = false;
                UpStop = false;
            }

            if (SymbolOrder.OrdStatus == "New" || SymbolOrder.OrdStatus == "PartiallyFilled")
            {
                OpenOrdercheck = true;
            }
            else
            {
                OpenOrdercheck = false;
            }



            if (SymbolPosition.IsOpen == true && OpenOrdercheck == true && SymbolOrder.OrdType == "Stop")
            {
                if (SymbolPosition.CurrentQty > 0)
                {
                    if (SymbolOrder.StopPx > SymbolPosition.AvgEntryPrice)
                    {
                        TrailigProfitOrderOpen = true;
                    }
                    else
                    {
                        TrailigProfitOrderOpen = false;
                    }
                }

                if (SymbolPosition.CurrentQty < 0)
                {
                    if (SymbolOrder.StopPx < SymbolPosition.AvgEntryPrice)
                    {
                        TrailigProfitOrderOpen = true;
                    }
                    else
                    {
                        TrailigProfitOrderOpen = false;
                    }
                }

            }
            else
            {
                TrailigProfitOrderOpen = false;
            }

            if (OpenOrdercheck == true && ((SymbolOrder.OrdType == "Stop" && TrailigProfitOrderOpen == true) || SymbolOrder.OrdType != "Stop"))
            {
                NotStopLoss = true;
            }
            else
            {
                NotStopLoss = false;
            }

            if (SymbolPosition.IsOpen == false && OpenOrdercheck == false && AvaliableMargin < ((nudPercentToTrade.Value / 100) * Balance))
            {                
                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
            }

            if (SymbolPosition.IsOpen == true && SymbolPosition.CurrentQty > 0)
            {
                StopLossStartPer = (Convert.ToDecimal(nudStartStopLoss.Value) / 5) / 100;
                StopLossStartPrice = Math.Ceiling((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) - (Convert.ToDecimal(SymbolPosition.AvgEntryPrice) * StopLossStartPer)) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);

                StopLossExecutePer = (Convert.ToDecimal(nudExecuteStopLoss.Value) / 5) / 100;
                StopLossExecutePrice = Math.Ceiling((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) - (Convert.ToDecimal(SymbolPosition.AvgEntryPrice) * StopLossExecutePer)) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);

                StopLossCancelPer = StopLossStartPer / 2;
                StopLossCancel = Math.Ceiling((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) - (Convert.ToDecimal(SymbolPosition.AvgEntryPrice) * StopLossCancelPer)) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);

                txtStartStopLoss.Text = StopLossStartPrice.ToString();
                txtExecuteStopLoss.Text = StopLossExecutePrice.ToString();
                txtCancelStopLoss.Text = StopLossCancel.ToString();
            }
            else if (SymbolPosition.IsOpen == true && SymbolPosition.CurrentQty < 0)
            {
                StopLossStartPer = 1 + ((Convert.ToDecimal(nudStartStopLoss.Value) / 5) / 100);
                StopLossStartPrice = Math.Ceiling((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) * StopLossStartPer) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);

                StopLossExecutePer = 1 + ((Convert.ToDecimal(nudExecuteStopLoss.Value) / 5) / 100);
                StopLossExecutePrice = Math.Ceiling((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) * StopLossExecutePer) / Convert.ToDecimal(.5)) *Convert.ToDecimal(.5);

                StopLossCancelPer = 1 + (((Convert.ToDecimal(nudStartStopLoss.Value) / 5) / 100) / 2);
                StopLossCancel = Math.Ceiling((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) * StopLossCancelPer) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);

                txtStartStopLoss.Text = StopLossStartPrice.ToString();
                txtExecuteStopLoss.Text = StopLossExecutePrice.ToString();
                txtCancelStopLoss.Text = StopLossCancel.ToString();
            }
            else
            {
                txtStartStopLoss.Text = "";
                txtExecuteStopLoss.Text = "";
                txtCancelStopLoss.Text = "";
            }


            if (SymbolPosition.IsOpen == true && SymbolPosition.CurrentQty > 0 && Prices[ActiveInstrument.Symbol] <= StopLossStartPrice)
            {
                StopLossActivate = true;
            }
            else if (SymbolPosition.IsOpen == true && SymbolPosition.CurrentQty < 0 && Prices[ActiveInstrument.Symbol] >= StopLossStartPrice)
            {
                StopLossActivate = true;
            }
            else
            {
                StopLossActivate = false;
            }

            if (!chkStopLoss.Checked && OpenOrdercheck == true && SymbolOrder.OrdType == "Stop" && TrailigProfitOrderOpen == false)
            {
                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
            }

            if (chkStopLoss.Checked && OpenOrdercheck == true && SymbolOrder.OrdType == "Stop" && TrailigProfitOrderOpen == false && SymbolPosition.CurrentQty > 0 && Prices[ActiveInstrument.Symbol] >= StopLossCancel && StopLossActivate == false)
            {
                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
            }

            if (chkStopLoss.Checked && OpenOrdercheck == true && SymbolOrder.OrdType == "Stop" && TrailigProfitOrderOpen == false && SymbolPosition.CurrentQty < 0 && Prices[ActiveInstrument.Symbol] <= StopLossCancel && StopLossActivate == false)
            {
                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
            }



            if (SymbolPosition.IsOpen == true && chkStopLoss.Checked && StopLossActivate == true)
            {
                if (OpenOrdercheck == true && NotStopLoss == true)
                {
                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                }

                if (SymbolPosition.CurrentQty > 0)
                {
                    SLside = "Sell";
                }
                else if (SymbolPosition.CurrentQty < 0)
                {
                    SLside = "Buy";
                }

                if (OpenOrdercheck == true && SymbolOrder.OrdType == "Stop" && TrailigProfitOrderOpen == false)
                {                    
                }                
                else
                {
                    bitmex.MarketStopLoss(ActiveInstrument.Symbol, SLside, StopLossExecutePrice, Math.Abs(Convert.ToInt32(SymbolPosition.CurrentQty)));
                }                
            }

            switch (ddlStrategyType.SelectedItem.ToString())
            {
                case "Strat1":

                    TPTimerLimit = 150;
                    txtTPTimer.Text = "TPTimer: " + TPTimerLimit.ToString();

                    if (TrailigProfitOrderOpen == true)
                    {
                        bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                    }


                 //if (OpenPositions.Any() && !OpenOrders.Any())
                if (SymbolPosition.IsOpen == true && OpenOrdercheck == false)
                {
                    bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                    //if (OpenPositions[0].CurrentQty > 0)
                    if (SymbolPosition.CurrentQty > 0)
                    {
                        // NEW TEST LIMIT CLOSE OPEN POSITON
                        decimal UserPercent = 1 + ((Convert.ToDecimal(nudPercentEarn.Value) / 5) / 100);
                        decimal PriceLCOP = Math.Ceiling((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) * UserPercent) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);
                        if (PriceLCOP < CalculateMarketOrderPrice("Sell"))
                        {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, CalculateMarketOrderPrice("Sell"));
                                }
                        }
                        else
                        {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, PriceLCOP);
                                }
                        }
                    }
                    //else if (OpenPositions[0].CurrentQty < 0)
                    else if (SymbolPosition.CurrentQty < 0)
                    {
                        // NEW TEST LIMIT CLOSE OPEN POSITON
                        decimal UserPercent = ((Convert.ToDecimal(nudPercentEarn.Value) / 5) / 100);
                        decimal UserPercentageAmount = Convert.ToDecimal(SymbolPosition.AvgEntryPrice) * UserPercent;
                        decimal PriceLCOP = Math.Floor((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) - UserPercentageAmount) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);
                        if (PriceLCOP > CalculateMarketOrderPrice("Buy"))
                        {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, CalculateMarketOrderPrice("Buy"));
                                }
                        }
                        else
                        {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, PriceLCOP);
                                }
                        }
                    }
                }
                //else if (OpenPositions.Any() && OpenOrders.Any() && OpenPositions[0].CurrentQty > 0 && OpenOrders.Any(a => a.Side == "Sell"))
                else if (SymbolPosition.IsOpen == true && OpenOrdercheck == true && SymbolPosition.CurrentQty > 0 && SymbolOrder.Side == "Sell" && SymbolOrder.OrdType != "Stop" && chkManualControl.Checked == false)
                {
                    goto SkipToEnd;
                }
                //else if (OpenPositions.Any() && OpenOrders.Any() && OpenPositions[0].CurrentQty < 0 && OpenOrders.Any(a => a.Side == "Buy"))
                else if (SymbolPosition.IsOpen == true && OpenOrdercheck == true && SymbolPosition.CurrentQty < 0 && SymbolOrder.Side == "Buy" && SymbolOrder.OrdType != "Stop" && chkManualControl.Checked == false)
                {
                    goto SkipToEnd;
                }
                //else if (OpenPositions.Any() && OpenOrders.Any() && OpenPositions[0].CurrentQty > 0 && OpenOrders.Any(a => a.Side == "Buy"))
                else if (SymbolPosition.IsOpen == true && OpenOrdercheck == true && SymbolPosition.CurrentQty > 0 && SymbolOrder.Side == "Buy" && SymbolOrder.OrdType != "Stop" && chkManualControl.Checked == false)
                {
                    if (rdoBuy.Checked)
                    {
                        goto SkipToEnd;
                    }
                    else if (rdoSell.Checked)
                    {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                            }
                    }
                }
                //else if (OpenPositions.Any() && OpenOrders.Any() && OpenPositions[0].CurrentQty < 0 && OpenOrders.Any(a => a.Side == "Sell"))
                else if (SymbolPosition.IsOpen == true && OpenOrdercheck == true && SymbolPosition.CurrentQty < 0 && SymbolOrder.Side == "Buy" && SymbolOrder.OrdType != "Stop" && chkManualControl.Checked == false)
                {
                    if (rdoBuy.Checked)
                    {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                            }
                    }
                    else if (rdoSell.Checked)
                    {
                        goto SkipToEnd;
                    }
                }
                //else if (!OpenPositions.Any() && !OpenOrders.Any())
                else if (SymbolPosition.IsOpen == false && OpenOrdercheck == false && chkManualControl.Checked == false)
                {
                    if (rdoBuy.Checked && Mode == "Buy")
                    {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
                            }
                    }
                    else if (rdoSell.Checked && Mode == "Sell")
                    {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));
                            }
                    }
                }
                //else if (!OpenPositions.Any() && OpenOrders.Any())
                else if (SymbolPosition.IsOpen == false && OpenOrdercheck == true && SymbolOrder.OrdType != "Stop" && chkManualControl.Checked == false)
                {
                    if (rdoBuy.Checked && SymbolOrder.Side == "Sell")
                    {
                        if (Mode == "Buy")
                        {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
                                }
                        }
                        else if (Mode != "Buy")
                        {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                }
                        }                    
                    }
                    else if (rdoSell.Checked && SymbolOrder.Side == "Buy")
                    {
                        if (Mode == "Sell")
                        {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));
                                }
                        }
                        else if (Mode != "Sell")
                        {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                }
                        }
                    }

                    if (UpStop == true && SymbolOrder.Side == "Buy")
                    {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                            }
                    }
                    if (DownStop == true && SymbolOrder.Side == "Sell")
                    {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                            }
                    }
                }

                SkipToEnd:;

                break;

                case "Strat2":

                    
                    if (FirstTimeTPStrat == true)
                    {
                        if (OpenOrdercheck == true && (SymbolOrder.OrdType != "Stop" || TrailigProfitOrderOpen == true))
                        {
                            bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                        }
                        
                        FirstTimeTPStrat = false;
                    }

                    if (SymbolPosition.IsOpen == true && SymbolPosition.CurrentQty < 0 && TrailigProfitOrderOpen == false)
                    {
                        TrailingProfitStartPer = (Convert.ToDecimal(nudStartTrailingProfit.Value) / 5) / 100;
                        TrailingProfitStartPrice = Math.Floor((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) - (Convert.ToDecimal(SymbolPosition.AvgEntryPrice) * TrailingProfitStartPer)) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);

                        TrailingProfitExecutePer = 1 + ((Convert.ToDecimal(nudExecuteTrailingProfit.Value) / 5) / 100);
                        TrailingProfitExecutePrice = Math.Floor((Convert.ToDecimal(TrailingProfitStartPrice) * TrailingProfitExecutePer) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);

                        txtTPStart.Text = TrailingProfitStartPrice.ToString();
                        txtTPExecute.Text = TrailingProfitExecutePrice.ToString();
                    }
                    else if (SymbolPosition.IsOpen == true && SymbolPosition.CurrentQty > 0 && TrailigProfitOrderOpen == false)
                    {
                        TrailingProfitStartPer = 1 + ((Convert.ToDecimal(nudStartTrailingProfit.Value) / 5) / 100);
                        TrailingProfitStartPrice = Math.Ceiling((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) * TrailingProfitStartPer) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);

                        TrailingProfitExecutePer = (Convert.ToDecimal(nudExecuteTrailingProfit.Value) / 5) / 100;
                        TrailingProfitExecutePrice = Math.Ceiling((TrailingProfitStartPrice - (TrailingProfitStartPrice * TrailingProfitExecutePer)) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);

                        txtTPStart.Text = TrailingProfitStartPrice.ToString();
                        txtTPExecute.Text = TrailingProfitExecutePrice.ToString();
                    }


                    //Strat 2

                    if (SymbolPosition.IsOpen == true && OpenOrdercheck == false)
                    {
                        //if (OrderChange == true)
                        //{
                        //    OrderChange = false;
                        //}
                        //else
                        //{
                        //    bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                        //}

                        if (SymbolPosition.CurrentQty > 0)
                        {
                            TPSide = "Sell";
                        }
                        else if (SymbolPosition.CurrentQty < 0)
                        {
                            TPSide = "Buy";
                        }


                        if (SymbolPosition.CurrentQty > 0)
                        {
                            if (Prices[ActiveInstrument.Symbol] >= TrailingProfitStartPrice)
                            {
                                TrailingProfitStartPrice = Prices[ActiveInstrument.Symbol];
                                TrailingProfitExecutePrice = Math.Ceiling((TrailingProfitStartPrice - (TrailingProfitStartPrice * TrailingProfitExecutePer)) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);
                                txtTPStart.Text = TrailingProfitStartPrice.ToString();
                                txtTPExecute.Text = TrailingProfitExecutePrice.ToString();

                                if (PositionChange == true)
                                {
                                    PositionChange = false;
                                }
                                else
                                {
                                    bitmex.MarketStopLoss(ActiveInstrument.Symbol, TPSide, TrailingProfitExecutePrice, Math.Abs(Convert.ToInt32(SymbolPosition.CurrentQty)));
                                }
                            }
                        }
                        else if (SymbolPosition.CurrentQty < 0)
                        {
                            if (Prices[ActiveInstrument.Symbol] <= TrailingProfitStartPrice)
                            {
                                TrailingProfitStartPrice = Prices[ActiveInstrument.Symbol];
                                TrailingProfitExecutePrice = Math.Floor((Convert.ToDecimal(TrailingProfitStartPrice) * TrailingProfitExecutePer) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);
                                txtTPStart.Text = TrailingProfitStartPrice.ToString();
                                txtTPExecute.Text = TrailingProfitExecutePrice.ToString();
                                if (PositionChange == true)
                                {
                                    PositionChange = false;
                                }
                                else
                                {
                                    bitmex.MarketStopLoss(ActiveInstrument.Symbol, TPSide, TrailingProfitExecutePrice, Math.Abs(Convert.ToInt32(SymbolPosition.CurrentQty)));
                                }
                            }
                        }

                    }
                    else if (SymbolPosition.IsOpen == true && OpenOrdercheck == true && TrailigProfitOrderOpen == true)
                    {
                        if (SymbolPosition.CurrentQty > 0)
                        {
                            if (Prices[ActiveInstrument.Symbol] > TrailingProfitStartPrice)
                            {
                                TrailingProfitStartPrice = Prices[ActiveInstrument.Symbol];
                                TrailingProfitExecutePrice = Math.Ceiling((TrailingProfitStartPrice - (TrailingProfitStartPrice * TrailingProfitExecutePer)) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);
                                txtTPStart.Text = TrailingProfitStartPrice.ToString();
                                txtTPExecute.Text = TrailingProfitExecutePrice.ToString();

                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    bitmex.EditOrderPriceMarketStop(SymbolOrder.OrderId, TrailingProfitExecutePrice);
                                }
                            }
                        }
                        else if (SymbolPosition.CurrentQty < 0)
                        {
                            if (Prices[ActiveInstrument.Symbol] < TrailingProfitStartPrice)
                            {
                                TrailingProfitStartPrice = Prices[ActiveInstrument.Symbol];
                                TrailingProfitExecutePrice = Math.Floor((Convert.ToDecimal(TrailingProfitStartPrice) * TrailingProfitExecutePer) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);
                                txtTPStart.Text = TrailingProfitStartPrice.ToString();
                                txtTPExecute.Text = TrailingProfitExecutePrice.ToString();

                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    bitmex.EditOrderPriceMarketStop(SymbolOrder.OrderId, TrailingProfitExecutePrice);
                                }
                            }
                        }
                    }
                    else if (SymbolPosition.IsOpen == false && OpenOrdercheck == false && chkManualControl.Checked == false)
                    {
                        TPTimerLimit++;
                        if (TPTimerLimit > 150)
                        {
                            TPTimerLimit = 150;
                        }
                        txtTPTimer.Text = "TPTimer: " + TPTimerLimit.ToString();                        

                            if (rdoBuy.Checked && Mode == "Buy" && TPTimerLimit >= 150)
                            {
                                TPTimerLimit = 0;
                                txtTPTimer.Text = "TPTimer: " + TPTimerLimit.ToString();

                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
                                }
                            }
                            else if (rdoSell.Checked && Mode == "Sell" && TPTimerLimit >= 150)
                            {
                                TPTimerLimit = 0;
                                txtTPTimer.Text = "TPTimer: " + TPTimerLimit.ToString();
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));
                                }
                            }
                        



                    }                    
                    else if (SymbolPosition.IsOpen == false && OpenOrdercheck == true && SymbolOrder.OrdType != "Stop" && chkManualControl.Checked == false)
                    {

                        if (rdoBuy.Checked && SymbolOrder.Side == "Sell")
                        {
                            if (Mode == "Buy")
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
                                }
                            }
                            else if (Mode != "Buy")
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                }
                            } 
                        }
                        else if (rdoSell.Checked && SymbolOrder.Side == "Buy")
                        {
                            if (Mode == "Sell")
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));
                                }
                            }
                            else if (Mode != "Sell")
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                }
                            }
                        }

                        if (Mode == "Wait")
                        {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                            }
                        }

                    }
                    else if (SymbolPosition.IsOpen == false && OpenOrdercheck == true && TrailigProfitOrderOpen == true && chkManualControl.Checked == false)
                    {
                        if (OrderChange == true)
                        {
                            OrderChange = false;
                        }
                        else
                        {
                            bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                        }
                    }
                        break;

                case "Strat3":

                    TPTimerLimit = 150;
                    txtTPTimer.Text = "TPTimer: " + TPTimerLimit.ToString();

                    if (TrailigProfitOrderOpen == true)
                    {
                        bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                    }


                    //if (OpenPositions.Any() && !OpenOrders.Any())
                    if (SymbolPosition.IsOpen == true && OpenOrdercheck == false)
                    {
                        bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                        //if (OpenPositions[0].CurrentQty > 0)
                        if (SymbolPosition.CurrentQty > 0)
                        {
                            // NEW TEST LIMIT CLOSE OPEN POSITON
                            //decimal UserPercent = 1 + ((Convert.ToDecimal(nudPercentEarn.Value) / 5) / 100);
                            decimal PriceLCOP = Math.Ceiling((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) + Convert.ToDecimal(nudPriceChange.Value)) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);
                            if (PriceLCOP < CalculateMarketOrderPrice("Sell"))
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, CalculateMarketOrderPrice("Sell"));
                                }
                            }
                            else
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, PriceLCOP);
                                }
                            }
                        }
                        //else if (OpenPositions[0].CurrentQty < 0)
                        else if (SymbolPosition.CurrentQty < 0)
                        {
                            // NEW TEST LIMIT CLOSE OPEN POSITON
                            //decimal UserPercent = ((Convert.ToDecimal(nudPercentEarn.Value) / 5) / 100);
                            //decimal UserPercentageAmount = Convert.ToDecimal(SymbolPosition.AvgEntryPrice) * UserPercent;
                            decimal PriceLCOP = Math.Ceiling((Convert.ToDecimal(SymbolPosition.AvgEntryPrice) - Convert.ToDecimal(nudPriceChange.Value)) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);
                            if (PriceLCOP > CalculateMarketOrderPrice("Buy"))
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, CalculateMarketOrderPrice("Buy"));
                                }
                            }
                            else
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, PriceLCOP);
                                }
                            }
                        }
                    }
                    //else if (OpenPositions.Any() && OpenOrders.Any() && OpenPositions[0].CurrentQty > 0 && OpenOrders.Any(a => a.Side == "Sell"))
                    else if (SymbolPosition.IsOpen == true && OpenOrdercheck == true && SymbolPosition.CurrentQty > 0 && SymbolOrder.Side == "Sell" && SymbolOrder.OrdType != "Stop" && chkManualControl.Checked == false)
                    {
                        goto SkipToEndt;
                    }
                    //else if (OpenPositions.Any() && OpenOrders.Any() && OpenPositions[0].CurrentQty < 0 && OpenOrders.Any(a => a.Side == "Buy"))
                    else if (SymbolPosition.IsOpen == true && OpenOrdercheck == true && SymbolPosition.CurrentQty < 0 && SymbolOrder.Side == "Buy" && SymbolOrder.OrdType != "Stop" && chkManualControl.Checked == false)
                    {
                        goto SkipToEndt;
                    }
                    //else if (OpenPositions.Any() && OpenOrders.Any() && OpenPositions[0].CurrentQty > 0 && OpenOrders.Any(a => a.Side == "Buy"))
                    else if (SymbolPosition.IsOpen == true && OpenOrdercheck == true && SymbolPosition.CurrentQty > 0 && SymbolOrder.Side == "Buy" && SymbolOrder.OrdType != "Stop" && chkManualControl.Checked == false)
                    {
                        if (rdoBuy.Checked)
                        {
                            goto SkipToEndt;
                        }
                        else if (rdoSell.Checked)
                        {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                            }
                        }
                    }
                    //else if (OpenPositions.Any() && OpenOrders.Any() && OpenPositions[0].CurrentQty < 0 && OpenOrders.Any(a => a.Side == "Sell"))
                    else if (SymbolPosition.IsOpen == true && OpenOrdercheck == true && SymbolPosition.CurrentQty < 0 && SymbolOrder.Side == "Buy" && SymbolOrder.OrdType != "Stop" && chkManualControl.Checked == false)
                    {
                        if (rdoBuy.Checked)
                        {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                            }
                        }
                        else if (rdoSell.Checked)
                        {
                            goto SkipToEndt;
                        }
                    }
                    //else if (!OpenPositions.Any() && !OpenOrders.Any())
                    else if (SymbolPosition.IsOpen == false && OpenOrdercheck == false && chkManualControl.Checked == false)
                    {
                        if (rdoBuy.Checked && Mode == "Buy")
                        {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
                            }
                        }
                        else if (rdoSell.Checked && Mode == "Sell")
                        {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));
                            }
                        }
                    }
                    //else if (!OpenPositions.Any() && OpenOrders.Any())
                    else if (SymbolPosition.IsOpen == false && OpenOrdercheck == true && SymbolOrder.OrdType != "Stop" && chkManualControl.Checked == false)
                    {
                        if (rdoBuy.Checked && SymbolOrder.Side == "Sell")
                        {
                            if (Mode == "Buy")
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
                                }
                            }
                            else if (Mode != "Buy")
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                }
                            }
                        }
                        else if (rdoSell.Checked && SymbolOrder.Side == "Buy")
                        {
                            if (Mode == "Sell")
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));
                                }
                            }
                            else if (Mode != "Sell")
                            {
                                if (OrderChange == true)
                                {
                                    OrderChange = false;
                                }
                                else
                                {
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                }
                            }
                        }

                        if (UpStop == true && SymbolOrder.Side == "Buy")
                        {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                            }
                        }
                        if (DownStop == true && SymbolOrder.Side == "Sell")
                        {
                            if (OrderChange == true)
                            {
                                OrderChange = false;
                            }
                            else
                            {
                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                            }
                        }
                    }

                SkipToEndt:;

                    break;
            }


             

            #region ORIGINAL BACKUP

        //    #region BUY
        //    if (rdoBuy.Checked)
        //    {
        //        if (OpenPositions.Any() && !OpenOrders.Any() && OpenPositions[0].CurrentQty > 0)
        //        {
        //            // NEW TEST LIMIT CLOSE OPEN POSITON
        //            decimal UserPercent = 1 + ((Convert.ToDecimal(nudPercentEarn.Value) / 5) / 100);
        //            decimal PriceLCOP = Math.Ceiling((Convert.ToDecimal(OpenPositions[0].AvgEntryPrice) * UserPercent) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);
        //            if (PriceLCOP < CalculateMarketOrderPrice("Sell"))
        //            {
        //                bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, CalculateMarketOrderPrice("Sell"));
        //            }
        //            else
        //            {
        //                bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, PriceLCOP);
        //            }
        //        }
        //        else
        //        {
        //            switch (Mode)
        //            {
        //                case "Buy":
        //                    // See if already have a position open
        //                    if (OpenPositions.Any())
        //                    {
        //                        // We have an open position, is it at our desired quanity?
        //                        if (OpenPositions[0].CurrentQty < nudAutoQuantity.Value)
        //                        {
        //                            // If we have an open order, edit it
        //                            if (OpenOrders.Any(a => a.Side == "Sell"))
        //                            {
        //                                // We still have an open sell order, cancel that order, make a new buy order
        //                                //string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                                //AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                            }
        //                            else if (OpenOrders.Any(a => a.Side == "Buy"))
        //                            {
        //                                // Edit our only open order, code should not allow for more than 1 at a time for now
        //                                string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
        //                            }
        //                        } // No else, it is filled to where we want.
        //                    }
        //                    else
        //                    {
        //                        if (OpenOrders.Any())
        //                        {
        //                            // If we have an open order, edit it
        //                            if (OpenOrders.Any(a => a.Side == "Sell"))
        //                            {
        //                                // We still have an open sell order, cancel that order, make a new buy order
        //                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                                AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                            }
        //                            else if (OpenOrders.Any(a => a.Side == "Buy"))
        //                            {
        //                                // Edit our only open order, code should not allow for more than 1 at a time for now
        //                                string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
        //                        }
        //                    }
        //                    break;
        //                case "CloseAndWait":
        //                    // See if we have open positions, if so, close them
        //                    if (OpenPositions.Any())
        //                    {
        //                        // Now do we have open orders? If so, we want to make sure they are at the right price
        //                        if (OpenOrders.Any())
        //                        {
        //                            if (OpenOrders.Any(a => a.Side == "Buy"))
        //                            {
        //                                // We still have an open buy order, cancel that order, make a new sell order
        //                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                                AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                            }
        //                            else if (OpenOrders.Any(a => a.Side == "Sell"))
        //                            {
        //                                // Edit our only open order, code should not allow for more than 1 at a time for now
        //                                //string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            // No open orders, need to make an order to sell
        //                            //AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                        }
        //                    }
        //                    else if (OpenOrders.Any())
        //                    {
        //                        // We don't have an open position, but we have an open order, close that order, we don't want to open any 
        //                        string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                    }
        //                    break;
        //                case "Wait":
        //                    // We are still in wait mode, no new buying or selling - close open orders
        //                    if (!OpenPositions.Any() && OpenOrders.Any())
        //                    {
        //                        string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                    }
        //                    break;
        //            }
        //        }
        //    }
        //    #endregion BUY

        //    #region SELL
        //    else if (rdoSell.Checked)
        //    {

        //        if (OpenPositions.Any() && !OpenOrders.Any() && OpenPositions[0].CurrentQty < 0)
        //        {
        //            // NEW TEST LIMIT CLOSE OPEN POSITON
        //            decimal UserPercent = ((Convert.ToDecimal(nudPercentEarn.Value) / 5) / 100);
        //            decimal UserPercentageAmount = Convert.ToDecimal(OpenPositions[0].AvgEntryPrice) * UserPercent;
        //            decimal PriceLCOP = Math.Ceiling((Convert.ToDecimal(OpenPositions[0].AvgEntryPrice) - UserPercentageAmount) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);
        //            if (PriceLCOP > CalculateMarketOrderPrice("Buy"))
        //            {
        //                bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, CalculateMarketOrderPrice("Buy"));
        //            }
        //            else
        //            {
        //                bitmex.LimitCloseOpenPosition(ActiveInstrument.Symbol, PriceLCOP);
        //            }
        //        }
        //        else
        //        {

        //            switch (Mode)
        //            {
        //                case "Sell":
        //                    // See if already have a position open
        //                    if (OpenPositions.Any())
        //                    {
        //                        // We have an open position, is it at our desired quanity?
        //                        if (OpenPositions[0].CurrentQty < nudAutoQuantity.Value)
        //                        {
        //                            // If we have an open order, edit it
        //                            if (OpenOrders.Any(a => a.Side == "Buy"))
        //                            {
        //                                // We still have an open buy order, cancel that order, make a new sell order
        //                                //string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                                //AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                            }
        //                            else if (OpenOrders.Any(a => a.Side == "Sell"))
        //                            {
        //                                // Edit our only open order, code should not allow for more than 1 at a time for now
        //                                string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
        //                            }
        //                        } // No else, it is filled to where we want.
        //                    }
        //                    else
        //                    {
        //                        if (OpenOrders.Any())
        //                        {
        //                            // If we have an open order, edit it
        //                            if (OpenOrders.Any(a => a.Side == "Buy"))
        //                            {
        //                                // We still have an open order, cancel that order, make a new sell order
        //                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                                AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                            }
        //                            else if (OpenOrders.Any(a => a.Side == "Sell"))
        //                            {
        //                                // Edit our only open order, code should not allow for more than 1 at a time for now
        //                                string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));
        //                        }
        //                    }
        //                    break;
        //                case "CloseAndWait":
        //                    // See if we have open positions, if so, close them
        //                    if (OpenPositions.Any())
        //                    {
        //                        // Now do we have open orders? If so, we want to make sure they are at the right price
        //                        if (OpenOrders.Any())
        //                        {
        //                            if (OpenOrders.Any(a => a.Side == "Sell"))
        //                            {
        //                                // We still have an open buy order, cancel that order, make a new buy order
        //                                string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                                AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                            }
        //                            else if (OpenOrders.Any(a => a.Side == "Buy"))
        //                            {
        //                                // Edit our only open order, code should not allow for more than 1 at a time for now
        //                                //string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            // No open orders, need to make an order to buy
        //                            //AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                        }
        //                    }
        //                    else if (OpenOrders.Any())
        //                    {
        //                        // We don't have an open position, but we have an open order, close that order, we don't want to open any 
        //                        string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                    }
        //                    break;
        //                case "Wait":
        //                    // We are still in wait mode, no new buying or selling - close open orders
        //                    if (!OpenPositions.Any() && OpenOrders.Any())
        //                    {
        //                        string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                    }
        //                    break;
        //            }
        //        }
        //    }
        //    #endregion SELL

        //    #region SWITCH
        //    else if (rdoSwitch.Checked)
        //    {
        //        switch (Mode)
        //        {
        //            case "Buy":
        //                // See if already have a position open
        //                if (OpenPositions.Any())
        //                {
        //                    int PositionDifference = Convert.ToInt32(nudAutoQuantity.Value - OpenPositions[0].CurrentQty);

        //                    if (OpenOrders.Any())
        //                    {
        //                        // If we have an open order, edit it.
        //                        if (OpenOrders.Any(a => a.Side == "Sell"))
        //                        {
        //                            // We still have an open sell order, cancel that order, make a new buy order
        //                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                            AutoMakeOrder("Buy", PositionDifference);
        //                        }
        //                        else if (OpenOrders.Any(a => a.Side == "Buy"))
        //                        {
        //                            // Edit our only open order, code should not allow for more than 1 at a time for now
        //                            string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
        //                        }
        //                    }
        //                    else
        //                    {
        //                        // No open orders, make one for the difference
        //                        if (PositionDifference != 0)
        //                        {
        //                            AutoMakeOrder("Buy", Convert.ToInt32(PositionDifference));
        //                        }
        //                    }                            
        //                }
        //                else
        //                {
        //                    if (OpenOrders.Any())
        //                    {
        //                        // If we have an open order, edit it.
        //                        if (OpenOrders.Any(a => a.Side == "Sell"))
        //                        {
        //                            // We still have an open sell order, cancel that order, make a new buy order
        //                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                            AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
        //                        }

        //                        else if (OpenOrders.Any(a => a.Side == "Buy"))
        //                        {
        //                            // Edit our only open order, code should not allow for more than 1 at a time for now
        //                            string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
        //                        }                                

        //                    }
        //                    else
        //                    {
        //                        AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
        //                    }

        //                }
        //                break;
        //            case "Sell":

        //                if (OpenPositions.Any())
        //                {
        //                    int PositionDifference = Convert.ToInt32(nudAutoQuantity.Value + OpenPositions[0].CurrentQty);

        //                    if (OpenOrders.Any())
        //                    {
        //                        // If we have an open order, edit it.
        //                        if (OpenOrders.Any(a => a.Side == "Buy"))
        //                        {
        //                            // We still have an open buy order, cancel that order, make a new sell order
        //                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                            AutoMakeOrder("Sell", PositionDifference);
        //                        }
        //                        else if (OpenOrders.Any(a => a.Side == "Sell"))
        //                        {
        //                            // Edit our only open order, code should not allow for more than 1 at a time for now
        //                            string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
        //                        }
        //                    }
        //                    else
        //                    {
        //                        // No open orders, make one for the difference
        //                        if (PositionDifference != 0)
        //                        {
        //                            AutoMakeOrder("Sell", Convert.ToInt32(PositionDifference));
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (OpenOrders.Any())
        //                    {
        //                        // If we have an open order, edit it.
        //                        if (OpenOrders.Any(a => a.Side == "Buy"))
        //                        {
        //                            // We still have an open buy order, cancel that order, make a new sell order
        //                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                            AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));
        //                        }
        //                        else if (OpenOrders.Any(a => a.Side == "Sell"))
        //                        {
        //                            // Edit our only open order, code should not allow for more than 1 at a time for now
        //                            string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
        //                        }
        //                    }
        //                    else
        //                    {
        //                        AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));                                
        //                    }
        //                }
        //                break;
        //            case "CloseLongsAndWait":   
                        
        //                if (OpenPositions.Any())
        //                {
        //                    // Now, do we have any open orders? If so, we want to make sure they are at the right price
        //                    if (OpenOrders.Any())
        //                    {                                
        //                        if (OpenOrders.Any(a => a.Side == "Buy"))
        //                        {
        //                            // We still have an open buy order, cancel that order, make a new sell order
        //                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                            AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                        }
        //                        else if (OpenOrders.Any(a => a.Side == "Sell"))
        //                        {
        //                            // Edit our only open order, code should not allow for more than 1 at a time for now
        //                            string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
        //                        }
        //                    }
        //                    else if (OpenPositions[0].CurrentQty > 0)
        //                    {
        //                        // No open oreders, need to make an order to sell
        //                        AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                    }
        //                }
        //                else if (OpenOrders.Any())
        //                {
        //                    // We don't have an open position, but we do have an open order, close that order, we don't want to open any position here.
        //                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                }
        //                break;
        //            case "CloseShortsAndWait":

        //                // Close any open orders, close any open shorts, we've missed our chance to long.
        //                if (OpenPositions.Any())
        //                {
        //                    //Now, do we have any open orders? If so, we want to make sure they are at the right price
        //                    if (OpenOrders.Any())
        //                    {
        //                        if (OpenOrders.Any(a => a.Side == "Sell"))
        //                        {
        //                            // We still have an open sell order, cancel that order, make a new buy order
        //                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                            AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                        }
        //                        else if (OpenOrders.Any(a => a.Side == "Buy"))
        //                        {
        //                            // Edit our only open order, code should not allow for more than 1 at a time for now
        //                            string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
        //                        }
        //                    }
        //                    else if (OpenPositions[0].CurrentQty < 0)
        //                    {
        //                        // No open oreders, need to make an order to buy
        //                        AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
        //                    }
        //                }
        //                else if (OpenOrders.Any())
        //                {
        //                    // We don't have an open position, but we do have an open order, close that order, we don't want to open any position here.
        //                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
        //                }
        //                break;
        //        }
        //    }
        //#endregion SWITCH

        #endregion ORIGINAL BACKUP

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ws != null)
            {
                ws.Close(); // Make sure our websocket is closed.
            }
        }

        private void UpdatePrice()
        {
            try
            {
                nudCurrentPrice.Value = Prices[ActiveInstrument.Symbol];
            }
            catch (Exception ex)
            {

            }
        }
        private void UpdateOrderInfo()
        {
            if (SymbolOrder.OrdStatus == "New" || SymbolOrder.OrdStatus == "PartiallyFilled")
            {
                if (SymbolOrder.Side == "Buy")
                {
                    txtOrderSize.Text = SymbolOrder.OrderQty.ToString();
                }
                else if (SymbolOrder.Side == "Sell")
                {
                    txtOrderSize.Text = (SymbolOrder.OrderQty * -1).ToString();
                }                

                if (SymbolOrder.OrdType != "Stop")
                {
                    txtOrderPrice.Text = SymbolOrder.Price.ToString();
                }
                else if (SymbolOrder.OrdType == "Stop")
                {
                    txtOrderPrice.Text = "";
                }
                //txtOrderPrice.Text = SymbolOrder.Price.ToString();
                //txtOrderSize.Text = SymbolOrder.OrderQty.ToString();
                txtOrderStatus.Text = SymbolOrder.OrdStatus;
                txtOrderSide.Text = SymbolOrder.Side;
                txtOrderType.Text = SymbolOrder.OrdType;

                if (SymbolOrder.OrdType != "Stop" && SymbolOrder.OrdType != "LimitIfTouched")
                {
                    txtTrailingProfitStart.Text = "";
                }
                else if (SymbolOrder.OrdType == "Stop" || SymbolOrder.OrdType == "LimitIfTouched")
                {
                    txtTrailingProfitStart.Text = SymbolOrder.StopPx.ToString();
                }

            }
            else
            {
                txtOrderPrice.Text = "";
                txtOrderSize.Text = "";
                txtOrderSide.Text = "";
                txtOrderStatus.Text = "";
                txtOrderType.Text = "";
                txtTrailingProfitStart.Text = "";
            }
        }


            private void UpdatePositionInfo()
        {
            if (SymbolPosition.CurrentQty != 0 && SymbolPosition.IsOpen == true)
            {
                txtPositionSize.Text = SymbolPosition.CurrentQty.ToString();
                txtPositionEntryPrice.Text = Math.Round(Convert.ToDecimal(SymbolPosition.AvgEntryPrice), 2).ToString();
                txtPositionMarkPrice.Text = SymbolPosition.MarkPrice.ToString();
                txtPositionLiquidation.Text = SymbolPosition.LiquidationPrice.ToString();
                txtPositionMargin.Text = SymbolPosition.Leverage.ToString();
                txtPositionUnrealizedPnL.Text = SymbolPosition.UsefulUnrealisedPnl.ToString();
                txtPositionUnrealizedPnLPercent.Text = Math.Round(Convert.ToDecimal(SymbolPosition.UnrealisedPnlPcnt * 5 * 100), 2).ToString() + "%";

                if (SymbolPosition.OpenOrderBuyQty != 0 && SymbolPosition.OpenOrderBuyCost != 0 && SymbolPosition.OpenOrderBuyQty != null && SymbolPosition.OpenOrderBuyCost != null)
                {
                    PositionCloseValue = SymbolPosition.OpenOrderBuyQty / ((SymbolPosition.OpenOrderBuyCost * -1) / 100000000);
                    PositionCloseValue = Math.Ceiling(Convert.ToDecimal(PositionCloseValue) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);

                    txtPositionClosePosition.Text = PositionCloseValue.ToString();
                }
                else if (SymbolPosition.OpenOrderSellQty != 0 && SymbolPosition.OpenOrderSellCost != 0 && SymbolPosition.OpenOrderSellQty != null && SymbolPosition.OpenOrderSellCost != null)
                {
                    PositionCloseValue = SymbolPosition.OpenOrderSellQty / ((SymbolPosition.OpenOrderSellCost * -1) / 100000000);
                    PositionCloseValue = Math.Ceiling(Convert.ToDecimal(PositionCloseValue) / Convert.ToDecimal(.5)) * Convert.ToDecimal(.5);

                    txtPositionClosePosition.Text = PositionCloseValue.ToString();

                }
                else
                {
                    txtPositionClosePosition.Text = "0";
                }
                //if (nudPositionLimitPrice.Value == 0m) // Only updates when default value is present
                //{
                //    nudPositionLimitPrice.Value = Convert.ToDecimal(((int)Math.Floor((double)SymbolPosition.MarkPrice)).ToString() + ".0");
                //}

            }
            else
            {
                txtPositionSize.Text = "";
                txtPositionEntryPrice.Text = "";
                txtPositionMarkPrice.Text = "";
                txtPositionLiquidation.Text = "";
                txtPositionMargin.Text = "";
                txtPositionUnrealizedPnL.Text = "";
                txtPositionUnrealizedPnLPercent.Text = "";
                txtPositionClosePosition.Text = "";
            }
        }

        private void tmrClientUpdates_Tick(object sender, EventArgs e)
        {
            UpdatePrice();
            UpdatePositionInfo();
            UpdateOrderInfo();
            txtTPTimer.Text = "TPTimer: " + TPTimerLimit.ToString();
        }

        

        private void Heartbeat_Tick(object sender, EventArgs e)
        {
            if (DateTime.UtcNow.Second == 0)
            {
                //Update our balance each minute
                //UpdateBalanceAndTime();
            }

            // Update the time every second.
            UpdateBalanceAndTime();

            if (((TimeSpan)(DateTime.UtcNow - WebScocketLastMessage)).TotalSeconds > 5)
            {
                ws.Ping();
                if (ws.IsAlive == true)
                {

                }
                else
                {
                    WBFaliedTimes++;
                    txtWebSocketFails.Text = "Websocket failed times - " + WBFaliedTimes.ToString();
                    ws.Close();
                    InitializeWebSocket();
                    InitializeSymbolSpecificData();
                    InitializeWalletWebSocket();
                }
            }

            if (rdoBuy.Checked)
            {
                lblRetry.Text = "Buy tries: " + Dblcheck.ToString();
            }
            else if (rdoSell.Checked)
            {
                lblRetry.Text = "Sell tries: " + DblcheckSell.ToString();
            }           

            if (chkDCA.Checked == true && DCARunning == true)
            {
                if (ddlDCA.SelectedIndex == 0)
                {
                    txtLiqudationLimitCalculated.Text = Convert.ToString(Prices[ActiveInstrument.Symbol] - nudLiquidationLimit.Value);
                }
                if (ddlDCA.SelectedIndex == 1)
                {
                    txtLiqudationLimitCalculated.Text = Convert.ToString(Prices[ActiveInstrument.Symbol] + nudLiquidationLimit.Value);
                }

                DCA();
            }

        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }

        private void chkOverloadRetry_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OverloadRetry = chkOverloadRetry.Checked;
            SaveSettings();
        }

        private void nudOverloadRetryAttempts_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OverloadRetryAttempts = (int)nudOverloadRetryAttempts.Value;
            SaveSettings();
        }

        private void AutoQuantityCheck()
        {
            nudAutoQuantity.Value = Math.Round(((nudPercentToTrade.Value / 100) * Balance) * Prices["XBTUSD"] * 5);
            //nudAutoQuantity.Value = Math.Round(nudAutoQuantity.Value);

            nupQty.Value = Math.Round(((nudPercentToTrade.Value / 100) * Balance) * Prices["XBTUSD"]);
            if (nupQty.Value < Convert.ToDecimal(19))
            {
                nupQty.Value = Convert.ToDecimal(19);
            }
            //nupQty.Value = Math.Round(nupQty.Value);
        }

        private void nudPercentToTrade_ValueChanged(object sender, EventArgs e)
        {
            AutoQuantityCheck();
        }

        private void txtAPIKey_TextChanged(object sender, EventArgs e)
        {
            switch (ddNetwork.SelectedItem.ToString())
            {
                case "TestNet":
                    Properties.Settings.Default.TestAPIKey = txtAPIKey.Text;

                    WebSocketAPIKey = Properties.Settings.Default.TestAPIKey;
                    
                    break;
                case "RealNet":
                    Properties.Settings.Default.APIKey = txtAPIKey.Text;

                    WebSocketAPIKey = Properties.Settings.Default.APIKey;
                    
                    break;
            }
            SaveSettings();
            InitializeAPI();


            if (ws != null)
            {
                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"position:" + ActiveInstrument.Symbol + "\"]}");
                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"order:" + ActiveInstrument.Symbol + "\"]}");
                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"margin\"]}");
                ws.Close(); // Make sure our websocket is closed.
            }
            InitializeWebSocket();
            InitializeSymbolSpecificData();
            InitializeWalletWebSocket();
        }

        private void txtAPISecret_TextChanged(object sender, EventArgs e)
        {
            switch (ddNetwork.SelectedItem.ToString())
            {
                case "TestNet":
                    Properties.Settings.Default.TestAPISecret = txtAPISecret.Text;

                    WebSocketAPISecret = Properties.Settings.Default.TestAPISecret;                    
                    
                    break;
                case "RealNet":
                    Properties.Settings.Default.APISecret = txtAPISecret.Text;

                    WebSocketAPISecret = Properties.Settings.Default.APISecret;
                    
                    break;
            }
            SaveSettings();
            InitializeAPI();


            if (ws != null)
            {
                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"position:" + ActiveInstrument.Symbol + "\"]}");
                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"order:" + ActiveInstrument.Symbol + "\"]}");
                ws.Send("{\"op\": \"unsubscribe\", \"args\": [\"margin\"]}");
                ws.Close(); // Make sure our websocket is closed.
            }
            InitializeWebSocket();
            InitializeSymbolSpecificData();
            InitializeWalletWebSocket();
        }

        private void UpdateCandles1h()
        {
            HourCandleFiratTime = false;
            #region ORIGINAL CANDLES
            // Get Candles

            //if (CandlesFirstTime == false)
            //{
            Candles1h = bitmex.GetCandleHistory1h(ActiveInstrument.Symbol, 500, "1h");
            //}




            Candles1h = Candles1h.OrderBy(a => a.TimeStamp).ToList();



            // For TD Sequential
            int TimeFrameTDSeq1h = 0;
            string UpOrDown1h = "Down";
            int UpValue1h = 1;
            int DownValue1h = 1;

            //  Set indicator info
            foreach (Candle1h c in Candles1h)
            {
                c.PCC = Candles1h.Where(a => a.TimeStamp < c.TimeStamp).Count();

                #region TDSeq

                if (c.PCC >= 4)
                {

                    double? FourCandlesBefore1h = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(TimeFrameTDSeq1h).Close;
                    if (FourCandlesBefore1h < c.Close)
                    {
                        UpOrDown1h = "Up";
                        DownValue1h = 1;
                        c.TDSeq = UpValue1h;
                        c.TDUoD = UpOrDown1h;
                        UpValue1h++;
                    }
                    else if (FourCandlesBefore1h > c.Close)
                    {
                        UpOrDown1h = "Down";
                        UpValue1h = 1;
                        c.TDSeq = DownValue1h;
                        c.TDUoD = UpOrDown1h;
                        DownValue1h++;
                    }
                    else if (FourCandlesBefore1h == c.Close)
                    {
                        UpValue1h = 1;
                        DownValue1h = 1;
                        c.TDUoD = "Equal";
                        c.TDSeq = 0;
                    }

                    TimeFrameTDSeq1h = TimeFrameTDSeq1h + 1;
                }

                #endregion TDSeq



                int MA1Period1h = Convert.ToInt32(nudMA1.Value);
                int MA2Period1h = Convert.ToInt32(nudMA2.Value);

                if (c.PCC >= MA1Period1h)
                {
                    // Get the moving average over the last x periods using closing ** Includes current candle **
                    c.MA1 = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MA1Period1h).Average(a => a.Close);
                    // With not enough candles, we don't set to 0, we leave it null
                    if (c.MA1 != null) { c.MA1 = Math.Round(Convert.ToDouble(c.MA1), 4); }
                }

                if (c.PCC >= MA2Period1h)
                {
                    // Get the moving average over the last x periods using closing ** Includes current candle **
                    c.MA2 = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MA2Period1h).Average(a => a.Close);
                    // With not enough candles, we don't set to 0, we leave it null
                    if (c.MA2 != null) { c.MA2 = Math.Round(Convert.ToDouble(c.MA2), 4); }
                }

                if (c.PCC >= BBLength1h)
                {
                    // BBMiddle is just a 20 period moving average
                    c.BBMiddle = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength1h).Average(a => a.Close);

                    // Calcualting Standard Deviation
                    double total_squared1h = 0;
                    double total_for_average1h = Convert.ToDouble(Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength1h).Sum(a => a.Close));
                    foreach (Candle1h cb in Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength1h).ToList())
                    {
                        total_squared1h += Math.Pow(Convert.ToDouble(cb.Close), 2);
                    }
                    double stdev1h = Math.Sqrt((total_squared1h - (Math.Pow(total_for_average1h, 2) / BBLength1h)) / BBLength1h);
                    c.BBUpper = c.BBMiddle + (stdev1h * BBMultiplier1h);
                    c.BBLower = c.BBMiddle - (stdev1h * BBMultiplier1h);

                    if (c.BBMiddle != null) { c.BBMiddle = Math.Round(Convert.ToDouble(c.BBMiddle), 4); }
                    if (c.BBUpper != null) { c.BBUpper = Math.Round(Convert.ToDouble(c.BBUpper), 4); }
                    if (c.BBLower != null) { c.BBLower = Math.Round(Convert.ToDouble(c.BBLower), 4); }
                }

                if (c.PCC >= EMA1Period1h)
                {
                    double p11h = EMA1Period1h + 1;
                    double EMAMultiplier1h = Convert.ToDouble(2 / p11h);

                    if (c.PCC == EMA1Period1h)
                    {
                        // This is our seed EMA, using SMA of EMA1 period for EMA 1
                        c.EMA1 = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA1Period1h).Average(a => a.Close);
                    }
                    else
                    {
                        double? LastEMA1h = Candles1h.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA1;
                        c.EMA1 = ((c.Close - LastEMA1h) * EMAMultiplier1h) + LastEMA1h;
                    }
                    if (c.EMA1 != null) { c.EMA1 = Math.Round(Convert.ToDouble(c.EMA1), 4); }
                }

                if (c.PCC >= EMA2Period1h)
                {
                    double p11h = EMA2Period1h + 1;
                    double EMAMultiplier1h = Convert.ToDouble(2 / p11h);

                    if (c.PCC == EMA2Period1h)
                    {
                        // This is our seed EMA, using SMA
                        c.EMA2 = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA2Period1h).Average(a => a.Close);
                    }
                    else
                    {
                        double? LastEMA1h = Candles1h.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA2;
                        c.EMA2 = ((c.Close - LastEMA1h) * EMAMultiplier1h) + LastEMA1h;
                    }
                    if (c.EMA2 != null) { c.EMA2 = Math.Round(Convert.ToDouble(c.EMA2), 4); }
                }

                if (c.PCC >= EMA3Period1h)
                {
                    double p11h = EMA3Period1h + 1;
                    double EMAMultiplier1h = Convert.ToDouble(2 / p11h);

                    if (c.PCC == EMA3Period1h)
                    {
                        // This is our seed EMA, using SMA
                        c.EMA3 = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA3Period1h).Average(a => a.Close);
                    }
                    else
                    {
                        double? LastEMA1h = Candles1h.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA3;
                        c.EMA3 = ((c.Close - LastEMA1h) * EMAMultiplier1h) + LastEMA1h;
                    }
                    if (c.EMA3 != null) { c.EMA3 = Math.Round(Convert.ToDouble(c.EMA3), 4); }
                }

                // MACD
                // We can only do this if we have the longest EMA period, EMA1
                if (c.PCC >= EMA1Period1h)
                {

                    double p11h = MACDEMAPeriod1h + 1;
                    double MACDEMAMultiplier1h = Convert.ToDouble(2 / p11h);

                    c.MACDLine = (c.EMA2 - c.EMA1); // default is 12EMA - 26EMA
                    if (c.PCC == EMA1Period1h + MACDEMAPeriod1h)
                    {
                        // Set this to SMA of MACDLine to seed it
                        c.MACDSignalLine = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MACDEMAPeriod1h).Average(a => (a.MACDLine));
                    }
                    else if (c.PCC > EMA1Period1h + MACDEMAPeriod1h)
                    {
                        // We can calculate this EMA based off past candle EMAs
                        double? LastMACDSignalLine1h = Candles1h.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().MACDSignalLine;
                        c.MACDSignalLine = ((c.MACDLine - LastMACDSignalLine1h) * MACDEMAMultiplier1h) + LastMACDSignalLine1h;
                    }
                    c.MACDHistorgram = c.MACDLine - c.MACDSignalLine;

                    if (c.MACDSignalLine != null) { c.MACDSignalLine = Math.Round(Convert.ToDouble(c.MACDSignalLine), 4); }
                    if (c.MACDLine != null) { c.MACDLine = Math.Round(Convert.ToDouble(c.MACDLine), 4); }
                    if (c.MACDHistorgram != null) { c.MACDHistorgram = Math.Round(Convert.ToDouble(c.MACDHistorgram), 4); }

                }

                #region ATR
                ATR1Period = Convert.ToInt32(nudATRPeriod.Value);
                // ATR, setting TR
                if (c.PCC == 0)
                {
                    c.SetTR(c.High);
                }
                else if (c.PCC > 0)
                {
                    c.SetTR(Candles1h.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().Close);
                }

                // Setting ATRs
                if (c.PCC == ATR1Period1h - 1)
                {
                    c.ATR1 = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(ATR1Period1h).Average(a => a.TR);
                }
                else if (c.PCC > ATR1Period1h - 1)
                {
                    double p11h = ATR1Period1h + 1;
                    double ATR1Multiplier1h = Convert.ToDouble(2 / p11h);
                    double? LastATR11h = Candles1h.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().ATR1;
                    c.ATR1 = ((c.TR - LastATR11h) * ATR1Multiplier1h) + LastATR11h;
                }


                if (c.PCC == ATR2Period1h - 1)
                {
                    c.ATR2 = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(ATR2Period1h).Average(a => a.TR);
                }
                else if (c.PCC > ATR2Period1h - 1)
                {
                    double p11h = ATR2Period1h + 1;
                    double ATR2Multiplier1h = Convert.ToDouble(2 / p11h);
                    double? LastATR21h = Candles1h.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().ATR2;
                    c.ATR2 = ((c.TR - LastATR21h) * ATR2Multiplier1h) + LastATR21h;
                }
                if (c.TR != null) { c.TR = Math.Round(Convert.ToDouble(c.TR), 4); }
                if (c.ATR1 != null) { c.ATR1 = Math.Round(Convert.ToDouble(c.ATR1), 4); }
                if (c.ATR2 != null) { c.ATR2 = Math.Round(Convert.ToDouble(c.ATR2), 4); }
                #endregion ATR

                #region ATR Trailing Stop
                ATRMultip = Convert.ToDouble(nudATRMultiplier.Value);

                if (c.PCC == ATR1Period - 1)
                {
                    double NLoss1h = Convert.ToDouble(c.ATR1) * ATRMultip;

                    if (c.Close > 0 && Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close > 0)
                    {
                        c.ATRTrailingStop = Math.Max(0, Convert.ToDouble(c.Close) - NLoss1h);
                    }
                    else if (c.Close < 0 && Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < 0)
                    {
                        c.ATRTrailingStop = Math.Min(0, Convert.ToDouble(c.Close) + NLoss1h);
                    }
                    else if (c.Close > 0)
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) - NLoss1h;
                    }
                    else
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) + NLoss1h;
                    }

                    if (Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < 0 && c.Close > 0)
                    {
                        c.ATRTrailingStopPOS = 1;
                    }
                    else if (Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close > 0 && c.Close < 0)
                    {
                        c.ATRTrailingStopPOS = -1;
                    }
                    else
                    {
                        c.ATRTrailingStopPOS = 0;
                    }

                    if (c.ATRTrailingStopPOS == -1)
                    {
                        c.ATRTS = "Down";
                    }
                    else if (c.ATRTrailingStopPOS == 1)
                    {
                        c.ATRTS = "Up";
                    }
                    else
                    {
                        c.ATRTS = "Blue";
                    }

                }
                else if (c.PCC > ATR1Period - 1)
                {
                    double NLoss1h = Convert.ToDouble(c.ATR1) * ATRMultip;

                    if (c.Close > Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close > Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStop = Math.Max(Convert.ToDouble(Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop), Convert.ToDouble(c.Close) - NLoss1h);
                    }
                    else if (c.Close < Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStop = Math.Min(Convert.ToDouble(Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop), Convert.ToDouble(c.Close) + NLoss1h);
                    }
                    else if (c.Close > Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) - NLoss1h;
                    }
                    else
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) + NLoss1h;
                    }



                    if (Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && c.Close > Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStopPOS = 1;
                    }
                    else if (Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close > Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && c.Close < Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStopPOS = -1;
                    }
                    else
                    {
                        c.ATRTrailingStopPOS = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStopPOS;
                    }



                    if (c.ATRTrailingStopPOS == -1)
                    {
                        c.ATRTS = "Down";
                    }
                    else if (c.ATRTrailingStopPOS == 1)
                    {
                        c.ATRTS = "Up";
                    }
                    else
                    {
                        c.ATRTS = "Blue";
                    }

                }
                #endregion ATR Trailing Stop


                #region RSI
                // For RSI
                if (c.PCC == RSIPeriod1h - 1)
                {
                    // AVG Gain is average of just gains, for all periods, (14), not just periods with gains.  Same goes for losses but with losses.
                    c.AVGGain = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Where(a => a.GainOrLoss > 0).Take(RSIPeriod1h).Sum(a => a.GainOrLoss) / RSIPeriod1h;
                    c.AVGLoss = (Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Where(a => a.GainOrLoss < 0).Take(RSIPeriod1h).Sum(a => a.GainOrLoss) / RSIPeriod1h) * -1;

                    c.RS = c.AVGGain / c.AVGLoss; // Only like this on first one (seeding it)
                    c.RSI = 100 - (100 / (1 + c.RS));
                }
                else if (c.PCC > RSIPeriod1h - 1)
                {
                    double? LastAVGGain1h = Candles1h.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().AVGGain;
                    double? LastAVGLoss1h = Candles1h.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().AVGLoss;
                    double? Gain1h = 0;
                    double? Loss1h = 0;

                    if (c.GainOrLoss > 0)
                    {
                        Gain1h = c.GainOrLoss;
                    }
                    else if (c.GainOrLoss < 0)
                    {
                        Loss1h = c.GainOrLoss * -1;
                    }

                    c.AVGGain = (((LastAVGGain1h * (RSIPeriod1h - 1)) + Gain1h) / RSIPeriod1h);
                    c.AVGLoss = (((LastAVGLoss1h * (RSIPeriod1h - 1)) + Loss1h) / RSIPeriod1h);

                    c.RS = c.AVGGain / c.AVGLoss;
                    c.RSI = 100 - (100 / (1 + c.RS));
                }
                if (c.AVGGain != null) { c.AVGGain = Math.Round(Convert.ToDouble(c.AVGGain), 4); }
                if (c.AVGLoss != null) { c.AVGLoss = Math.Round(Convert.ToDouble(c.AVGLoss), 4); }
                if (c.RSI != null) { c.RSI = Math.Round(Convert.ToDouble(c.RSI), 4); }
                if (c.RS != null) { c.RS = Math.Round(Convert.ToDouble(c.RS), 4); }
                #endregion RSI

                #region StochRSI

                // For STOCH
                if (c.PCC >= STOCHLookbackPeriod1h - 1)
                {
                    double? HighInLookback1h = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(STOCHLookbackPeriod1h).Max(a => a.High);
                    double? LowInLookback1h = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(STOCHLookbackPeriod1h).Min(a => a.Low);

                    c.STOCHK = ((c.Close - LowInLookback1h) / (HighInLookback1h - LowInLookback1h)) * 100;
                }
                if (c.PCC >= STOCHLookbackPeriod1h - 1 + STOCHDPeriod1h) // difference of -1 and 2 is 3, to allow for the 3 period SMA required for STOCH
                {
                    c.STOCHD = Candles1h.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(STOCHDPeriod1h).Average(a => a.STOCHK);
                }

                if (c.STOCHK != null) { c.STOCHK = Math.Round(Convert.ToDouble(c.STOCHK), 4); }
                if (c.STOCHD != null) { c.STOCHD = Math.Round(Convert.ToDouble(c.STOCHD), 4); }
                #endregion StochRSI

            }

            Candles1h = Candles1h.OrderByDescending(a => a.TimeStamp).ToList();

            // Show Candles
            dgvCandles1h.DataSource = Candles1h;

            //dgvCandles1h.Columns["MA1"].Visible = false;
            //dgvCandles1h.Columns["MA2"].Visible = false;
            dgvCandles1h.Columns["EMA1"].Visible = false;
            dgvCandles1h.Columns["EMA2"].Visible = false;
            dgvCandles1h.Columns["EMA3"].Visible = false;
            dgvCandles1h.Columns["ATRTrailingStop"].Visible = false;
            dgvCandles1h.Columns["ATRTrailingStopPOS"].Visible = false;
            ////  dgvCandles.Columns["MACDLine"].Visible = false;
            ////  dgvCandles.Columns["MACDSignalLine"].Visible = false;
            dgvCandles1h.Columns["STOCHK"].Visible = false;
            dgvCandles1h.Columns["STOCHD"].Visible = false;
            dgvCandles1h.Columns["TR"].Visible = false;
            dgvCandles1h.Columns["ATR1"].Visible = false;
            dgvCandles1h.Columns["ATR2"].Visible = false;
            dgvCandles1h.Columns["RS"].Visible = false;
            dgvCandles1h.Columns["AVGGain"].Visible = false;
            dgvCandles1h.Columns["AVGLoss"].Visible = false;
            dgvCandles1h.Columns["GainOrLoss"].Visible = false;


            #endregion ORIGINAL CANDLES



            

        }

        private void UpdateCandles1d()
        {
            DayCandleFiratTime = false;

            #region ORIGINAL CANDLES
            // Get Candles

            //if (CandlesFirstTime == false)
            //{
            Candles1d = bitmex.GetCandleHistory1d(ActiveInstrument.Symbol, 500, "1d");
            //}




            Candles1d = Candles1d.OrderBy(a => a.TimeStamp).ToList();



            // For TD Sequential
            int TimeFrameTDSeq = 0;
            string UpOrDown1d = "Down";
            int UpValue1d = 1;
            int DownValue1d = 1;

            //  Set indicator info
            foreach (Candle1d c in Candles1d)
            {
                c.PCC = Candles1d.Where(a => a.TimeStamp < c.TimeStamp).Count();

                #region TDSeq

                if (c.PCC >= 4)
                {

                    double? FourCandlesBefore1d = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(TimeFrameTDSeq).Close;
                    if (FourCandlesBefore1d < c.Close)
                    {
                        UpOrDown1d = "Up";
                        DownValue1d = 1;
                        c.TDSeq = UpValue1d;
                        c.TDUoD = UpOrDown1d;
                        UpValue1d++;
                    }
                    else if (FourCandlesBefore1d > c.Close)
                    {
                        UpOrDown1d = "Down";
                        UpValue1d = 1;
                        c.TDSeq = DownValue1d;
                        c.TDUoD = UpOrDown1d;
                        DownValue1d++;
                    }
                    else if (FourCandlesBefore1d == c.Close)
                    {
                        UpValue1d = 1;
                        DownValue1d = 1;
                        c.TDUoD = "Equal";
                        c.TDSeq = 0;
                    }

                    TimeFrameTDSeq = TimeFrameTDSeq + 1;
                }

                #endregion TDSeq



                int MA1Period1d = Convert.ToInt32(nudMA1.Value);
                int MA2Period1d = Convert.ToInt32(nudMA2.Value);

                if (c.PCC >= MA1Period1d)
                {
                    // Get the moving average over the last x periods using closing ** Includes current candle **
                    c.MA1 = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MA1Period1d).Average(a => a.Close);
                    // With not enough candles, we don't set to 0, we leave it null
                    if (c.MA1 != null) { c.MA1 = Math.Round(Convert.ToDouble(c.MA1), 4); }
                }

                if (c.PCC >= MA2Period1d)
                {
                    // Get the moving average over the last x periods using closing ** Includes current candle **
                    c.MA2 = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MA2Period1d).Average(a => a.Close);
                    // With not enough candles, we don't set to 0, we leave it null
                    if (c.MA2 != null) { c.MA2 = Math.Round(Convert.ToDouble(c.MA2), 4); }
                }

                if (c.PCC >= BBLength1d)
                {
                    // BBMiddle is just a 20 period moving average
                    c.BBMiddle = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength1d).Average(a => a.Close);

                    // Calcualting Standard Deviation
                    double total_squared1d = 0;
                    double total_for_average1d = Convert.ToDouble(Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength1d).Sum(a => a.Close));
                    foreach (Candle1d cb in Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(BBLength1d).ToList())
                    {
                        total_squared1d += Math.Pow(Convert.ToDouble(cb.Close), 2);
                    }
                    double stdev1d = Math.Sqrt((total_squared1d - (Math.Pow(total_for_average1d, 2) / BBLength1d)) / BBLength1d);
                    c.BBUpper = c.BBMiddle + (stdev1d * BBMultiplier1d);
                    c.BBLower = c.BBMiddle - (stdev1d * BBMultiplier1d);

                    if (c.BBMiddle != null) { c.BBMiddle = Math.Round(Convert.ToDouble(c.BBMiddle), 4); }
                    if (c.BBUpper != null) { c.BBUpper = Math.Round(Convert.ToDouble(c.BBUpper), 4); }
                    if (c.BBLower != null) { c.BBLower = Math.Round(Convert.ToDouble(c.BBLower), 4); }
                }

                if (c.PCC >= EMA1Period1d)
                {
                    double p11d = EMA1Period1d + 1;
                    double EMAMultiplier1d = Convert.ToDouble(2 / p11d);

                    if (c.PCC == EMA1Period1d)
                    {
                        // This is our seed EMA, using SMA of EMA1 period for EMA 1
                        c.EMA1 = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA1Period1d).Average(a => a.Close);
                    }
                    else
                    {
                        double? LastEMA1d = Candles1d.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA1;
                        c.EMA1 = ((c.Close - LastEMA1d) * EMAMultiplier1d) + LastEMA1d;
                    }
                    if (c.EMA1 != null) { c.EMA1 = Math.Round(Convert.ToDouble(c.EMA1), 4); }
                }

                if (c.PCC >= EMA2Period1d)
                {
                    double p11d = EMA2Period1d + 1;
                    double EMAMultiplier1d = Convert.ToDouble(2 / p11d);

                    if (c.PCC == EMA2Period1d)
                    {
                        // This is our seed EMA, using SMA
                        c.EMA2 = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA2Period1d).Average(a => a.Close);
                    }
                    else
                    {
                        double? LastEMA1d = Candles1d.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA2;
                        c.EMA2 = ((c.Close - LastEMA1d) * EMAMultiplier1d) + LastEMA1d;
                    }
                    if (c.EMA2 != null) { c.EMA2 = Math.Round(Convert.ToDouble(c.EMA2), 4); }
                }

                if (c.PCC >= EMA3Period1d)
                {
                    double p11d = EMA3Period1d + 1;
                    double EMAMultiplier1d = Convert.ToDouble(2 / p11d);

                    if (c.PCC == EMA3Period1d)
                    {
                        // This is our seed EMA, using SMA
                        c.EMA3 = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(EMA3Period1d).Average(a => a.Close);
                    }
                    else
                    {
                        double? LastEMA1d = Candles1d.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().EMA3;
                        c.EMA3 = ((c.Close - LastEMA1d) * EMAMultiplier1d) + LastEMA1d;
                    }
                    if (c.EMA3 != null) { c.EMA3 = Math.Round(Convert.ToDouble(c.EMA3), 4); }
                }

                // MACD
                // We can only do this if we have the longest EMA period, EMA1
                if (c.PCC >= EMA1Period1d)
                {

                    double p11d = MACDEMAPeriod1d + 1;
                    double MACDEMAMultiplier1d = Convert.ToDouble(2 / p11d);

                    c.MACDLine = (c.EMA2 - c.EMA1); // default is 12EMA - 26EMA
                    if (c.PCC == EMA1Period1d + MACDEMAPeriod1d)
                    {
                        // Set this to SMA of MACDLine to seed it
                        c.MACDSignalLine = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MACDEMAPeriod1d).Average(a => (a.MACDLine));
                    }
                    else if (c.PCC > EMA1Period1d + MACDEMAPeriod1d)
                    {
                        // We can calculate this EMA based off past candle EMAs
                        double? LastMACDSignalLine = Candles1d.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().MACDSignalLine;
                        c.MACDSignalLine = ((c.MACDLine - LastMACDSignalLine) * MACDEMAMultiplier1d) + LastMACDSignalLine;
                    }
                    c.MACDHistorgram = c.MACDLine - c.MACDSignalLine;

                    if (c.MACDSignalLine != null) { c.MACDSignalLine = Math.Round(Convert.ToDouble(c.MACDSignalLine), 4); }
                    if (c.MACDLine != null) { c.MACDLine = Math.Round(Convert.ToDouble(c.MACDLine), 4); }
                    if (c.MACDHistorgram != null) { c.MACDHistorgram = Math.Round(Convert.ToDouble(c.MACDHistorgram), 4); }

                }

                #region ATR

                ATR1Period = Convert.ToInt32(nudATRPeriod.Value);
                // ATR, setting TR
                if (c.PCC == 0)
                {
                    c.SetTR(c.High);
                }
                else if (c.PCC > 0)
                {
                    c.SetTR(Candles1d.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().Close);
                }

                // Setting ATRs
                if (c.PCC == ATR1Period1d - 1)
                {
                    c.ATR1 = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(ATR1Period1d).Average(a => a.TR);
                }
                else if (c.PCC > ATR1Period1d - 1)
                {
                    double p11d = ATR1Period1d + 1;
                    double ATR1Multiplier1d = Convert.ToDouble(2 / p11d);
                    double? LastATR1 = Candles1d.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().ATR1;
                    c.ATR1 = ((c.TR - LastATR1) * ATR1Multiplier1d) + LastATR1;
                }


                if (c.PCC == ATR2Period1d - 1)
                {
                    c.ATR2 = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(ATR2Period1d).Average(a => a.TR);
                }
                else if (c.PCC > ATR2Period1d - 1)
                {
                    double p11d = ATR2Period1d + 1;
                    double ATR2Multiplier1d = Convert.ToDouble(2 / p11d);
                    double? LastATR2 = Candles1d.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().ATR2;
                    c.ATR2 = ((c.TR - LastATR2) * ATR2Multiplier1d) + LastATR2;
                }
                if (c.TR != null) { c.TR = Math.Round(Convert.ToDouble(c.TR), 4); }
                if (c.ATR1 != null) { c.ATR1 = Math.Round(Convert.ToDouble(c.ATR1), 4); }
                if (c.ATR2 != null) { c.ATR2 = Math.Round(Convert.ToDouble(c.ATR2), 4); }
                #endregion ATR

                #region ATR Trailing Stop

                ATRMultip = Convert.ToDouble(nudATRMultiplier.Value);

                if (c.PCC == ATR1Period - 1)
                {
                    double NLoss1d = Convert.ToDouble(c.ATR1) * ATRMultip;

                    if (c.Close > 0 && Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close > 0)
                    {
                        c.ATRTrailingStop = Math.Max(0, Convert.ToDouble(c.Close) - NLoss1d);
                    }
                    else if (c.Close < 0 && Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < 0)
                    {
                        c.ATRTrailingStop = Math.Min(0, Convert.ToDouble(c.Close) + NLoss1d);
                    }
                    else if (c.Close > 0)
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) - NLoss1d;
                    }
                    else
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) + NLoss1d;
                    }

                    if (Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < 0 && c.Close > 0)
                    {
                        c.ATRTrailingStopPOS = 1;
                    }
                    else if (Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close > 0 && c.Close < 0)
                    {
                        c.ATRTrailingStopPOS = -1;
                    }
                    else
                    {
                        c.ATRTrailingStopPOS = 0;
                    }

                    if (c.ATRTrailingStopPOS == -1)
                    {
                        c.ATRTS = "Down";
                    }
                    else if (c.ATRTrailingStopPOS == 1)
                    {
                        c.ATRTS = "Up";
                    }
                    else
                    {
                        c.ATRTS = "Blue";
                    }

                }
                else if (c.PCC > ATR1Period - 1)
                {
                    double NLoss1d = Convert.ToDouble(c.ATR1) * ATRMultip;

                    if (c.Close > Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close > Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStop = Math.Max(Convert.ToDouble(Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop), Convert.ToDouble(c.Close) - NLoss1d);
                    }
                    else if (c.Close < Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStop = Math.Min(Convert.ToDouble(Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop), Convert.ToDouble(c.Close) + NLoss1d);
                    }
                    else if (c.Close > Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) - NLoss1d;
                    }
                    else
                    {
                        c.ATRTrailingStop = Convert.ToDouble(c.Close) + NLoss1d;
                    }



                    if (Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close < Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && c.Close > Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStopPOS = 1;
                    }
                    else if (Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).Close > Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop && c.Close < Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStop)
                    {
                        c.ATRTrailingStopPOS = -1;
                    }
                    else
                    {
                        c.ATRTrailingStopPOS = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).ElementAtOrDefault(c.PCC - 1).ATRTrailingStopPOS;
                    }



                    if (c.ATRTrailingStopPOS == -1)
                    {
                        c.ATRTS = "Down";
                    }
                    else if (c.ATRTrailingStopPOS == 1)
                    {
                        c.ATRTS = "Up";
                    }
                    else
                    {
                        c.ATRTS = "Blue";
                    }

                }
                #endregion ATR Trailing Stop



                #region RSI
                // For RSI
                if (c.PCC == RSIPeriod1d - 1)
                {
                    // AVG Gain is average of just gains, for all periods, (14), not just periods with gains.  Same goes for losses but with losses.
                    c.AVGGain = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Where(a => a.GainOrLoss > 0).Take(RSIPeriod1d).Sum(a => a.GainOrLoss) / RSIPeriod1d;
                    c.AVGLoss = (Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Where(a => a.GainOrLoss < 0).Take(RSIPeriod1d).Sum(a => a.GainOrLoss) / RSIPeriod1d) * -1;

                    c.RS = c.AVGGain / c.AVGLoss; // Only like this on first one (seeding it)
                    c.RSI = 100 - (100 / (1 + c.RS));
                }
                else if (c.PCC > RSIPeriod1d - 1)
                {
                    double? LastAVGGain = Candles1d.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().AVGGain;
                    double? LastAVGLoss = Candles1d.Where(a => a.TimeStamp < c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(1).FirstOrDefault().AVGLoss;
                    double? Gain1d = 0;
                    double? Loss1d = 0;

                    if (c.GainOrLoss > 0)
                    {
                        Gain1d = c.GainOrLoss;
                    }
                    else if (c.GainOrLoss < 0)
                    {
                        Loss1d = c.GainOrLoss * -1;
                    }

                    c.AVGGain = (((LastAVGGain * (RSIPeriod1d - 1)) + Gain1d) / RSIPeriod1d);
                    c.AVGLoss = (((LastAVGLoss * (RSIPeriod1d - 1)) + Loss1d) / RSIPeriod1d);

                    c.RS = c.AVGGain / c.AVGLoss;
                    c.RSI = 100 - (100 / (1 + c.RS));
                }
                if (c.AVGGain != null) { c.AVGGain = Math.Round(Convert.ToDouble(c.AVGGain), 4); }
                if (c.AVGLoss != null) { c.AVGLoss = Math.Round(Convert.ToDouble(c.AVGLoss), 4); }
                if (c.RSI != null) { c.RSI = Math.Round(Convert.ToDouble(c.RSI), 4); }
                if (c.RS != null) { c.RS = Math.Round(Convert.ToDouble(c.RS), 4); }
                #endregion RSI

                #region StochRSI

                // For STOCH
                if (c.PCC >= STOCHLookbackPeriod1d - 1)
                {
                    double? HighInLookback1d = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(STOCHLookbackPeriod1d).Max(a => a.High);
                    double? LowInLookback1d = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(STOCHLookbackPeriod1d).Min(a => a.Low);

                    c.STOCHK = ((c.Close - LowInLookback1d) / (HighInLookback1d - LowInLookback1d)) * 100;
                }
                if (c.PCC >= STOCHLookbackPeriod1d - 1 + STOCHDPeriod1d) // difference of -1 and 2 is 3, to allow for the 3 period SMA required for STOCH
                {
                    c.STOCHD = Candles1d.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(STOCHDPeriod1d).Average(a => a.STOCHK);
                }

                if (c.STOCHK != null) { c.STOCHK = Math.Round(Convert.ToDouble(c.STOCHK), 4); }
                if (c.STOCHD != null) { c.STOCHD = Math.Round(Convert.ToDouble(c.STOCHD), 4); }
                #endregion StochRSI

            }

            Candles1d = Candles1d.OrderByDescending(a => a.TimeStamp).ToList();

            // Show Candles
            dgvCandles1d.DataSource = Candles1d;

            dgvCandles1d.Columns["MA1"].Visible = false;
            dgvCandles1d.Columns["MA2"].Visible = false;
            dgvCandles1d.Columns["EMA1"].Visible = false;
            dgvCandles1d.Columns["EMA2"].Visible = false;
            dgvCandles1d.Columns["EMA3"].Visible = false;
            dgvCandles1h.Columns["ATRTrailingStop"].Visible = false;
            dgvCandles1h.Columns["ATRTrailingStopPOS"].Visible = false;
            ////  dgvCandles.Columns["MACDLine"].Visible = false;
            ////  dgvCandles.Columns["MACDSignalLine"].Visible = false;
            dgvCandles1d.Columns["STOCHK"].Visible = false;
            dgvCandles1d.Columns["STOCHD"].Visible = false;
            dgvCandles1d.Columns["TR"].Visible = false;
            dgvCandles1d.Columns["ATR1"].Visible = false;
            dgvCandles1d.Columns["ATR2"].Visible = false;
            dgvCandles1d.Columns["RS"].Visible = false;
            dgvCandles1d.Columns["AVGGain"].Visible = false;
            dgvCandles1d.Columns["AVGLoss"].Visible = false;
            dgvCandles1d.Columns["GainOrLoss"].Visible = false;


            #endregion ORIGINAL CANDLES

            

            

        }

        private void tmrCandleUpdaterhd_Tick(object sender, EventArgs e)
        {
            if (chkUpdateCandles.Checked)
            {
                UpdateCandles1h();
                UpdateCandles1d();
            }
        }

        private void ddlStrategyType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SymbolPosition.IsOpen == true && SymbolPosition.CurrentQty > 0)
            {
                TrailingProfitStartPrice = 1000000;
                TrailingProfitExecutePrice = 999999;
            }

            if (SymbolPosition.IsOpen == true && SymbolPosition.CurrentQty < 0)
            {
                TrailingProfitStartPrice = 1;
                TrailingProfitExecutePrice = 2;
            }
            txtTPStart.Text = TrailingProfitStartPrice.ToString();
            txtTPExecute.Text = TrailingProfitExecutePrice.ToString();

            if (ddlStrategyType.SelectedIndex == 1)
            {
                TPTimerLimit = 150;
                txtTPTimer.Text = "TPTimer: " + TPTimerLimit.ToString();
            }


            if (ddlStrategyType.SelectedIndex == 0 && (SymbolOrder.OrdStatus == "New" || SymbolOrder.OrdStatus == "PartiallyFilled") && NotStopLoss == true)
            {
                bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
            }
            if(ddlStrategyType.SelectedIndex == 1 && (SymbolOrder.OrdStatus == "New" || SymbolOrder.OrdStatus == "PartiallyFilled") && NotStopLoss == true)
            {
                bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
            }
            if (ddlStrategyType.SelectedIndex == 2 && (SymbolOrder.OrdStatus == "New" || SymbolOrder.OrdStatus == "PartiallyFilled") && NotStopLoss == true)
            {
                bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
            }
        }

        private void nudStartTrailingProfit_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkManualControl_CheckedChanged(object sender, EventArgs e)
        {
            bool OpenOrdercheckmc = false;

            if (SymbolOrder.OrdStatus == "New" || SymbolOrder.OrdStatus == "PartiallyFilled")
            {
                OpenOrdercheckmc = true;
            }
            else
            {
                OpenOrdercheckmc = false;
            }

            if (SymbolPosition.IsOpen == false && OpenOrdercheckmc == true)
            {
                bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
            }
        }

        private void nudATRPeriod_ValueChanged(object sender, EventArgs e)
        {
            UpdateCandles1d();
            UpdateCandles1h();
            UpdateCandles();
        }

        private void nudATRMultiplier_ValueChanged(object sender, EventArgs e)
        {
            UpdateCandles1d();
            UpdateCandles1h();
            UpdateCandles();
        }

        private void chkDCA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDCA.Checked == true)
            {
                btnAutomatedTrading.Enabled = false;
                ddlStrategyType.Enabled = false;
                rdoBuy.Enabled = false;
                rdoSell.Enabled = false;
                rdoSwitch.Enabled = false;
                chkManualControl.Enabled = false;
                nudPriceChange.Enabled = false;
                nupRSIDifferenceThree.Enabled = false;
                chkStopLoss.Enabled = false;
                nudStartStopLoss.Enabled = false;
                nudExecuteStopLoss.Enabled = false;
                nudPercentEarn.Enabled = false;
                nupRSIDifference.Enabled = false;
                nudStartTrailingProfit.Enabled = false;
                nudExecuteTrailingProfit.Enabled = false;
                chkManualControl.Enabled = false;
                nudMA1.Enabled = false;
                nudMA2.Enabled = false;
                nudATRPeriod.Enabled = false;
                nudATRMultiplier.Enabled = false;
                ddlAutoOrderType.Enabled = false;
                btnBuy.Enabled = false;
                btnSell.Enabled = false;
                btnDCA.Enabled = true;
                chkStrategyThreeShort.Enabled = false;
                chkStrategyThreeLong.Enabled = false;
            }
            else
            {
                btnAutomatedTrading.Enabled = true;
                ddlStrategyType.Enabled = true;
                rdoBuy.Enabled = true;
                rdoSell.Enabled = true;
                rdoSwitch.Enabled = true;
                chkManualControl.Enabled = true;
                nudPriceChange.Enabled = true;
                nupRSIDifferenceThree.Enabled = true;
                chkStopLoss.Enabled = true;
                nudStartStopLoss.Enabled = true;
                nudExecuteStopLoss.Enabled = true;
                nudPercentEarn.Enabled = true;
                nupRSIDifference.Enabled = true;
                nudStartTrailingProfit.Enabled = true;
                nudExecuteTrailingProfit.Enabled = true;
                chkManualControl.Enabled = true;
                nudMA1.Enabled = true;
                nudMA2.Enabled = true;
                nudATRPeriod.Enabled = true;
                nudATRMultiplier.Enabled = true;
                ddlAutoOrderType.Enabled = true;
                btnBuy.Enabled = true;
                btnSell.Enabled = true;
                btnDCA.Enabled = false;
                chkStrategyThreeShort.Enabled = true;
                chkStrategyThreeLong.Enabled = true;
            }
        }

        
        private void chkAutoReOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoReOrder.Checked == false)
            {
                DCAAutoReOrderSec = Convert.ToInt32(nudAutoReOrderTime.Value);
            }
        }

        private void btnDCA_Click(object sender, EventArgs e)
        {
            if (btnDCA.Text == "DCA")
            {
                btnDCA.Text = "DCA - Stop";
                btnDCA.BackColor = Color.Red;
                DCARunning = true;
                ddlDCA.Enabled = false;
                nudPercentToTrade.Enabled = false;
                chkDCA.Enabled = false;
                DCAAutoReOrderSec = Convert.ToInt32(nudAutoReOrderTime.Value);

            }
            else
            {

                btnDCA.Text = "DCA";
                btnDCA.BackColor = Color.LightGreen;
                DCARunning = false;
                nudPercentToTrade.Enabled = true;
                chkDCA.Enabled = true;
                ddlDCA.Enabled = true;

            }
        }

        private void nudMA1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
