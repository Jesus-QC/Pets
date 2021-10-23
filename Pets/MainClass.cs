using System;
using Exiled.API.Features;
using Pets.Features;

namespace Pets
{
    public class MainClass : Plugin<Config>
    {
        public override string Author { get; } = "Jesus-QC";
        public override string Name { get; } = "Pets";
        public override string Prefix { get; } = "Pets";
        public override Version Version { get; } = new Version(0, 0, 1);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 15);
        
        public static Config Cfg;
        
        public override void OnEnabled()
        {
            Cfg = Config;
            
            Exiled.Events.Handlers.Server.RestartingRound += PetManager.Restart;
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RestartingRound -= PetManager.Restart;
            
            PetManager.Restart();
            
            base.OnDisabled();
        }
    }
}