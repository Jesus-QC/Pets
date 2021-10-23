using Exiled.API.Features;

namespace Pets.Features
{
    public static class Extensions
    {
        public static bool HasPet(this Player player)
        {
            if (PetManager.PetDictionary.ContainsKey(player) && PetManager.PetDictionary[player] == null)
                PetManager.PetDictionary.Remove(player);

            return PetManager.PetDictionary.ContainsKey(player);
        }
    }
}