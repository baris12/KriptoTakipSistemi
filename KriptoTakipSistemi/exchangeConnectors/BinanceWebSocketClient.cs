using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KriptoTakipSistemi.exchangeConnectors
{
    internal class BinanceWebSocketClient : WebSocketClient
    {
        private const string BaseUri = "wss://stream.binance.com:9443/ws";

        private ClientWebSocket _clientWebSocket;
        private int _currentId;
        private Dictionary<string, List<Action<string>>> _streamCallbacks;
        public BinanceWebSocketClient()
        {
            _clientWebSocket = new ClientWebSocket();
            _currentId = 1;
            _streamCallbacks = new Dictionary<string, List<Action<string>>>();
        }

        public override async Task StartAsync()
        {
            while (true)
            {
                try
                {

                    Uri serverUri = new Uri(BaseUri);
                    await Stop();
                    _clientWebSocket = new ClientWebSocket();
                    await _clientWebSocket.ConnectAsync(serverUri, CancellationToken.None);
                    foreach (string _streamName in _streamCallbacks.Keys)
                    {
                        foreach (Action<string> _callback in _streamCallbacks[_streamName])
                        {
                            await SubscribeStream(_streamName, _callback);
                        }
                    }
                    Console.WriteLine("WebSocket connection established.");
                    await ReceiveMessagesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }

        public override async Task Stop()
        {
            try
            {
                await _clientWebSocket?.CloseAsync(WebSocketCloseStatus.NormalClosure, "connection closed by client", CancellationToken.None);
                Console.WriteLine("WebSocket connection closed.");
            }
            catch
            {
                Console.WriteLine("webscoket connection cannot be closed!");
            }
        }
        public override async Task SubscribeSingleTickerStream(string symbol, Action<string> callback)
        {
            string streamName = $"{symbol.ToLower()}@ticker";
            await this.SubscribeStream(streamName, callback);
        }
        public override async Task UnsubscribeSingleTickerStream(string symbol, Action<string> callback)
        {
            string streamName = $"{symbol.ToLower()}@ticker";
            await this.UnsubscribeStream(streamName, callback);
        }
        public override async Task SubscribeAllTickerStream(Action<string> callback)
        {
            string streamName = "!ticker@arr";
            await this.SubscribeStream(streamName, callback);
        }
        public override async Task UnsubscribeAllTickerStream(Action<string> callback)
        {
            string streamName = "!ticker@arr";
            await this.UnsubscribeStream(streamName, callback);
        }

        public override async Task SubscribeKlineStream(string symbol, TIME_FRAME timeFrame, Action<string> callback)
        {
            string streamName = $"{symbol.ToLower()}@kline_{BinanceClient.ConvertTimeFrame(timeFrame)}";
            await this.SubscribeStream(streamName, callback);
            //Console.WriteLine("subscribed: " + streamName);
        }

        public override async Task UnsubscribeKlineStream(string symbol, TIME_FRAME timeFrame, Action<string> callback)
        {
            string streamName = $"{symbol.ToLower()}@kline_{BinanceClient.ConvertTimeFrame(timeFrame)}";
            await this.UnsubscribeStream(streamName, callback);
            //Console.WriteLine("unsubscribed: " + streamName);
        }


        private async Task SubscribeStream(string streamName, Action<string> callback)
        {
            var subscribeRequest = new
            {
                method = "SUBSCRIBE",
                @params = new[] { streamName },
                id = _currentId++
            };
            string subscribePayload = Newtonsoft.Json.JsonConvert.SerializeObject(subscribeRequest);
            await SendWebSocketMessage(subscribePayload);
            if (!_streamCallbacks.ContainsKey(streamName))
            {
                _streamCallbacks[streamName] = new List<Action<string>>();
            }

            if (!_streamCallbacks[streamName].Contains(callback))
            {
                _streamCallbacks[streamName].Add(callback);
            }
        }
        private async Task UnsubscribeStream(string streamName, Action<string> callback)
        {
            if (!_streamCallbacks.Keys.Contains(streamName))
            {
                return;
            }

            if (!_streamCallbacks[streamName].Contains(callback))
            {
                return;
            }

            _streamCallbacks[streamName]?.Remove(callback);
            var unsubscribeRequest = new
            {
                method = "UNSUBSCRIBE",
                @params = new[] { streamName },
                id = _currentId++
            };
            string unsubscribePayload = Newtonsoft.Json.JsonConvert.SerializeObject(unsubscribeRequest);
            await SendWebSocketMessage(unsubscribePayload);
        }
        private async Task SendWebSocketMessage(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            try
            {
                if (_clientWebSocket.State == WebSocketState.Open)
                {
                    await _clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private async Task ReceiveMessagesAsync()
        {

            const int bufferSize = 1024 * 10;
            byte[] buffer = new byte[bufferSize];
            MemoryStream receivedData = new MemoryStream();

            try
            {
                while (_clientWebSocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await _clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        receivedData.Write(buffer, 0, result.Count);

                        if (result.EndOfMessage)
                        {
                            string receivedMessage = Encoding.UTF8.GetString(receivedData.ToArray(), 0, (int)receivedData.Length);
                            ProcessReceivedMessage(receivedMessage);

                            receivedData = new MemoryStream();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Websocket connection is lost!");
            }

        }

        private void ProcessReceivedMessage(string message)
        {
            JToken parsedMessage;
            try
            {
                parsedMessage = JToken.Parse(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

            JObject Parse24HTicker(JToken obj)
            {
                JObject jObject = new JObject
                {
                    ["symbol"] = obj["s"].ToString().ToUpper(),
                    ["price"] = obj["c"].ToString().ToUpper(),
                    ["changePercent"] = obj["P"].ToString().ToUpper()
                };
                return jObject;
            }
            try
            {
                if (parsedMessage is JObject)
                {
                    JObject jsonObject = parsedMessage as JObject;
                    if (!jsonObject.ContainsKey("e"))
                    {
                        return;
                    }

                    string eventName = jsonObject["e"].ToString();
                    if (eventName == "24hrTicker")
                    {
                        JObject jObject = Parse24HTicker(jsonObject);

                        string streamName = jsonObject["s"].ToString().ToLower() + "@ticker";
                        if (_streamCallbacks.ContainsKey(streamName))
                        {
                            foreach (Action<string> action in _streamCallbacks[streamName])
                            {
                                try
                                {
                                    if (action != null)
                                    {
                                        action?.Invoke(jObject.ToString());
                                    }
                                }
                                catch (Exception)
                                {

                                }
                            }

                        }
                    }
                    else if (eventName == "kline")
                    {
                        JObject klineData = parsedMessage as JObject;
                        klineData = klineData["k"] as JObject;
                        JObject processedKlineData = new JObject
                        {
                            ["openTime"] = klineData["t"],
                            ["open"] = klineData["o"],
                            ["high"] = klineData["h"],
                            ["low"] = klineData["l"],
                            ["close"] = klineData["c"],
                            ["volume"] = klineData["q"],
                            ["closeTime"] = klineData["T"]
                        };

                        string streamName = $"{klineData["s"].ToString().ToLower()}@kline_{klineData["i"]}";
                        if (_streamCallbacks.ContainsKey(streamName))
                        {
                            foreach (Action<string> action in _streamCallbacks[streamName])
                            {
                                action?.Invoke(processedKlineData.ToString());
                            }
                        }
                    }
                }
                else if (parsedMessage is JArray jsonArray)
                {
                    JArray jArray = new JArray();
                    string streamName = null;
                    foreach (JObject obj in jsonArray.Cast<JObject>())
                    {
                        string eventName = obj["e"].ToString();
                        if (eventName == "24hrTicker")
                        {
                            jArray.Add(Parse24HTicker(obj));
                            if (streamName == null)
                            {
                                streamName = "!ticker@arr";
                            }
                        }
                    }
                    if (_streamCallbacks.ContainsKey(streamName))
                    {
                        foreach (Action<string> action in _streamCallbacks[streamName])
                        {
                            if (action != null)
                            {
                                action?.Invoke(jArray.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
