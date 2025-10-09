using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Designe_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Light light = new Light();
            ICommand turnOn = new TurnOnCommand(light);
            ICommand turnOff = new TurnOffCommand(light);

            RemoteControl remote = new RemoteControl();

            // Turn ON the light
            remote.SetCommand(turnOn);
            remote.PressButton();

            // Turn OFF the light
            remote.SetCommand(turnOff);
            remote.PressButton(); 
        }
    }
}
