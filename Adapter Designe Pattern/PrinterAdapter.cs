using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Designe_Pattern
{
    internal class PrinterAdapter:IPrinter
    {
        private readonly OldPrinter _oldPrinter;

        public PrinterAdapter(OldPrinter oldPrinter)
        {
            _oldPrinter = oldPrinter;
        }

        public void Print(string text)
        {
            // Adapting the method call
            _oldPrinter.OldPrint(text);
        }
    }
}
