using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTransmitter
{
    public interface IProcessCommands
    {
        public void ProcessCommands(CommandSet commands);
    }
}