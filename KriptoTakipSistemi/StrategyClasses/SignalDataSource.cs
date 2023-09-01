namespace KriptoTakipSistemi.StrategyClasses
{
    internal abstract class SignalDataSource
    {
        public enum SIGNAL_SOURCE_TYPE
        {
            PRICE = 1,
            INDICATOR = 2,
        }
        public double[] Data;

        public abstract double GetFirst();
        public abstract double GetLast();
        public abstract double GetByIndex();
    }
}
