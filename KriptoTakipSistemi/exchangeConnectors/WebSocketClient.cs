using System;
using System.Threading.Tasks;

namespace KriptoTakipSistemi.exchangeConnectors
{
    internal abstract class WebSocketClient
    {

        abstract public Task StartAsync();
        abstract public Task Stop();
        abstract public Task SubscribeSingleTickerStream(string symbol, Action<string> callback);
        abstract public Task UnsubscribeSingleTickerStream(string symbol, Action<string> callback);

        abstract public Task SubscribeAllTickerStream(Action<string> callback);
        abstract public Task UnsubscribeAllTickerStream(Action<string> callback);

        abstract public Task SubscribeKlineStream(string symbol, TIME_FRAME timeFrame, Action<string> callback);
        abstract public Task UnsubscribeKlineStream(string symbol, TIME_FRAME timeFrame, Action<string> callback);
    }
}
