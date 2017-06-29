using System;
using System.Collections.Generic;

namespace Calculator
{
    public enum Operator { None, Plus, Minus, Multiply, Division }

    public class CalculatorEngine
    {
        public List<decimal> Numbers { get; set; }
        public Operator UsedOperator { get; set; }
        public Int32 UsedNumberIterator;    


        public CalculatorEngine()
        {
            InitFields();
        }

        private void InitFields()
        {
            Numbers            = new List<decimal>() {0, 0};
            UsedOperator       = Operator.None;
            UsedNumberIterator = 0;
        }
    }
}
