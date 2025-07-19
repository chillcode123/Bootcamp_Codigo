using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp001
{
    public class OperacionDivision
    {
        public int num1 { get; set; }
        public int num2 { get; set; }

        public int resultado { get; set; }

        //  Constructor
        public OperacionDivision(int numero1, int numero2)
        {
            num1 = numero1;
            num2 = numero2;
            resultado = numero1 / numero2;
        }

    }
}
