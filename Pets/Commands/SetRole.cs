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
    public class SetRole : ICommand
    {
        public string Command { get; } = "SetRole";
        public string[] Aliases { get; } = { "role" };
        public string Description { get; } = "SetRole command";

        public static SetRole Instance { get; } = new SetRole();
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var ply = Player.Get(sender);
            
            if (!ply.CheckPermission("pets.setrole"))
            {
                response = "You can't change the role of pets, you don't have enough permissions.";
                return false;
            }

            if (!ply.HasPet())
            {
                response = "You can't change the role of pets, you don't have any pet.";
                return false;
            }

            if (MainClass.Cfg.EnforceSameRole)
            {
                response = "You can't change your role, the server is configured to use the same role in pets and owners";
                return false;
            }
            
            if (!Enum.TryParse(arguments.At(0), true, out RoleType petRole))
            {
                response = "RoleType not found, valid ones:\nClassD, Scientist, Tutorial\nScp173, Scp049, Scp106, Scp0492, Scp096, Scp93989, Scp93953\nNtfSpecialist, NtfSergeant, NtfCaptain, NtfPrivate, FacilityGuard\nChaosConscript, ChaosRepressor, ChaosMarauder, ChaosRifleman ";
                return false;
            }

            if (petRole == RoleType.None || petRole == RoleType.Spectator || petRole == RoleType.Scp079)
            {
                response = "Don't do that :)";
                return false;
            }

            var pet = PetManager.PetDictionary[ply];
            NetworkServer.UnSpawn(pet.PlayerWrapper.GameObject);
            pet.PlayerWrapper.ReferenceHub.characterClassManager.CurClass = petRole;
            NetworkServer.Spawn(pet.PlayerWrapper.GameObject);
            
            response = "Done!";
            return true;
        }
    }
}