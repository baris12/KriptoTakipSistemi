using System.Collections.Generic;

namespace KriptoTakipSistemi.StrategyClasses
{
    internal class PriceIndicator
    {
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public int InputCount;
        public int OutputCount;
        public int OptionsCount;

        public List<string> InputNames;
        public List<string> OutputNames;
        public List<string> OptionsNames;

        public double[] Inputs;
        public double[] Options;
        public double[] Outputs;
    }
}
