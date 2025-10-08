using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Designe_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Using old printer via adapter
            OldPrinter oldPrinter = new OldPrinter();
            IPrinter printer = new PrinterAdapter(oldPrinter);

            printer.Print("Hello, Adapter Pattern!");
        }
    }
}
