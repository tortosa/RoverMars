using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTransmitter
{
    public class Rover : IRover
    {
        private Bounds bounds;

        public Coordinates GetCoordinates()
        {
            throw new NotImplementedException();
        }

        public Orientation GetOrientation()
        {
            throw new NotImplementedException();
        }

        public bool IsInsideBounds()
        {
            throw new NotImplementedException();
        }

        public void ProcessCommands(string commands)
        {
            throw new NotImplementedException();
        }
    }
}