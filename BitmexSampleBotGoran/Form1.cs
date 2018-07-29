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

namespace BitmexSampleBotGoran
{
    public partial class Form1 : Form
    {

        private static string TestbitmexKey = "test";
        private static string TestbitmexSecret = "test";
        private static string TestbitmexDomain = "https://testnet.bitmex.com";

        private static string bitmexKey = "test";
        private static string bitmexSecret = "test";
        private static string bitmexDomain = "https://www.bitmex.com";


        BitMEXApi bitmex;
        List<OrderBook> CurrentBook = new List<OrderBook>();
        List<Instrument> ActiveInstruments = new List<Instrument>();
        Instrument ActiveInstrument = new Instrument();
        List<Candle> Candles = new List<Candle>();

        bool Running = false;
        string Mode = "Wait";
        List<Position> OpenPositions = new List<Position>();
        List<Order> OpenOrders = new List<Order>();

        //WebSocket ws;
        //Dictionary<string, decimal> Prices = new Dictionary<string, decimal>();

        public Form1()
        {
            InitializeComponent();
            InitializeDropdowns();            
            InitializeAPI();
            InitializeCandleArea();            

            //InitializeWebSocket();
        }

        private void InitializeDropdowns()
        {
            ddNetwork.SelectedIndex = 0;
            ddOrderType.SelectedIndex = 0;
            ddlCandleTimes.SelectedIndex = 0;
            ddlAutoOrderType.SelectedIndex = 0;
        }

        private void InitializeCandleArea ()
        {
            tmrCandleUpdater.Start();
        }

        private void InitializeAPI()
        {
            switch(ddNetwork.SelectedItem.ToString())
            {
                case "TestNet":
                    bitmex = new BitMEXApi(TestbitmexKey, TestbitmexSecret, TestbitmexDomain);
                    break;
                case "RealNet":
                    bitmex = new BitMEXApi(bitmexKey, bitmexSecret, bitmexDomain);
                    break;
            }            
            // We must do this in case symbols are different on test and real net
            InitializeSymbolInformation();
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

        //private void InitializeWebSocket ()
        //{
        //    switch (ddNetwork.SelectedItem.ToString())
        //    {
        //        case "TestNet":
        //            ws = new WebSocket("wss://testnet.bitmex.com/realtime");
        //            break;
        //        case "RealNet":
        //            ws = new WebSocket("wss://www.bitmex.com/realtime");
        //            break;
        //    }
        //    ws.OnMessage += (sender, e) =>
        //    {
        //        try
        //        {
        //            JObject Message = JObject.Parse(e.Data);
        //            if (Message.ContainsKey("table"))
        //            {
        //                if ((string)Message["table"] == "trade")
        //                {
        //                    if (Message.ContainsKey("data"))
        //                    {
        //                        JArray TD = (JArray)Message["data"];
        //                        if (TD.Any())
        //                        {
        //                            decimal Price = (decimal)TD.Children().LastOrDefault()["price"];
        //                            string Symbol = (string)TD.Children().LastOrDefault()["symbol"];
        //                            Prices[Symbol] = Price;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    };

        //    ws.Connect();
        //    // Assamble our price dictionary
        //    foreach (Instrument i in ActiveInstruments)
        //    {
        //        ws.Send("{\"op\": \"subscribe\", \"args\": [\"trade:" + i.Symbol + "\"]}");
        //    }
        //}

        private double CalculateMarketOrderPrice(string Side)
        {
            CurrentBook = bitmex.GetOrderBook(ActiveInstrument.Symbol, 1);

            double SellPrice = CurrentBook.Where(a => a.Side == "Sell").FirstOrDefault().Price;
            double BuyPrice = CurrentBook.Where(a => a.Side == "Buy").FirstOrDefault().Price;

            double OrderPrice = 0;

            switch (Side)
            {
                case "Buy":
                    OrderPrice = BuyPrice;

                    if (BuyPrice + Convert.ToDouble(ActiveInstrument.TickSize) >= SellPrice)
                    {
                        OrderPrice = BuyPrice;
                    }
                    else if (BuyPrice + Convert.ToDouble(ActiveInstrument.TickSize) < SellPrice)
                    {
                        OrderPrice = BuyPrice + Convert.ToDouble(ActiveInstrument.TickSize);
                    }
                    break;
                case "Sell":
                    OrderPrice = SellPrice;

                    if (SellPrice - Convert.ToDouble(ActiveInstrument.TickSize) <= BuyPrice)
                    {
                        OrderPrice = SellPrice;
                    }
                    else if (SellPrice - Convert.ToDouble(ActiveInstrument.TickSize) > BuyPrice)
                    {
                        OrderPrice = SellPrice - Convert.ToDouble(ActiveInstrument.TickSize);
                    }
                    break;
            }
            return OrderPrice;

        }

        private void MakeOrder(string Side, int Qty, double Price = 0)
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

        private void AutoMakeOrder(string Side, int Qty, double Price = 0)
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
            InitializeAPI();
            //InitializeWebSocket();
        }

