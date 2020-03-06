using UnityEngine.UI;
using UnityEngine;

namespace NyaGames.UI.Canvases
{
    public class LootBoxCanvas : ARewardCanvas
    {
        [Space]
        [Header("LootBox values")]
        [SerializeField] private Image spriteLootBox;
        
        private void OnEnable()
        {
            if (dataHolder.lootBox.equpments.Length != 0)
            {
                rewards = dataHolder.lootBox.equpments;
                DoOnEnable();
            }
            spriteLootBox.sprite = dataHolder.lootBox.sprite;
        }
    }
}
