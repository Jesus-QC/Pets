using System.Collections.Generic;
using Exiled.API.Features;
using JesusQC_Npcs.Features;

namespace Pets.Features
{
    public class PetManager
    {
        public static Dictionary<Player, Dummy> PetDictionary = new Dictionary<Player, Dummy>();
        public static HashSet<Player> PetEnabled = new HashSet<Player>();

        public static void Restart()
        {
            PetDictionary.Clear();
        }
    }
}