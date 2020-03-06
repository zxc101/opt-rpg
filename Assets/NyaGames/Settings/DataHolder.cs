using UnityEngine;

using NyaGames.Enemy;
using NyaGames.LootBox;

namespace NyaGames.Settings
{
    public class DataHolder : MonoBehaviour
    {
        [HideInInspector] public SoEnemy enemy;
        [HideInInspector] public SoLootBox lootBox;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
