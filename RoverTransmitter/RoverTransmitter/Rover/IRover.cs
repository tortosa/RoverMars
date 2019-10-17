using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTransmitter
{
    public interface IRover
    {
        public void ProcessCommands(string commands);

        public Orientation GetOrientation();

        public Coordinates GetCoordinates();

        public bool IsInsideBounds();
    }
}