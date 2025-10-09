using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Designe_Pattern
{
    internal class TurnOffCommand:ICommand
    {
        private Light _light;
        public TurnOffCommand(Light light)
        {
            _light = light;
        }

        public void execute()
        {
            _light.TurnOff();
        }
    }
}