        private void ddlSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveInstrument = bitmex.GetInstrument(((Instrument)ddlSymbol.SelectedItem).Symbol)[0];
        }

        private void UpdateCandles ()
        {
            // Get Candles
            Candles = bitmex.GetCandleHistory(ActiveInstrument.Symbol, 100, ddlCandleTimes.SelectedItem.ToString());

            //  Set indicator info
            foreach (Candle c in Candles)
            {
                c.PCC = Candles.Where(a => a.TimeStamp < c.TimeStamp).Count();

                int MA1Period = Convert.ToInt32(nudMA1.Value);
                int MA2Period = Convert.ToInt32(nudMA2.Value);

                if (c.PCC > MA1Period)
                {
                    // Get the moving average over the last x periods using closing ** Includes current candle **
                    c.MA1 = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MA1Period).Average(a => a.Close);
                    // With not enough candles, we don't set to 0, we leave it null
                }

                if (c.PCC > MA2Period)
                {
                    // Get the moving average over the last x periods using closing ** Includes current candle **
                    c.MA2 = Candles.Where(a => a.TimeStamp <= c.TimeStamp).OrderByDescending(a => a.TimeStamp).Take(MA2Period).Average(a => a.Close);
                    // With not enough candles, we don't set to 0, we leave it null
                }
            }

            // Show Candles
            dgvCandles.DataSource = Candles;

