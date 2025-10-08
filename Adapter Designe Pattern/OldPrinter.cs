using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Designe_Pattern
{
    internal class OldPrinter
    {

        public void OldPrint(string content)
        {
            Console.WriteLine("Old Printer Printing: " + content);
        }
    }
}
