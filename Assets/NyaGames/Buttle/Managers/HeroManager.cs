using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyaGames
{
    public class HeroManager : MonoBehaviour
    {
        public int power;
        public int endurance;
        public int agility;
        public int shield;
        public int luck;

        public List<Stats> equipmentList;
        public List<Stats> inventaryList;
        public List<Stats> storageList;
        public Sprite appearance;
        private Stats stats;

        [SerializeField] private string heroName;
        [SerializeField] private Object[] firstEquipment;

        private Data data;

        public string Name { get => heroName; }

        private void Init()
        {
            equipmentList = new List<Stats>();
            inventaryList = new List<Stats>();
            storageList = new List<Stats>();
            data = new Data();
            stats = new Stats();
        }
        
        // Power
        public int GetPower() => stats.power.value + (stats.characteristics.power + power) * 10;
        public int GetCritPower()
        {
            int critPower = stats.crit.value + stats.characteristics.power + power;
            if (critPower <= 50)
                return critPower / 10;
            else if (critPower > 50 && critPower < 100)
                return 5;
            else if (critPower >= 100)
                return 6;
            else
                return 1;
        }

        // Endurance
        public int GetHealth() => (stats.characteristics.endurance + endurance) * 50 + 
                                  (stats.characteristics.shield + shield) * 40 +
                                   stats.health.value;

        public int GetRegenCountSteps()
        {
            int countSteps = stats.regen.countSteps + stats.characteristics.endurance + endurance;
            if (countSteps >= 30 && countSteps < 60)
                return 3;
            else if (countSteps > 60 && countSteps < 100)
                return 5;
            else if (countSteps >= 100)
                return 8;
            else
                return 0;
        }

        public int GetRegenPower()
        {
            int regenPower = stats.regen.value + stats.characteristics.endurance + endurance;
            if (regenPower >= 30 && regenPower < 60)
                return GetHealth() / GetRegenCountSteps() / 3;
            else if (regenPower > 60 && regenPower < 100)
                return GetHealth() / GetRegenCountSteps() / 2;
            else if (regenPower >= 100)
                return GetHealth() / GetRegenCountSteps();
            else
                return 0;
        }

        // Shield
        public int GetShield()
        {
            int _shield = stats.shield.value + stats.characteristics.shield + shield;
            if (_shield <= 50)
                return _shield / 10 * 10;
            if (_shield > 50 && _shield < 100)
                return 50;
            else if (_shield >= 100)
                return 60;
            else
                return 0;
        }

        // Agility
        public int GetEvasion()
        {
            int evasion = stats.agility.evasion + stats.characteristics.agility + agility;
            if (evasion <= 50)
                return evasion / 10 * 10;
            if (evasion > 50 && evasion < 100)
                return 50;
            else if (evasion >= 100)
                return 60;
            else
                return 0;
        }
        public int GetAttackSpeed() => stats.agility.attackSpeed + (stats.characteristics.agility + agility) / 10;

        public float GetProcentAttackYourself()
        {
            float attackYourself = stats.agility.procentAttackYourself + stats.characteristics.agility + agility;
            float res = 30;
            res -= Mathf.Clamp(attackYourself * 0.3f, 0.1f, 30f);
            return res;
        }

        // Luck
        public int GetPoisonPercent() => Mathf.Clamp(stats.poison.percent + stats.characteristics.luck + luck, 0, 80);
        public int GetRegenProcent() => Mathf.Clamp(stats.regen.percent + stats.characteristics.luck + luck, 0, 60);
        public int GetCritProcent()
        {
            int critProcent = stats.crit.percent + stats.characteristics.luck + luck;
            if (critProcent >= 10 && critProcent < 30)
                return 10;
            else if (critProcent >= 30 && critProcent < 50)
                return 20;
            else if (critProcent >= 50 && critProcent < 80)
                return 45;
            else if (critProcent >= 80 && critProcent < 100)
                return 60;
            else if (critProcent >= 100)
                return 70;
            else
                return 0;
        }

        public void GetDamage(int _power) => stats.health.value -= _power;

        private void OnValidate()
        {
            power = power < 0 ? 0 : power;
            endurance = endurance < 0 ? 0 : endurance;
            agility = agility < 0 ? 0 : agility;
            shield = shield < 0 ? 0 : shield;
            luck = luck < 0 ? 0 : luck;
        }

        private void Start()
        {
            Init();
            SetFirstStats();
        }

        public void AddEquipment(Stats equipment)
        {
            equipmentList.Add(equipment);
            stats.Add(equipment);
        }

        public Stats GetStats() => stats;

        public void SetFirstStats()
        {
            stats = new Stats();
            for (int i = 0; i < firstEquipment.Length; i++)
            {
                Stats s = data.GetData(firstEquipment[i], ETypeStatObj.Equip);
                stats.Add(s);
            }
        }
    }
}

