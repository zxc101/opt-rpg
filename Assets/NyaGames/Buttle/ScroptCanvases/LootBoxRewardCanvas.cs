using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace NyaGames
{
    public class LootBoxRewardCanvas : RewardCanvas
    {
        [Space]
        [Header("LootBox values")]
        [SerializeField] private Image spriteLootBox;

        private LootBox lootBox;

        private void OnEnable()
        {
            lootBox = new LootBox();
            rewards = lootBox.GetRewards(DB.lootBoxLVL);
            if (rewards.Length != 0)
            {
                DoOnEnable();
            }
            spriteLootBox.sprite = lootBox.GetSpriteLootBox(DB.lootBoxLVL);
        }
    }
}
