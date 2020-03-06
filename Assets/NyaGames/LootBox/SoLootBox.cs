using UnityEngine;

namespace NyaGames.LootBox
{
    [CreateAssetMenu(fileName = "NewLootBox", menuName = "NyaGames/LootBox")]
    public class SoLootBox : ScriptableObject
    {
        public Sprite sprite;
        public ElLootBox[] equpments;
    }
}
