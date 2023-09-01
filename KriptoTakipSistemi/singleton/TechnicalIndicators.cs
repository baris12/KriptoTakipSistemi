using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using tinet;

namespace KriptoTakipSistemi.singleton
{
    internal class TechnicalIndicators
    {
        private static TechnicalIndicators _instance;

        public TechnicalIndicators()
        {

        }

        public static TechnicalIndicators Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TechnicalIndicators();
                }
                return _instance;
            }
        }
        private Dictionary<string, double[]> ExtractValuesFromPriceData(JArray priceData, bool open = false, bool high = false, bool low = false, bool close = false, bool volume = false)
        {
            if ((open || high || low || close || volume) == false)
            {
                throw new Exception("At least one of the parameters should be true");
            }

            Dictionary<string, double[]> result = new Dictionary<string, double[]>();
            if (open)
            {
                result.Add("open", new double[priceData.Count]);
            }

            if (high)
            {
                result.Add("high", new double[priceData.Count]);
            }

            if (low)
            {
                result.Add("low", new double[priceData.Count]);
            }

            if (close)
            {
                result.Add("close", new double[priceData.Count]);
            }

            if (volume)
            {
                result.Add("volume", new double[priceData.Count]);
            }

            for (int i = 0; i < priceData.Count; i++) // Extract price data
            {
                JObject bar = priceData[i] as JObject;
                if (open)
                {
                    if (double.TryParse(bar["open"].ToString(), out double openPrice))
                    {
                        result["open"][i] = openPrice;
                    }
                }

                if (high)
                {
                    if (double.TryParse(bar["high"].ToString(), out double highPrice))
                    {
                        result["high"][i] = highPrice;
                    }
                }

                if (low)
                {
                    if (double.TryParse(bar["low"].ToString(), out double lowPrice))
                    {
                        result["low"][i] = lowPrice;
                    }
                }

                if (close)
                {
                    if (double.TryParse(bar["close"].ToString(), out double closePrice))
                    {
                        result["close"][i] = closePrice;
                    }
                }

                if (volume)
                {
                    if (double.TryParse(bar["volume"].ToString(), out double barVolume))
                    {
                        result["volume"][i] = barVolume;
                    }
                }
            }
            return result;
        }


        public double[] RelativeStrengthIndex(JArray priceData, double rsiLength)
        {
            double[] closePrice = new double[priceData.Count];
            Dictionary<string, double[]> ExtractedValues = ExtractValuesFromPriceData(priceData, close: true);
            closePrice = ExtractedValues["close"];

            double[] options = new double[] { rsiLength };

            int output_length = closePrice.Length - indicators.rsi.start(options);
            double[] output = new double[output_length];

            double[][] inputs = { closePrice };
            double[][] outputs = { output };

            int success = indicators.rsi.run(inputs, options, outputs);


            return outputs[0];
        }

        public double[] AccumulationAndDistribution(JArray priceData)
        {
            double[] highPrice, lowPrice, closePrice, volume;
            Dictionary<string, double[]> ExtractedValues = ExtractValuesFromPriceData(priceData, high: true, low: true, close: true, volume: true);
            closePrice = ExtractedValues["close"];
            lowPrice = ExtractedValues["low"];
            highPrice = ExtractedValues["high"];
            volume = ExtractedValues["volume"];

            double[] options = new double[] { };
            int output_length = closePrice.Length - indicators.ad.start(options);
            double[] output = new double[output_length];

            double[][] inputs = { highPrice, lowPrice, closePrice, volume };
            double[][] outputs = { output };

            int success = indicators.ad.run(inputs, options, outputs);
            return outputs[0];
        }

        public double[] AverageDirectionalMovementIndex(JArray priceData, double period)
        {
            double[] highPrice, lowPrice, closePrice;
            Dictionary<string, double[]> ExtractedValues = ExtractValuesFromPriceData(priceData, high: true, low: true, close: true);
            closePrice = ExtractedValues["close"];
            lowPrice = ExtractedValues["low"];
            highPrice = ExtractedValues["high"];

            double[] options = new double[] { period };
            int output_length = closePrice.Length - indicators.adx.start(options);
            double[] output = new double[output_length];

            double[][] inputs = { highPrice, lowPrice, closePrice };
            double[][] outputs = { output };

            int success = indicators.adx.run(inputs, options, outputs);
            return outputs[0];
        }

    }
}
