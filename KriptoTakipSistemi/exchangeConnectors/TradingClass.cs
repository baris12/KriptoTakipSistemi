using Binance.Spot;
using Binance.Spot.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace KriptoTakipSistemi.exchangeConnectors
{
    enum TRADE_SIDE
    {
        BUY = 1,
        SELL = 2
    }

    enum ORDER_TYPE
    {
        MARKET = 1,
        LIMIT = 2
    }
    internal class TradingClass
    {

        readonly string apiKey = ""; // for now apiKey is provided in code but it will be in database later.
        readonly string secretKey = ""; // in this situation, without apiKey trading feature throws exception
        HttpClient HttpClient;
        SpotAccountTrade SpotTrade;


        private static TradingClass _instance;


        public static TradingClass Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TradingClass();
                }
                return _instance;
            }
        }
        private Side ConvertSide(TRADE_SIDE side)
        {
            if (side == TRADE_SIDE.BUY)
            {
                return Side.BUY;
            }
            else
            {
                return Side.SELL;
            }
        }
        private OrderType ConvertOrderType(ORDER_TYPE orderType)
        {
            if (orderType == ORDER_TYPE.MARKET)
            {
                return OrderType.MARKET;
            }
            else
            {
                return OrderType.LIMIT;
            }
        }
        private void Initialize()
        {
            HttpClient = new HttpClient();
            SpotTrade = new SpotAccountTrade(HttpClient, apiKey: apiKey, apiSecret: secretKey);
        }
        public async Task<bool> BuyMarket(string symbol, decimal quantity)
        {
            try
            {
                if (HttpClient == null || SpotTrade == null)
                {
                    Initialize();
                }

                string result = await SpotTrade.NewOrder(symbol.ToUpper(), Side.BUY, OrderType.MARKET, quantity: quantity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> SellMarket(string symbol, decimal quantity)
        {
            try
            {
                if (HttpClient == null || SpotTrade == null)
                {
                    Initialize();
                }

                string result = await SpotTrade.NewOrder(symbol.ToUpper(), Side.SELL, OrderType.MARKET, quantity: quantity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}