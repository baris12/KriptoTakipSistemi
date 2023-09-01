using System.Collections.Generic;

namespace KriptoTakipSistemi.StrategyClasses
{
    internal class TradeSignal
    {
        public enum SIGNAL_CONDITION
        {
            IS_UPPER = 1,
            IS_LOWER = 2,
            IS_UPPER_OR_EQUAL = 3,
            IS_LOWER_OR_EQUAL = 4,
            CROSS_UP = 5,
            CROSS_DOWN = 6,
            CROSS = 7,
        }
        public enum SIGNAL_TYPE
        {
            STRONG_BUY = 1,
            BUY = 2,
            SELL = 3,
            STRONG_SELL = 4,
            NEUTRAL = 5,
        }
        public class SignalRule
        {
            public SIGNAL_CONDITION Condition;
            public string SourceName;
            public double ComparisonValue;
        }

        // rsi(14) rsi > 20
        public PriceIndicator BaseIndicator;
        public List<double> Options;
        public Dictionary<SIGNAL_TYPE, List<SignalRule>> Rules;

        public void AddRule(SIGNAL_TYPE ruleType, string sourceName, SIGNAL_CONDITION condition, double comparisonValue)
        {
            if (Rules[ruleType] == null) { Rules[ruleType] = new List<SignalRule>(); }
            SignalRule newRule = new SignalRule
            {
                Condition = condition,
                SourceName = sourceName,
                ComparisonValue = comparisonValue
            };
            Rules[ruleType].Add(newRule);
        }
        public void RemoveRule(SIGNAL_TYPE ruleType, SignalRule signalRule)
        {
            Rules[ruleType].Remove(signalRule);
        }
    }


}
