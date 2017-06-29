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

        private Dictionary<char, Operator> operatorChar;

        public CalculatorEngine()
        {
            InitFields();
        }

        private void InitFields()
        {
            operatorChar = new Dictionary<char, Operator>();
            operatorChar.Add(' ', Operator.None);
            operatorChar.Add('+', Operator.Plus);
            operatorChar.Add('-', Operator.Minus);
            operatorChar.Add('*', Operator.Multiply);
            operatorChar.Add('/', Operator.Division);

            Numbers            = new List<decimal>() {0, 0};
            UsedOperator       = Operator.None;
            UsedNumberIterator = 0;
        }

        public void AddDigit(char aDigit)
        {
            if (Numbers[UsedNumberIterator] != 0)
            {
                Numbers[UsedNumberIterator] = decimal.Parse(Numbers[UsedNumberIterator].ToString()
                                                            +
                                                            aDigit);
            }
            else
            {
                Numbers[UsedNumberIterator] = decimal.Parse("" + aDigit);
            }
        }

        public void SetOperator(char aOperatorChar)
        {
            UsedOperator = operatorChar[aOperatorChar];
            UsedNumberIterator = 1;
        }

        public void MakeCalculation()
        {
            switch (UsedOperator)
            {
                case Operator.Plus:
                    Numbers[0] += Numbers[1];
                    break;
                case Operator.Minus:
                    Numbers[0] -= Numbers[1];
                    break;
                case Operator.Multiply:
                    Numbers[0] *= Numbers[1];
                    break;
                case Operator.Division:
                    if (Numbers[1] != 0)
                    {
                        Numbers[0] /= Numbers[1];
                    }
                    break;
                default:
                    break;
            }
            UsedNumberIterator = 0;
            Numbers[1]         = 0;
            UsedOperator       = Operator.None;
        }

        public string PrintState()
        {
            string result = "";
            result += Numbers[0].ToString();

            if (UsedOperator != Operator.None)
            {
                foreach (var key in operatorChar.Keys)
                {
                    if (UsedOperator == operatorChar[key])
                    {
                        result += " " + key;
                    }
                }
            }
            if (Numbers[1] != 0)
            {
                result += " " + Numbers[1].ToString();
            }
            return result;
        }
    }
}
