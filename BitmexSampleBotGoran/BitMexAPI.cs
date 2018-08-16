//using ServiceStack.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace BitMEX
{
    public class OrderBookItem
    {
        public string Symbol { get; set; }
        public int Level { get; set; }
        public int BidSize { get; set; }
        public decimal BidPrice { get; set; }
        public int AskSize { get; set; }
        public decimal AskPrice { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class BitMEXApi
    {
        private string domain = "https://testnet.bitmex.com";
        private string apiKey;
        private string apiSecret;
        private int rateLimit;
        List<string> errors = new List<string>();

        public BitMEXApi(string bitmexKey = "", string bitmexSecret = "", string bitmexDomain = "", int rateLimit = 5000)
        {
            this.apiKey = bitmexKey;
            this.apiSecret = bitmexSecret;
            this.rateLimit = rateLimit;
            this.domain = bitmexDomain;
        }

        #region API Connector - Don't touch
        private string BuildQueryData(Dictionary<string, string> param)
        {
            if (param == null)
                return "";

            StringBuilder b = new StringBuilder();
            foreach (var item in param)
                b.Append(string.Format("&{0}={1}", item.Key, WebUtility.UrlEncode(item.Value)));

            try { return b.ToString().Substring(1); }
            catch (Exception) { return ""; }
        }

        private string BuildJSON(Dictionary<string, string> param)
        {
            if (param == null)
                return "";

            var entries = new List<string>();
            foreach (var item in param)
                entries.Add(string.Format("\"{0}\":\"{1}\"", item.Key, item.Value));

            return "{" + string.Join(",", entries) + "}";
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private long GetExpires()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 3600; // set expires one hour in the future
        }

        private byte[] hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using (var hash = new HMACSHA256(keyByte))
            {
                return hash.ComputeHash(messageBytes);
            }
        }

        public string GetExpiresArg()
        {
            long timestamp = (long)((DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);

            string expires = (timestamp + 60).ToString();

            return (expires);
        }

        public string GetWebSocketSignatureString(string APISecret, string APIExpires)
        {
            byte[] signatureBytes = hmacsha256(Encoding.UTF8.GetBytes(APISecret), Encoding.UTF8.GetBytes("GET/realtime" + APIExpires));
            string signatureString = ByteArrayToString(signatureBytes);
            return signatureString;
        }

        private string Query(string method, string function, Dictionary<string, string> param = null, bool auth = false, bool json = false)
        {
            string paramData = json ? BuildJSON(param) : BuildQueryData(param);
            string url = "/api/v1" + function + ((method == "GET" && paramData != "") ? "?" + paramData : "");
            string postData = (method != "GET") ? paramData : "";

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(domain + url);
            webRequest.Method = method;

            if (auth)
            {
                string expires = GetExpires().ToString();
                string message = method + url + expires + postData;
                byte[] signatureBytes = hmacsha256(Encoding.UTF8.GetBytes(apiSecret), Encoding.UTF8.GetBytes(message));
                string signatureString = ByteArrayToString(signatureBytes);

                webRequest.Headers.Add("api-expires", expires);
                webRequest.Headers.Add("api-key", apiKey);
                webRequest.Headers.Add("api-signature", signatureString);
            }

            try
            {
                if (postData != "")
                {
                    webRequest.ContentType = json ? "application/json" : "application/x-www-form-urlencoded";
                    var data = Encoding.UTF8.GetBytes(postData);
                    using (var stream = webRequest.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }

                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream str = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(str))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (WebException wex)
            {
                using (HttpWebResponse response = (HttpWebResponse)wex.Response)
                {
                    if (response == null)
                        throw;

                    using (Stream str = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(str))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
        #endregion

        #region Examples from BitMex
        //public List<OrderBookItem> GetOrderBook(string symbol, int depth)
        //{
        //    var param = new Dictionary<string, string>();
        //    param["symbol"] = symbol;
        //    param["depth"] = depth.ToString();
        //    string res = Query("GET", "/orderBook", param);
        //    return JsonSerializer.DeserializeFromString<List<OrderBookItem>>(res);
        //}

        public string GetOrders(string Symbol)
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = Symbol;
            //param["filter"] = "{\"open\":true}";
            //param["columns"] = "";
            //param["count"] = 100.ToString();
            //param["start"] = 0.ToString();
            //param["reverse"] = false.ToString();
            //param["startTime"] = "";
            //param["endTime"] = "";
            return Query("GET", "/order", param, true);
        }

        public string PostOrders()
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = "XBTUSD";
            param["side"] = "Buy";
            param["orderQty"] = "1";
            param["ordType"] = "Market";
            return Query("POST", "/order", param, true);
        }

        public string DeleteOrders()
        {
            var param = new Dictionary<string, string>();
            param["orderID"] = "de709f12-2f24-9a36-b047-ab0ff090f0bb";
            param["text"] = "cancel order by ID";
            return Query("DELETE", "/order", param, true, true);
        }
        #endregion

        #region Our Calls
        public List<OrderBook> GetOrderBook(string symbol, int depth)
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = symbol;
            param["depth"] = depth.ToString();
            string res = Query("GET", "/orderBook/L2", param);
            return JsonConvert.DeserializeObject<List<OrderBook>>(res);

        }

        public string PostOrderPostOnly(string Symbol, string Side, decimal Price, int Quantity)
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = Symbol;
            param["side"] = Side;
            param["orderQty"] = Quantity.ToString();
            param["ordType"] = "Limit";
            param["execInst"] = "ParticipateDoNotInitiate";
            //param["displayQty"] = 0.ToString(); //Show Order as Hidden, keep us from moving price away from our own orders
            param["price"] = Price.ToString().Replace(",", ".");
            //return Query("POST", "/order", param, true);

            string res = Query("POST", "/order", param, true);
            int RetryAttemptCount = 0;
            int MaxRetries = RetryAttempts(res);
            while (res.Contains("error") && RetryAttemptCount < MaxRetries)
            {
                errors.Add(res);
                Thread.Sleep(500); // Force app to wait 500ms
                res = Query("POST", "/order", param, true);
                RetryAttemptCount++;
                if (RetryAttemptCount == MaxRetries)
                {
                    errors.Add("Max rety attempts of " + MaxRetries.ToString() + " reached.");
                    break;
                }
            }
            return res;
        }

        // NEW LIMIT CLOSE OPEN POSITION
        public string LimitCloseOpenPosition(string Symbol, decimal Price)
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = Symbol;
            param["price"] = Price.ToString().Replace(",", ".");
            //return Query("POST", "/order/closePosition", param, true);

            string res = Query("POST", "/order/closePosition", param, true);
            int RetryAttemptCount = 0;
            int MaxRetries = RetryAttempts(res);
            while (res.Contains("error") && RetryAttemptCount < MaxRetries)
            {
                errors.Add(res);
                Thread.Sleep(500); // Force app to wait 500ms
                res = Query("POST", "/order/closePosition", param, true);
                RetryAttemptCount++;
                if (RetryAttemptCount == MaxRetries)
                {
                    errors.Add("Max rety attempts of " + MaxRetries.ToString() + " reached.");
                    break;
                }
            }
            return res;
        }

        public string MarketOrder(string Symbol, string Side, int Quantity)
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = Symbol;
            param["side"] = Side;
            param["orderQty"] = Quantity.ToString();
            param["ordType"] = "Market";
            // return Query("POST", "/order", param, true);

            string res = Query("POST", "/order", param, true);
            int RetryAttemptCount = 0;
            int MaxRetries = RetryAttempts(res);
            while (res.Contains("error") && RetryAttemptCount < MaxRetries)
            {
                errors.Add(res);
                Thread.Sleep(500); // Force app to wait 500ms
                res = Query("POST", "/order", param, true);
                RetryAttemptCount++;
                if (RetryAttemptCount == MaxRetries)
                {
                    errors.Add("Max rety attempts of " + MaxRetries.ToString() + " reached.");
                    break;
                }
            }
            return res;
        }

        public string CancelAllOpenOrders(string symbol, string Note = "")
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = symbol;
            param["text"] = Note;
            //return Query("DELETE", "/order/all", param, true, true);

            string res = Query("DELETE", "/order/all", param, true, true);
            int RetryAttemptCount = 0;
            int MaxRetries = RetryAttempts(res);
            while (res.Contains("error") && RetryAttemptCount < MaxRetries)
            {
                errors.Add(res);
                Thread.Sleep(500); // Force app to wait 500ms
                res = Query("DELETE", "/order/all", param, true, true);
                RetryAttemptCount++;
                if (RetryAttemptCount == MaxRetries)
                {
                    errors.Add("Max rety attempts of " + MaxRetries.ToString() + " reached.");
                    break;
                }
            }
            return res;
        }

        public List<Instrument> GetActiveInstruments()
        {
            string res = Query("GET", "/instrument/active");
            return JsonConvert.DeserializeObject<List<Instrument>>(res);
        }

        public List<Instrument> GetInstrument(string symbol)
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = symbol;
            string res = Query("GET", "/instrument", param);
            return JsonConvert.DeserializeObject<List<Instrument>>(res);
        }

        public List<Candle> GetCandleHistory(string symbol, int count, string size)
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = symbol;
            param["count"] = count.ToString();
            param["reverse"] = true.ToString();
            param["partial"] = false.ToString();
            param["binSize"] = size;
            string res = Query("GET", "/trade/bucketed", param);
            return JsonConvert.DeserializeObject<List<Candle>>(res).OrderByDescending(a => a.TimeStamp).ToList();
        }

        public List<Position> GetOpenPositions(string symbol)
        {
            var param = new Dictionary<string, string>();
            string res = Query("GET", "/position", param, true);
            return JsonConvert.DeserializeObject<List<Position>>(res).Where(a => a.Symbol == symbol && a.IsOpen == true).OrderByDescending(a => a.TimeStamp).ToList();
        }

        public List<Order> GetOpenOrders(string symbol)
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = symbol;
            param["reverse"] = true.ToString();
            string res = Query("GET", "/order", param, true);
            return JsonConvert.DeserializeObject<List<Order>>(res).Where(a => a.OrdStatus == "New" || a.OrdStatus == "PartiallyFilled").OrderByDescending(a => a.TimeStamp).ToList();
        }

        public string EditOrderPrice(string OrderId, decimal Price)
        {
            var param = new Dictionary<string, string>();
            param["orderID"] = OrderId;
            param["price"] = Price.ToString().Replace(",", ".");
            //return Query("PUT", "/order", param, true, true);

            string res = Query("PUT", "/order", param, true, true);
            int RetryAttemptCount = 0;
            int MaxRetries = RetryAttempts(res);
            while (res.Contains("error") && RetryAttemptCount < MaxRetries)
            {
                errors.Add(res);
                Thread.Sleep(500); // Force app to wait 500ms
                res = Query("PUT", "/order", param, true, true);
                RetryAttemptCount++;
                if (RetryAttemptCount == MaxRetries)
                {
                    errors.Add("Max rety attempts of " + MaxRetries.ToString() + " reached.");
                    break;
                }
            }
            return res;
        }
        #endregion

        private int RetryAttempts(string res)
        {
            int att = 0;

            if (res.Contains("Unable to cancel order due to existing state"))
            {
                att = 0;
            }
            else if (res.Contains("The system is currently overloaded. Please try again later."))
            {
                if (BitmexSampleBotGoran.Properties.Settings.Default.OverloadRetry)
                {
                    att = BitmexSampleBotGoran.Properties.Settings.Default.OverloadRetryAttempts;
                }
                else
                {
                    att = 0;
                }
            }
            else if (res.Contains("error"))
            {
                att = 0;
            }

            return att;
        }


        #region RateLimiter

        private long lastTicks = 0;
        private object thisLock = new object();

        private void RateLimit()
        {
            lock (thisLock)
            {
                long elapsedTicks = DateTime.Now.Ticks - lastTicks;
                var timespan = new TimeSpan(elapsedTicks);
                if (timespan.TotalMilliseconds < rateLimit)
                    Thread.Sleep(rateLimit - (int)timespan.TotalMilliseconds);
                lastTicks = DateTime.Now.Ticks;
            }
        }

        #endregion RateLimiter
    }

    // Working Classes
    public class OrderBook
    {
        public string Side { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
    }

    public class Instrument
    {
        public string Symbol { get; set; }
        public decimal TickSize { get; set; }
        public double Volume24H { get; set; }
        public int DecimalPlacesInTickSize
        {
            get { return BitConverter.GetBytes(decimal.GetBits(TickSize)[3])[2]; }
        }
    }

    public class Candle
    {
        public DateTime TimeStamp { get; set; }
        public double? Open { get; set; }
        public double? Close { get; set; }
        public double? High { get; set; }
        public double? Low { get; set; }
        public double? Volume { get; set; }
        public int Trades { get; set; }
        public int PCC { get; set; }  // Previous Candle Count
        public double? MA1 { get; set; }
        public double? MA2 { get; set; }
        public double? BBUpper { get; set; }
        public double? BBMiddle { get; set; }
        public double? BBLower { get; set; }
        public double? EMA1 { get; set; }
        public double? EMA2 { get; set; }
        public double? EMA3 { get; set; }
        public double? MACDLine { get; set; }
        public double? MACDSignalLine { get; set; }
        public double? MACDHistorgram { get; set; }

    }

    public class Position
    {
        public DateTime TimeStamp { get; set; }
        public decimal? Leverage { get; set; }
        public int? CurrentQty { get; set; }
        public double? CurrentCost { get; set; }
        public bool IsOpen { get; set; }
        public decimal? MarkPrice { get; set; }
        public decimal? UnrealisedPnl { get; set; }
        public decimal? UnrealisedPnlPcnt { get; set; }
        public decimal? AvgEntryPrice { get; set; }
        public decimal? BreakEvenPrice { get; set; }
        public decimal? LiquidationPrice { get; set; }
        public string Symbol { get; set; }
    }

    public class Order
    {
        public DateTime TimeStamp { get; set; }
        public string Symbol { get; set; }
        public string OrdStatus { get; set; }
        public string OrdType { get; set; }
        public string OrderId { get; set; }
        public string Side { get; set; }
        public double? Price { get; set; }
        public int? OrderQty { get; set; }
        public int? DisplayQty { get; set; }
    }
}