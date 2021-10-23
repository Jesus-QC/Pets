using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using JesusQC_Npcs.Features;
using Pets.Features;
using Pets.Features.Components;
using UnityEngine;

namespace Pets.Commands
{
    public class Spawn : ICommand
    {
        public string Command { get; } = "spawn";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Spawn command";

        public static Spawn Instance { get; } = new Spawn();
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var ply = Player.Get(sender);
            
            if (!ply.CheckPermission("pets.spawn"))
            {
                response = "You can't spawn pets, you don't have enough permissions.";
                return false;
            }
            
            if (ply.HasPet())
            {
                response = "You can't spawn pets, you already have a pet.";
                return false;
            }

            var pet = new Dummy(ply.Position, MainClass.Cfg.PetsScale, MainClass.Cfg.EnforceSameRole ? ply.Role : MainClass.Cfg.DefaultRole, MainClass.Cfg.PetName.Replace("{player}", ply.Nickname));
            pet.PlayerWrapper.CustomInfo = MainClass.Cfg.CustomInfo;
            
            var petController = pet.PlayerWrapper.GameObject.AddComponent<PetController>();
            petController.Dummy = pet;
            petController.Owner = ply;
            
            PetManager.PetDictionary.Add(ply, pet);
            
            response = "Done!";
            return true;
        }
    }
}