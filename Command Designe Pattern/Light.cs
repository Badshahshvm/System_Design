using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Designe_Pattern
{
    internal class Light
    {
        public void TurnOn() => Console.WriteLine("Light is ON");
        public void TurnOff() => Console.WriteLine("Light is OFF");
    }
}
