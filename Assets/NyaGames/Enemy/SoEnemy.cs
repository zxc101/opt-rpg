using UnityEngine;

using NyaGames.Statistics;
using NyaGames.LootBox;

namespace NyaGames.Enemy
{
    [CreateAssetMenu(fileName = "NewEnemy", menuName = "NyaGames/Enemy")]
    public class SoEnemy : ScriptableObject
    {
        public Identifier identifier;
        public Power power;
        public Health health;
        public Agility agility;
        public Shield shield;
        public Crit crit;
        public Poison poison;
        public XP xp;
        public ElLootBox[] rewards;

        public SoEnemy()
        {
            identifier = new Identifier();
            power = new Power();
            health = new Health();
            agility = new Agility();
            shield = new Shield();
            crit = new Crit();
            poison = new Poison();
            xp = new XP();
        }

        // Power
        public int Power
        {
            get => power.value * 10;
            set => power.value = value;
        }

        public int CritPower
        {
            get
            {
                int critPower = crit.value;
                if (critPower <= 50)
                    return critPower / 10;
                else if (critPower > 50 && critPower < 100)
                    return 5;
                else if (critPower >= 100)
                    return 6;
                else
                    return 1;
            }

            set => crit.value = value;
        }

        // Endurance
        public int Health
        {
            get => health.value;
            set => health.value = value;
        }

        // Shield
        public int Shield
        {
            get
            {
                int _shield = shield.value;
                if (_shield <= 50)
                    return _shield / 10 * 10;
                if (_shield > 50 && _shield < 100)
                    return 50;
                else if (_shield >= 100)
                    return 60;
                else
                    return 0;
            }

            set => shield.value = value;
        }

        // Agility
        public int Evasion
        {
            get
            {
                int evasion = agility.evasion;
                if (evasion <= 50)
                    return evasion / 10 * 10;
                if (evasion > 50 && evasion < 100)
                    return 50;
                else if (evasion >= 100)
                    return 60;
                else
                    return 0;
            }

            set => agility.evasion = value;
        }
        public int AttackSpeed
        {
            get => agility.attackSpeed;
            set => agility.attackSpeed = value;
        }

        public float PercentAttackYourself
        {
            get
            {
                float attackYourself = agility.percentAttackYourself;
                float res = 30;
                res -= Mathf.Clamp(attackYourself * 0.3f, 0.1f, 30f);
                return res;
            }

            set => agility.percentAttackYourself = value;
        }

        // Luck
        public int PoisonPercent
        {
            get => Mathf.Clamp(poison.percent, 0, 80);
            set => poison.percent = value;
        }

        public int CritPercent
        {
            get
            {
                int critPercent = crit.percent;
                if (critPercent >= 10 && critPercent < 30)
                    return 10;
                else if (critPercent >= 30 && critPercent < 50)
                    return 20;
                else if (critPercent >= 50 && critPercent < 80)
                    return 45;
                else if (critPercent >= 80 && critPercent < 100)
                    return 60;
                else if (critPercent >= 100)
                    return 70;
                else
                    return 0;
            }

            set => crit.percent = value;
        }
    }
}
