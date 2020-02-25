using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace NyaGames
{
    public class BattleСanvas : MonoBehaviour
    {
        [SerializeField] private WinRewardCanvas winRewardCanvas;

        [SerializeField] private HeroManager heroManager;
        [SerializeField] private DB_Territory territory;
        [SerializeField] private RectTransform win;
        [SerializeField] private RectTransform lose;
        [SerializeField] private InputField countSteps_IF;
        [SerializeField] private Button countSteps_BTN;
        [SerializeField] private Image Hero_IMG;
        [SerializeField] private Image Enemy_IMG;

        private Stats enemy;
        private Stats hero;

        private void OnEnable()
        {
            hero = heroManager.GetStats();
            enemy = territory.GetEnemy();
            Hero_IMG.sprite = heroManager.appearance;
            Enemy_IMG.sprite = enemy.Appearance;
            Buttle();
        }

        public void Buttle()
        {
            enemy.health.value = 0;

            if (hero.AttackSpeed > enemy.AttackSpeed)
            {
                hero.agility.attackSpeed = Mathf.Clamp(hero.AttackSpeed - enemy.AttackSpeed, 1, 3);
                for(int i = 0; i < hero.AttackSpeed; i++)
                {
                    Attack(ref hero, ref enemy);
                }
                Attack(ref enemy, ref hero);
            }
            else if (hero.AttackSpeed < enemy.AttackSpeed)
            {
                Attack(ref hero, ref enemy);
                enemy.agility.attackSpeed = Mathf.Clamp(enemy.AttackSpeed - hero.AttackSpeed, 1, 3);
                for (int i = 0; i < enemy.AttackSpeed; i++)
                {
                    Attack(ref enemy, ref hero);
                }
            }
            else
            {
                Attack(ref hero, ref enemy);
                Attack(ref enemy, ref hero);
            }

            if (enemy.health.value == 0)
            {
                enemy = new Stats();

                win.gameObject.SetActive(true);
                return;
            }

            if (hero.health.value == 0)
            {
                enemy = new Stats();
                lose.gameObject.SetActive(true);
            }
        }

        public void MoveToReward()
        {
            win.gameObject.SetActive(false);
            gameObject.SetActive(false);
            winRewardCanvas.gameObject.SetActive(true);
        }

        public void MoveToMap()
        {
            lose.gameObject.SetActive(false);
            gameObject.SetActive(false);
            winRewardCanvas.gameObject.SetActive(true);
        }

        private void Attack(ref Stats val1, ref Stats val2)
        {
        }
    }
}
