using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace NyaGames
{
    public abstract class RewardCanvas : MonoBehaviour
    {
        [Space]
        [Header("Reward values")]
        [SerializeField] private MapCanvas mapCanvas;
        [SerializeField] protected DB_Territory DB;
        [SerializeField] private HeroManager hero;
        [SerializeField] private Image[] images;
        
        protected Reward[] rewards;

        private int count;
        private List<Reward> gettingRewards;
        private List<Stats> statsList;

        protected void DoOnEnable()
        {
            count = images.Length;
            gettingRewards = GetRewards();
            statsList = new List<Stats>();
            for (int i = 0; i < gettingRewards.Count; i++)
            {
                statsList.Add(gettingRewards[i].stats);

                hero.inventaryList.Add(statsList[i]);

                images[i].sprite = Resources.Load<Sprite>($"Sprites/{statsList[i].identifier.appearanceName}");
            }
        }

        public void MoveToGame()
        {
            gameObject.SetActive(false);
            mapCanvas.gameObject.SetActive(true);
        }

        protected List<Reward> GetRewards()
        {
            List<Reward> resList = new List<Reward>();
            List<Reward> rewardList = new List<Reward>();
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
