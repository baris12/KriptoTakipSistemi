using Binance.Spot;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace KriptoTakipSistemi.exchangeConnectors
{
    internal class BinanceClient : ExchangeClient
    {
        public BinanceClient()
        {
            this.ready = false;
            this.webSocketClient = new BinanceWebSocketClient();
        }

        ~BinanceClient()
        {
            this.ready = false;
        }

        public static Binance.Spot.Models.Interval ConvertTimeFrame(TIME_FRAME timeFrame)
        {
            if (timeFrame == TIME_FRAME.ONE_MIN)
            {
                return Binance.Spot.Models.Interval.ONE_MINUTE;
            }
            else if (timeFrame == TIME_FRAME.FIVE_MIN)
            {
                return Binance.Spot.Models.Interval.FIVE_MINUTE;
            }
            else if (timeFrame == TIME_FRAME.FIFTEEN_MIN)
            {
                return Binance.Spot.Models.Interval.FIFTEEN_MINUTE;
            }
            else if (timeFrame == TIME_FRAME.THIRTY_MIN)
            {
                return Binance.Spot.Models.Interval.THIRTY_MINUTE;
            }
            else if (timeFrame == TIME_FRAME.ONE_HOUR)
            {
                return Binance.Spot.Models.Interval.ONE_HOUR;
            }
            else if (timeFrame == TIME_FRAME.TWO_HOUR)
            {
                return Binance.Spot.Models.Interval.TWO_HOUR;
            }
            else if (timeFrame == TIME_FRAME.FOUR_HOUR)
            {
                return Binance.Spot.Models.Interval.FOUR_HOUR;
            }
            else if (timeFrame == TIME_FRAME.ONE_DAY)
            {
                return Binance.Spot.Models.Interval.ONE_DAY;
            }
            else if (timeFrame == TIME_FRAME.ONE_WEEK)
            {
                return Binance.Spot.Models.Interval.ONE_WEEK;
            }
            else if (timeFrame == TIME_FRAME.ONE_MONTH)
            {
                return Binance.Spot.Models.Interval.ONE_MONTH;
            }
            else
            {
                throw new Exception("Time frame is not valid");
            }
        }
        private async Task<string> CheckServerTime()
        {
            try
            {
                Market market = new Market();
                string serverTime = await market.CheckServerTime();
                this.ready = true;
                return serverTime;
            }
            catch (Exception)
            {
                this.ready = false;
                return null;
            }
        }

        private JArray ProcessRawTickerData(JArray data)
        {
            JArray tickerData = new JArray();
            foreach (JObject ticker in data.Cast<JObject>())
            {
                JObject jObject = new JObject
                {
                    ["symbol"] = ticker["symbol"].ToString(),
                    ["price"] = ticker["lastPrice"].ToString(),
                    ["changePercent"] = ticker["priceChangePercent"].ToString()
                };
                tickerData.Add(jObject);
            }

            return tickerData;
        }
        public override async Task<string> GetSingleSymbolTicker(string symbol)
        {
            if (!this.ready)
            {
                Task<string> checkServer = CheckServerTime();
                await Task.WhenAll(checkServer);
                if (checkServer.Result == null)
                {
                    return null;
                }
            }
            try
            {
                Market market = new Market();
                string rawData = await market.TwentyFourHrTickerPriceChangeStatistics(symbol: symbol.ToUpper());
                JArray parsedData = new JArray
                {
                    JObject.Parse(rawData)
                };
                return this.ProcessRawTickerData(parsedData)[0].ToString();
            }
            catch
            {
                this.ready = false;
                MessageBox.Show("borsa ile bağlantı kurulamıyor");
                return null;
            }
        }

        public override async Task<string> GetAllTicker()
        {
            if (!this.ready)
            {
                Task<string> checkServer = CheckServerTime();
                await Task.WhenAll(checkServer);
                if (checkServer.Result == null)
                {
                    return null;
                }
            }
            try
            {
                Market market = new Market();
                string rawData = await market.TwentyFourHrTickerPriceChangeStatistics();
                JArray parsedData = JArray.Parse(rawData);
                return this.ProcessRawTickerData(parsedData).ToString();
            }
            catch
            {
                this.ready = false;
                MessageBox.Show("borsa ile bağlantı kurulamıyor");
                return null;
            }
        }

        public override async Task<JArray> GetPriceData(string symbol, TIME_FRAME timeFrame, int limit = 10)
        {
            if (!this.ready)
            {
                Task<string> checkServer = CheckServerTime();
                await Task.WhenAll(checkServer);
                if (checkServer.Result == null)
                {
                    return null;
                }
            }
            try
            {
                Market market = new Market();
                string rawData = await market.KlineCandlestickData
                    (
                        symbol: symbol.ToUpper(),
                        interval: BinanceClient.ConvertTimeFrame(timeFrame),
                        limit: limit
                    );
                JArray data = JArray.Parse(rawData);
                JArray transformedData = new JArray();
                foreach (JArray item in data.Cast<JArray>())
                {
                    JObject transformedItem = new JObject
                    {
                        ["openTime"] = item[0],
                        ["open"] = item[1],
                        ["high"] = item[2],
                        ["low"] = item[3],
                        ["close"] = item[4],
                        ["volume"] = item[5],
                        ["closeTime"] = item[6]
                    };
                    transformedData.Add(transformedItem);
                }
                return transformedData;
            }
            catch (Exception)
            {
                this.ready = false;
                MessageBox.Show("borsa ile bağlantı kurulamıyor");
                return null;
            }


        }
        public override async Task<List<string>> GetSymbolList()
        {
            if (!this.ready)
            {
                Task<string> checkServer = CheckServerTime();
                await Task.WhenAll(checkServer);
                if (checkServer.Result == null)
                {
                    return null;
                }
            }
            try
            {
                Market market = new Market();
                string rawData = await market.ExchangeInformation();
                JsonElement symbols = JsonDocument.Parse(rawData).RootElement.GetProperty("symbols");
                List<string> tempList = new List<string>();
                foreach (JsonElement symbol in symbols.EnumerateArray())
                {
                    if (symbol.GetProperty("status").GetString() == "TRADING")
                    {
                        tempList.Add(symbol.GetProperty("symbol").GetString());
                    }
                }
                return tempList;

            }
            catch
            {
                this.ready = false;
                MessageBox.Show("borsa ile bağlantı kurulamıyor");
                return null;
            }
        }

        public override void Dispose()
        {
            webSocketClient.Stop();
            webSocketClient = null;
        }
    }
}
