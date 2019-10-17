using System.Collections.Generic;

namespace RoverTransmitter
{
    public class CommandSet
    {
        public ICollection<CommandEnum> Commands { get; private set; }

        private CommandEnum TransformCommand(char command)
        {
            return command switch
            {
                'A' => CommandEnum.Advance,
                'L' => CommandEnum.Left,
                'R' => CommandEnum.Right,
                _ => CommandEnum.NotValid,
            };
        }

        private ICollection<CommandEnum> TransformCommands(string commandsRaw)
        {
            commandsRaw ??= string.Empty;

            ICollection<CommandEnum> commands = new List<CommandEnum>();
            var commandArray = commandsRaw.ToCharArray();

            foreach (var command in commandArray)
            {
                commands.Add(TransformCommand(command));
            }

            return commands;
        }

        public CommandSet(ICollection<CommandEnum> commandsToProcess)
        {
            Commands = commandsToProcess;
        }

        public CommandSet(string commandsToProcess)
        {
            Commands = TransformCommands(commandsToProcess);
        }
    }
}