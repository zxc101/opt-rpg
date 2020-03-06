using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

using NyaGames.Settings;
using NyaGames.Enemy;
using NyaGames.Hero;

namespace NyaGames.UI.Canvases
{
    public class BattleCanvas : MonoBehaviour
    {
        [SerializeField] private RectTransform win;
        [SerializeField] private RectTransform lose;
        [SerializeField] private InputField countSteps_IF;
        [SerializeField] private Button countSteps_BTN;
        [SerializeField] private Image Hero_IMG;
        [SerializeField] private Image Enemy_IMG;

        [SerializeField] private SoHero _hero;

        private DataHolder dataHolder;
        private SoHero hero;
        private SoEnemy enemy;

        private void OnEnable()
        {
            dataHolder = FindObjectOfType<DataHolder>();

            hero = _hero;
            enemy = dataHolder.enemy;
            Hero_IMG.sprite = _hero.appearance;
            Enemy_IMG.sprite = enemy.identifier.appearance;
            Buttle();
        }

        public void Buttle()
        {
            enemy.health.value = 0;

            if (hero.AttackSpeed > enemy.AttackSpeed)
            {
                int heroAttackSpeed = Mathf.Clamp(hero.AttackSpeed - enemy.AttackSpeed, 1, 3);
                for(int i = 0; i < heroAttackSpeed; i++)
                {
                    // Атака hero => enemy
                }
                // Атака enemy => hero
            }
            else if (hero.AttackSpeed < enemy.AttackSpeed)
            {
                // Атака hero => enemy
                int enemyAttackSpeed = Mathf.Clamp(enemy.AttackSpeed - hero.AttackSpeed, 1, 3);
                for (int i = 0; i < enemyAttackSpeed; i++)
                {
                    // Атака enemy => hero
                }
            }
            else
            {
                // Атака hero => enemy
                // Атака enemy => hero
            }

            if (enemy.health.value == 0)
            {
                enemy = ScriptableObject.CreateInstance<SoEnemy>();

                win.gameObject.SetActive(true);
                return;
            }

            if (hero.Health == 0)
            {
                enemy = ScriptableObject.CreateInstance<SoEnemy>();
                lose.gameObject.SetActive(true);
            }
        }

        public void MoveToWin()
        {
            SceneManager.LoadScene("Win");
        }

        public void MoveToMap()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
