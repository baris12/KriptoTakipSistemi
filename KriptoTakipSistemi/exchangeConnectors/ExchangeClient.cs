using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KriptoTakipSistemi.exchangeConnectors
{
    internal abstract class ExchangeClient
    {
        public bool ready = false;

        public WebSocketClient webSocketClient;
        public static ExchangeClient _instance;


        public static ExchangeClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BinanceClient();
                }
                return _instance;
            }
            set
            {
                if (value != null)
                {
                    _instance.Dispose();
                }
                _instance = value;
            }
        }

        public abstract Task<string> GetSingleSymbolTicker(string symbol);
        /*
        {
            "symbol": symbol,
            "price": price
        }
         */
        public abstract Task<List<string>> GetSymbolList();

        public abstract Task<JArray> GetPriceData(string symbol, TIME_FRAME timeFrame, int limit = 0);
        /*
         Data format: [[openTime, open, high, low, close, volume, closeTime], ...]
         */
        public abstract Task<string> GetAllTicker();

        public abstract void Dispose();
    }
}
