using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mysimplecalculator
{
    public class MySimpleCalculator
    {
        public int Index { get; set; }
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public double Answer { get; set; }
        public double Addition()
        {
            return Number1 + Number2;    
        }

       public double Subtraction()
        {
            return Number1 - Number2;
        }

        public double Multiplication()
        {
            return Number1 * Number2;
        }

        public double Division()
        {
            return Number1 / Number2;
        }

        public MySimpleCalculator()
        {
            Number1 = Number2 = 0.0;
            Index = 0; 
        }   
    }
}

