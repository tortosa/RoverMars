using System;
using System.Threading;

namespace RoverTransmitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var widthSize = 25;
            var heightSize = 25;
            var RoverPositionX = 4;
            var RoverPositionY = 12;
            var initialOrientation = OrientationEnum.North;
            var commandString = "AALAARALA";

            var boundary = new Bounds(widthSize, heightSize);
            var initialCoordinates = new Coordinates(RoverPositionX, RoverPositionY);            
            var opportunity = new Rover(boundary, initialCoordinates, initialOrientation);

            opportunity.OnProcessCommandExecuted += BasicViewer;

            var commandSet = new CommandSet(commandString);
            opportunity.ProcessCommands(commandSet);

            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        private static void BasicViewer(Rover rover, string info)
        {
            const int TIME_FRAME_MILISECONDS = 500;
            const char ROVER_CHARACTER = (char)43;
            const char BOUNDARY_CHARACTER = (char)33;
            const int FONT_SIZE_ADJUST = 2;

            var roverBounds = rover.GetBounds();
            var roverCoords = rover.GetCoordinates();

            var width = roverBounds.Width * FONT_SIZE_ADJUST;
            var height = roverBounds.Height;

            Console.Clear();
            for (int y = 0; y <= height; y++)
            {
                for (int x = 0; x <= width; x++)
                {
                    if (roverCoords.X == x && roverCoords.Y == y)
                        Console.Write(ROVER_CHARACTER);
                    else
                    {
                        if (y == 0 || x == 0 || y == height || x == width)
                            Console.Write(BOUNDARY_CHARACTER);
                        else
                            Console.Write(" ");
                    }

                    if (x == width)
                        Console.WriteLine("");
                }
            }
            Console.WriteLine(info);
            Thread.Sleep(TIME_FRAME_MILISECONDS);
        }
    }
}