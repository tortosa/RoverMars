
using System;
using System.Text;

namespace RoverTransmitter
{
    public class Rover : IRover, IProcessCommands
    {
        private Bounds bounds;
        private Coordinates coordinates;
        private OrientationEnum orientation;

        public event OnProcessCommand OnProcessCommandExecuted;
        public delegate void OnProcessCommand(Rover rover, string info);

        public event OnNotValidProcessCommand OnNotValidCommand;
        public delegate void OnNotValidProcessCommand(string info);

        public Rover(Bounds initialBounds, Coordinates initialCoordinates, OrientationEnum initialOrientation)
        {
            bounds = initialBounds;
            coordinates = initialCoordinates;
            orientation = initialOrientation;
            if (!IsInsideBounds())
                throw new Exception("Rover must be deployed inside the boundary");
        }

        private void MoveForward()
        {
            int x = coordinates.X;
            int y = coordinates.Y;

            switch (orientation)
            {
                case OrientationEnum.North:
                    coordinates.Y += 1;
                    break;
                case OrientationEnum.East:
                    coordinates.X += 1;
                    break;
                case OrientationEnum.South:
                    coordinates.Y -= 1;
                    break;
                case OrientationEnum.West:
                    coordinates.X -= 1;
                    break;
            }

            if (!IsInsideBounds())
            {
                coordinates.Y = y;
                coordinates.X = x;
            }
        }

        private void Rotate(CommandEnum command)
        {
            switch (command)
            {
                case CommandEnum.Left:
                    orientation = orientation == OrientationEnum.North ? OrientationEnum.West : orientation - 90;
                    break;
                case CommandEnum.Right:
                    orientation = orientation == OrientationEnum.West ? OrientationEnum.North : orientation + 90;
                    break;
            }
        }

        private string GetInfo()
        {
            StringBuilder infoBuilder = new StringBuilder(string.Empty);
            infoBuilder.Append(IsInsideBounds().ToString());
            infoBuilder.Append(", ");
            infoBuilder.Append(Enum.GetName(orientation.GetType(), orientation));
            infoBuilder.Append(", (");
            infoBuilder.Append(coordinates?.X.ToString());
            infoBuilder.Append(", ");
            infoBuilder.Append(coordinates?.Y.ToString());
            infoBuilder.Append(")");
            return infoBuilder.ToString();
        }

        public Coordinates GetCoordinates()
        {
            return this.coordinates;
        }

        public Bounds GetBounds()
        {
            return this.bounds;
        }

        public OrientationEnum GetOrientation()
        {
            return orientation;
        }

        public bool IsInsideBounds()
        {
            var insideX = (coordinates.X >= 0 && coordinates.X <= bounds.Width);
            var insideY = (coordinates.Y >= 0 && coordinates.Y <= bounds.Height);

            return insideX && insideY;
        }

        public bool ProcessCommand(CommandEnum command)
        {
            switch (command)
            {
                case CommandEnum.Advance:
                    MoveForward();
                    break;
                case CommandEnum.Left:
                case CommandEnum.Right:
                    Rotate(command);
                    break;
                case CommandEnum.NotValid:
                    OnNotValidCommand?.Invoke(Enum.GetName(command.GetType(), command) + " command executed");
                    break;
            }

            OnProcessCommandExecuted?.Invoke(this, GetInfo());
            return IsInsideBounds();
        }

        public void ProcessCommands(CommandSet commandSet)
        {
            foreach (var command in commandSet.Commands)
            {
                var isProcessed = ProcessCommand(command);
            }
        }
    }
}