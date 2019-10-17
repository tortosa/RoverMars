using System;

namespace RoverTransmitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var boundary = new Bounds(100, 200);
            var initialCoordinates = new Coordinates(boundary.Width/2, boundary.Height/2);
            
            var opportunity = new Rover(boundary, initialCoordinates, OrientationEnum.North);

            var commandSet = new CommandSet("AALAARALA");

            opportunity.ProcessCommands(commandSet);

            opportunity.GetCoordinates();
        }
    }
}