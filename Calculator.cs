using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcApp
{
    public class Calculator
    {
        private double value1;
        private double value2;
        //private string? operator_value;

        public double Value1 { get { return value1; } }
        public double Value2 { get { return value2; } }


        public Calculator(double value1, double value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

 

        public double Sum()
        {
            return Value1 + Value2;
        }

        public double Sub()
        {
            return Value1 - Value2;
        }
        public double Multi()
        {
            return Value1 * Value2; 
        }

        public double Divide()
        {
            return Value1 / Value2;
        }

    }
}
