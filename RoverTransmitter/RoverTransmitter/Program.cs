using System;

namespace RoverTransmitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var widthSize = 25;
            var heightSize = 25;
            var RoverPositionX = 25;
            var RoverPositionY = 25;
            var initialOrientation = OrientationEnum.North;
            var commandString = "AALAARALADSDADAADSADADAE";

            var boundary = new Bounds(widthSize, heightSize);
            var initialCoordinates = new Coordinates(RoverPositionX, RoverPositionY);            
            var opportunity = new Rover(boundary, initialCoordinates, initialOrientation);

            opportunity.OnProcessCommandExecuted += (info) =>
            {
                Console.WriteLine(info);
            };

            opportunity.OnNotValidCommand += (info) =>
            {
                Console.WriteLine(info);
            };
                        
            var commandSet = new CommandSet(commandString);
            opportunity.ProcessCommands(commandSet);
            opportunity.GetCoordinates();
            Console.ReadLine();
        }
    }
}