using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandAdd : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }

        public CommandAdd()
        {
            Name = "Quit";
            Command = "quit";

            AddCommandToConsole();
        }
        public override void RunCommand()
        {
            Application.Quit();
        }
        public static CommandAdd CreateCommand()
        {
            return new CommandAdd();
        }
    }
}
