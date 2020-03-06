using UnityEngine;

using NyaGames.Equipment;

namespace NyaGames.LootBox
{
    // Element LootBox
    [System.Serializable]
    public struct ElLootBox
    {
        public string Name;
        public SoEquipment equip;
        [Range(1, 100)]
        public int chance;
    }
}
