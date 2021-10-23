using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using JesusQC_Npcs.Features;
using Pets.Features;
using Pets.Features.Components;

namespace Pets.Commands
{
    public class Destroy : ICommand
    {
        public string Command { get; } = "Destroy";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Destroy command";

        public static Destroy Instance { get; } = new Destroy();
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var ply = Player.Get(sender);
            
            if (!ply.CheckPermission("pets.destroy"))
            {
                response = "You can't destroy pets, you don't have enough permissions.";
                return false;
            }

            if (!ply.HasPet())
            {
                response = "You can't destroy pets, you don't have any pet.";
                return false;
            }

            var pet = PetManager.PetDictionary[ply];
            
            if (pet != null)
            {
                pet.Destroy();
                pet = null;
            }

            PetManager.PetDictionary.Remove(ply);

            response = "Done!";
            return true;
        }
    }
}