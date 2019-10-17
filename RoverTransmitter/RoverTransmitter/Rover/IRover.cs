using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTransmitter
{
    public interface IRover
    {
        public OrientationEnum GetOrientation();

        public Coordinates GetCoordinates();

        public bool IsInsideBounds();
    }
}