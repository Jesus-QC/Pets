using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using JesusQC_Npcs.Features;
using Mirror;
using Pets.Features;
using Pets.Features.Components;

namespace Pets.Commands
{
    public class SetName : ICommand
    {
        public string Command { get; } = "SetName";
        public string[] Aliases { get; } = { "name" };
        public string Description { get; } = "SetName command";

        public static SetName Instance { get; } = new SetName();
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var ply = Player.Get(sender);
            
            if (!ply.CheckPermission("pets.setname"))
            {
                response = "You can't change the name of pets, you don't have enough permissions.";
                return false;
            }

            if (!ply.HasPet())
            {
                response = "You can't change the name of pets, you don't have any pet.";
                return false;
            }
            
            var pet = PetManager.PetDictionary[ply];
            NetworkServer.UnSpawn(pet.PlayerWrapper.GameObject);
            pet.PlayerWrapper.ReferenceHub.nicknameSync.Network_myNickSync = arguments.At(0);
            NetworkServer.Spawn(pet.PlayerWrapper.GameObject);
            
            response = "Done!";
            return true;
        }
    }
}