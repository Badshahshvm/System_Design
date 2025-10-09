using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Designe_Pattern
{
    internal class TurnOnCommand :ICommand
    {

        private Light _light;
        public TurnOnCommand(Light light)
        {
            _light = light;
        }

        public void execute()
        {
            _light.TurnOn();
        }
    }
}
