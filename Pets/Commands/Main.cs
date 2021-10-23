using System;
using CommandSystem;
using Exiled.API.Features;

namespace Pets.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Main : ParentCommand
    {
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Please, specify a valid subcommand! Available ones: spawn, destroy, setrole, setname";
            return false;
        }

        public override string Command { get; } = "pet";
        public override string[] Aliases { get; }
        public override string Description { get; } = "The command to spawn pets.";

        public Main() => LoadGeneratedCommands();
        
        public override void LoadGeneratedCommands()
        {
            RegisterCommand(Destroy.Instance);
            RegisterCommand(Spawn.Instance);
            RegisterCommand(SetRole.Instance);
            RegisterCommand(SetName.Instance);
        }
    }
}