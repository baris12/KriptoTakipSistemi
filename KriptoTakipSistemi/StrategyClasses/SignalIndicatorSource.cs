using System;

namespace KriptoTakipSistemi.StrategyClasses
{
    internal class SignalIndicatorSource : SignalDataSource
    {

        public PriceIndicator BaseIndicator;
        public string OutputSource;

        public override double GetByIndex()
        {
            throw new NotImplementedException();
        }

        public override double GetFirst()
        {
            throw new NotImplementedException();
        }

        public override double GetLast()
        {
            throw new NotImplementedException();
        }


    }
}
