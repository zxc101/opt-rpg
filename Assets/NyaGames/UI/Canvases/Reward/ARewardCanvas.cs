using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

using NyaGames.Settings;
using NyaGames.Equipment;
using NyaGames.Hero;
using NyaGames.LootBox;

namespace NyaGames.UI.Canvases
{
    public abstract class ARewardCanvas : MonoBehaviour
    {
        [Space]
        [Header("Reward values")]
        [SerializeField] private SoHero hero;
        [SerializeField] private Image[] images;
        
        protected DataHolder dataHolder;
        protected ElLootBox[] rewards;

        private int count;
        private List<ElLootBox> gettingRewards;
        private List<SoEquipment> statsList;

        private void Awake()
        {
            dataHolder = FindObjectOfType<DataHolder>();
        }

        protected void DoOnEnable()
        {
            count = images.Length;
            gettingRewards = GetRewards();
            statsList = new List<SoEquipment>();
            for (int i = 0; i < gettingRewards.Count; i++)
            {
                statsList.Add(gettingRewards[i].equip);

                hero.AddInventary(statsList[i]);

                images[i].sprite = statsList[i].identifier.appearance;
            }
        }

        public void MoveToGame()
        {
            SceneManager.LoadScene("Game");
        }

        protected List<ElLootBox> GetRewards()
        {
            List<ElLootBox> resList = new List<ElLootBox>();
            List<ElLootBox> rewardList = new List<ElLootBox>();
            int random;

            while (resList.Count < count)
            {
                if (rewardList.Count == 0)
                {
                    for (int j = 0; j < rewards.Length; j++)
                    {
                        rewardList.Add(rewards[j]);
                    }
                }

                for (int i = 0; i < rewardList.Count; i++)
                {
                    if (rewardList[i].chance == 100)
                    {
                        resList.Add(rewardList[i]);
                        rewardList.RemoveAt(i);
                    }
                    if (rewardList.Count == count) break;
                }

                if (resList.Count == count) break;

                random = Random.Range(0, rewardList.Count);

                if (rewards[random].chance >= Random.value * 100)
                {
                    resList.Add(rewardList[random]);
                    rewardList.RemoveAt(random);
                }
            }
            return resList;
        }
    }
}
