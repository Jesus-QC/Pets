using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;
using UnityEngine;

namespace Pets
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("The name of the pet, {player} will be replaced with the name of the owner")]
        public string PetName { get; set; } = "{player}'s Pet";
        [Description("The text that will appear to identify pets, you can use hex colors")]
        public string CustomInfo { get; set; } = "<color=aqua>Pet</color>";
        [Description("The default role for pets when they spawn")]
        public RoleType DefaultRole { get; set; } = RoleType.Scp93953;
        [Description("The scale of the pets")]
        public Vector3 PetsScale { get; set; } = new Vector3(0.4f, 0.4f, 0.4f);
        [Description("If true the pet will be always the same role as the owner")]
        public bool EnforceSameRole { get; set; } = false;
    }
}