            // Determin the bot Mode based on MAs, trades happen or another timer
            if(Running) // We could set this up to also ignoer setting bot mode if we've already reviewed current candles
                        // However, if you wanted to use info from most current candle, that wouldn't work well
            {
                SetBotMode(); // We only need to set bot mode if bot is running
                btnAutomatedTrading.Text = "Stop - " + Mode; // So we can see what the mode of the bot is while running
            }

        }

        private void SetBotMode ()
        {
            // This is where we determine what mode bot is in
            if(rdoBuy.Checked)
            {
                if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 <= Candles[2].MA2)) // Most recent closed candle crossed over up
                {
                    // Did the last full candle have MA1 cross above MA2?  We'll need to buy now
                    Mode = "Buy";
                }
                else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 >= Candles[2].MA2))
                {
                    // Did the last full candle have MA1 cross below MA2?  We'll need to close any open position.
                    Mode = "CloseAndWait";
                }
                else if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 > Candles[2].MA2))
                {
                    // If no crossover, is MA1 still above MA2?  We'll need to leave our position open.
                    Mode = "Wait";
                }
                else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 < Candles[2].MA2))
                {
                    // If no crossover, is MA1 still below MA2?  We'll need to make sure we don't have a position open.
                    Mode = "CloseAndWait";
                }
            }
            else if(rdoSell.Checked)
            {
                if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 <= Candles[2].MA2)) // Most recent closed candle crossed over up
                {
                    // Did the last full candle have MA1 cross above MA2?  We'll need to close any open position.
                    Mode = "CloseAndWait";
                }
                else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 >= Candles[2].MA2))
                {
                    // Did the last full candle have MA1 cross below MA2?  We'll need to sell now
                    Mode = "Sell";
                }
                else if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 > Candles[2].MA2))
                {
                    // If no crossover, is MA1 still above MA2?  We'll need to make sure we don't have a position open.
                    Mode = "CloseAndWait";
                }
                else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 < Candles[2].MA2))
                {
                    // If no crossover, is MA1 still below MA2?  We'll need to leave our position open.
                    Mode = "Wait";
                }
            }
            else if(rdoSwitch.Checked)
            {
                if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 <= Candles[2].MA2)) // Most recent closed candle crossed over up
                {
                    // Did the last full candle have MA1 cross above MA2?  Triggers a buy in switch setting.
                    Mode = "Buy";
                }
                else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 >= Candles[2].MA2))
                {
                    // Did the last full candle have MA1 cross below MA2?  Triggers a sell in switch setting.
                    Mode = "Sell";
                }
                else if ((Candles[1].MA1 > Candles[1].MA2) && (Candles[2].MA1 > Candles[2].MA2))
                {
                    // If no crossover, is MA1 still above MA2?  Keep long positions open, close any shorts if they are still open.
                    Mode = "CloseShortsAndWait";
                }
                else if ((Candles[1].MA1 < Candles[1].MA2) && (Candles[2].MA1 < Candles[2].MA2))
                {
                    // If no crossover, is MA1 still below MA2?  Keep short positions open, close any longs if they are still open.
                    Mode = "CloseLongsAndWait";
                }
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
            }
            else
            {
                tmrCandleUpdater.Stop();
            }
        }

        private void ddlCandleTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCandles();
        }

        private void btnAutomatedTrading_Click(object sender, EventArgs e)
        {
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
                rdoSwitch.Enabled = true;
            }
        }

        private void tmrAutotradeExecution_Tick(object sender, EventArgs e)
        {
            OpenPositions = bitmex.GetOpenPositions(ActiveInstrument.Symbol);
            OpenOrders = bitmex.GetOpenOrders(ActiveInstrument.Symbol);

            if (rdoBuy.Checked)
            {
                switch (Mode)
                {
                    case "Buy":
                        // See if already have a position open
                        if (OpenPositions.Any())
                        {
                            // We have an open position, is it at our desired quanity?
                            if (OpenPositions[0].CurrentQty < nudAutoQuantity.Value)
                            {
                                // If we have an open order, edit it
                                if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // We still have an open buy order, cancel that order, make a new buy order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
                                }
                                else if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
                                }
                            } // No else, it is filled to where we want.
                        }
                        else
                        {
                            if (OpenOrders.Any())
                            {
                                // If we have an open order, edit it
                                if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // We still have an open order, cancel that order, make a new buy order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
                                }
                                else if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
                                }
                            }
                            else
                            {
                                AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
                            }
                        }
                        break;
                    case "CloseAndWait":
                        // See if we have open positions, if so, close them
                        if (OpenPositions.Any())
                        {
                            // Now do we have open orders? If so, we want to make sure they are at the right price
                            if (OpenOrders.Any())
                            {
                                if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // We still have an open buy order, cancel that order, make a new sell order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
                                }
                                else if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
                                }
                            }
                            else
                            {
                                // No open orders, need to make an order to sell
                                AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
                            }
                        }
                        else if (OpenOrders.Any())
                        {
                            // We don't have an open position, but we have an open order, close that order, we don't want to open any 
                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                        }
                        break;
                    case "Wait":
                        // We are still in wait mode, no new buying or selling - close open orders
                        if (OpenOrders.Any())
                        {
                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                        }
                        break;
                }
            }
            else if (rdoSell.Checked)
            {
                switch (Mode)
                {
                    case "Sell":
                        // See if already have a position open
                        if (OpenPositions.Any())
                        {
                            // We have an open position, is it at our desired quanity?
                            if (OpenPositions[0].CurrentQty < nudAutoQuantity.Value)
                            {
                                // If we have an open order, edit it
                                if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // We still have an open buy order, cancel that order, make a new sell order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
                                }
                                else if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
                                }
                            } // No else, it is filled to where we want.
                        }
                        else
                        {
                            if (OpenOrders.Any())
                            {
                                // If we have an open order, edit it
                                if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // We still have an open order, cancel that order, make a new sell order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
                                }
                                else if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
                                }
                            }
                            else
                            {
                                AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));
                            }
                        }
                        break;
                    case "CloseAndWait":
                        // See if we have open positions, if so, close them
                        if (OpenPositions.Any())
                        {
                            // Now do we have open orders? If so, we want to make sure they are at the right price
                            if (OpenOrders.Any())
                            {
                                if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // We still have an open buy order, cancel that order, make a new buy order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
                                }
                                else if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
                                }
                            }
                            else
                            {
                                // No open orders, need to make an order to buy
                                AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
                            }
                        }
                        else if (OpenOrders.Any())
                        {
                            // We don't have an open position, but we have an open order, close that order, we don't want to open any 
                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                        }
                        break;
                    case "Wait":
                        // We are still in wait mode, no new buying or selling - close open orders
                        if (OpenOrders.Any())
                        {
                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                        }
                        break;
                }
            }
            else if (rdoSwitch.Checked)
            {
                switch (Mode)
                {
                    case "Buy":
                        // See if already have a position open
                        if (OpenPositions.Any())
                        {
                            int PositionDifference = Convert.ToInt32(nudAutoQuantity.Value - OpenPositions[0].CurrentQty);

                            if (OpenOrders.Any())
                            {
                                // If we have an open order, edit it.
                                if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // We still have an open sell order, cancel that order, make a new buy order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Buy", PositionDifference);
                                }
                                else if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
                                }
                            }
                            else
                            {
                                // No open orders, make one for the difference
                                if (PositionDifference != 0)
                                {
                                    AutoMakeOrder("Buy", Convert.ToInt32(PositionDifference));
                                }
                            }                            
                        }
                        else
                        {
                            if (OpenOrders.Any())
                            {
                                // If we have an open order, edit it.
                                if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // We still have an open sell order, cancel that order, make a new buy order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
                                }

                                else if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
                                }                                

                            }
                            else
                            {
                                AutoMakeOrder("Buy", Convert.ToInt32(nudAutoQuantity.Value));
                            }

                        }
                        break;
                    case "Sell":

                        if (OpenPositions.Any())
                        {
                            int PositionDifference = Convert.ToInt32(nudAutoQuantity.Value + OpenPositions[0].CurrentQty);

                            if (OpenOrders.Any())
                            {
                                // If we have an open order, edit it.
                                if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // We still have an open buy order, cancel that order, make a new sell order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Sell", PositionDifference);
                                }
                                else if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
                                }
                            }
                            else
                            {
                                // No open orders, make one for the difference
                                if (PositionDifference != 0)
                                {
                                    AutoMakeOrder("Sell", Convert.ToInt32(PositionDifference));
                                }
                            }
                        }
                        else
                        {
                            if (OpenOrders.Any())
                            {
                                // If we have an open order, edit it.
                                if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // We still have an open buy order, cancel that order, make a new sell order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));
                                }
                                else if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
                                }
                            }
                            else
                            {
                                AutoMakeOrder("Sell", Convert.ToInt32(nudAutoQuantity.Value));                                
                            }
                        }
                        break;
                    case "CloseLongsAndWait":   
                        
                        if (OpenPositions.Any())
                        {
                            // Now, do we have any open orders? If so, we want to make sure they are at the right price
                            if (OpenOrders.Any())
                            {                                
                                if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // We still have an open buy order, cancel that order, make a new sell order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
                                }
                                else if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Sell"));
                                }
                            }
                            else if (OpenPositions[0].CurrentQty > 0)
                            {
                                // No open oreders, need to make an order to sell
                                AutoMakeOrder("Sell", Convert.ToInt32(OpenPositions[0].CurrentQty));
                            }
                        }
                        else if (OpenOrders.Any())
                        {
                            // We don't have an open position, but we do have an open order, close that order, we don't want to open any position here.
                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                        }
                        break;
                    case "CloseShortsAndWait":

                        // Close any open orders, close any open shorts, we've missed our chance to long.
                        if (OpenPositions.Any())
                        {
                            //Now, do we have any open orders? If so, we want to make sure they are at the right price
                            if (OpenOrders.Any())
                            {
                                if (OpenOrders.Any(a => a.Side == "Sell"))
                                {
                                    // We still have an open sell order, cancel that order, make a new buy order
                                    string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                                    AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
                                }
                                else if (OpenOrders.Any(a => a.Side == "Buy"))
                                {
                                    // Edit our only open order, code should not allow for more than 1 at a time for now
                                    string result = bitmex.EditOrderPrice(OpenOrders[0].OrderId, CalculateMarketOrderPrice("Buy"));
                                }
                            }
                            else if (OpenPositions[0].CurrentQty < 0)
                            {
                                // No open oreders, need to make an order to buy
                                AutoMakeOrder("Buy", Convert.ToInt32(OpenPositions[0].CurrentQty));
                            }
                        }
                        else if (OpenOrders.Any())
                        {
                            // We don't have an open position, but we do have an open order, close that order, we don't want to open any position here.
                            string result = bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                        }
                        break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ws.Close();  // Make sure our WebSocket is closed on exit
        }

        //private void UpdatePrice()
        //{
        //    nudCurrentPrice.Value = Prices[ActiveInstrument.Symbol];
        //}

        private void tmrClientUpdates_Tick(object sender, EventArgs e)
        {
            //UpdatePrice();
        }
    }
}
