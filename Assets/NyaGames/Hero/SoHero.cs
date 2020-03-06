using System.Collections.Generic;
using UnityEngine;

using NyaGames.Equipment;

namespace NyaGames.Hero
{
    [CreateAssetMenu(fileName = "NewHero", menuName = "NyaGames/Hero/Hero")]
    public class SoHero : ScriptableObject
    {
        public Sprite appearance;
        public SoCharacteristics characteristics;
        public Dictionary<EEquipmentType, SoEquipment> equipment;
        public List<SoEquipment> inventary;

        [HideInInspector] public int Health;

        private SoEquipment equipStats;

        // Power
        public int Power
        {
            get => equipStats.power.value + (equipStats.characteristics.power + characteristics.power) * 10;
            set => equipStats.power.value = value;
        }

        public int CritPower
        {
            get
            {
                int critPower = equipStats.crit.value + equipStats.characteristics.power + characteristics.power;
                if (critPower <= 50)
                    return critPower / 10;
                else if (critPower > 50 && critPower < 100)
                    return 5;
                else if (critPower >= 100)
                    return 6;
                else
                    return 1;
            }

            set => equipStats.crit.value = value;
        }

        // Endurance
        private int _Health => (equipStats.characteristics.endurance + characteristics.endurance) * 50 + 
                               (equipStats.characteristics.shield + characteristics.shield) * 40 +
                                equipStats.health.value;

        public int RegenPower
        {
            get
            {
                int regenPower = equipStats.regen.value + equipStats.characteristics.endurance + characteristics.endurance;
                if (regenPower >= 30 && regenPower < 60)
                    return _Health / RegenCountSteps / 3;
                else if (regenPower > 60 && regenPower < 100)
                    return _Health / RegenCountSteps / 2;
                else if (regenPower >= 100)
                    return _Health / RegenCountSteps;
                else
                    return 0;
            }

            set => equipStats.regen.value = value;
        }

        public int RegenCountSteps
        {
            get
            {
                int countSteps = equipStats.regen.countSteps + equipStats.characteristics.endurance + characteristics.endurance;
                if (countSteps >= 30 && countSteps < 60)
                    return 3;
                else if (countSteps > 60 && countSteps < 100)
                    return 5;
                else if (countSteps >= 100)
                    return 8;
                else
                    return 0;
            }

            set => equipStats.regen.countSteps = value;
        }

        // Shield
        public int Shield
        {
            get
            {
                int _shield = equipStats.shield.value + equipStats.characteristics.shield + characteristics.shield;
                if (_shield <= 50)
                    return _shield / 10 * 10;
                if (_shield > 50 && _shield < 100)
                    return 50;
                else if (_shield >= 100)
                    return 60;
                else
                    return 0;
            }

            set => equipStats.shield.value = value;
        }

        // Agility
        public int Evasion
        {
            get
            {
                int evasion = equipStats.agility.evasion + equipStats.characteristics.agility + characteristics.agility;
                if (evasion <= 50)
                    return evasion / 10 * 10;
                if (evasion > 50 && evasion < 100)
                    return 50;
                else if (evasion >= 100)
                    return 60;
                else
                    return 0;
            }

            set => equipStats.agility.evasion = value;
        }

        public int AttackSpeed
        {
            get => equipStats.agility.attackSpeed + (equipStats.characteristics.agility + characteristics.agility) / 10;
            set => equipStats.agility.attackSpeed = value;
        }

        public float PercentAttackYourself
        {
            get
            {
                float attackYourself = equipStats.agility.percentAttackYourself + equipStats.characteristics.agility + characteristics.agility;
                float res = 30;
                res -= Mathf.Clamp(attackYourself * 0.3f, 0.1f, 30f);
                return res;
            }

            set => equipStats.agility.percentAttackYourself = value;
        }

        // Luck
        public int PoisonPercent
        {
            get => Mathf.Clamp(equipStats.poison.percent + equipStats.characteristics.luck + characteristics.luck, 0, 80);
            set => equipStats.poison.percent = value;
        }

        public int RegenPercent
        {
            get => Mathf.Clamp(equipStats.regen.percent + equipStats.characteristics.luck + characteristics.luck, 0, 60);
            set => equipStats.regen.percent = value;
        }

        public int CritPercent
        {
            get
            {
                int critPercent = equipStats.crit.percent + equipStats.characteristics.luck + characteristics.luck;
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

            set => equipStats.crit.percent = value;
        }

        public void AddLVL() => characteristics.AddLVL();
        public void ClearCharacteristics() => characteristics.ClearCharacteristics();

        public void AddInventary(params SoEquipment[] equip)
        {
            for (int i = 0; i < equip.Length; i++)
            {
                inventary.Add(equip[i]);
            }
        }

        public void AddEquipment(params SoEquipment[] equips)
        {
            equipStats = new SoEquipment();
            for (int i = 0; i < equips.Length; i++)
            {
                equipment[equips[i].type] = equips[i];
                equipStats.Add(equipment[equips[i].type]);
            }
            UpdateStats();
        }

        public void Init()
        {
            equipment = new Dictionary<EEquipmentType, SoEquipment>();
            inventary = new List<SoEquipment>();
            equipStats = new SoEquipment();
            Health = _Health;

            InitEquipment();
        }

        private void InitEquipment()
        {
            foreach (EEquipmentType type in System.Enum.GetValues(typeof(EEquipmentType)))
            {
                equipment.Add(type, new SoEquipment());
            }
        }

        private void ClearEquipment()
        {
            foreach (EEquipmentType type in equipment.Keys)
            {
                equipment[type] = new SoEquipment();
            }
        }

        private void UpdateStats()
        {
            equipStats = new SoEquipment();
            foreach(EEquipmentType type in equipment.Keys)
            {
                equipStats.Add(equipment[type]);
            }
        }

        private void Death()
        {
            ClearStats();
            ClearEquipment();
            inventary.Clear();
        }

        private void ClearStats()
        {
            characteristics.power = 1;
            characteristics.endurance = 1;
            characteristics.agility = 1;
            characteristics.shield = 1;
            characteristics.luck = 1;
        }
    }
}

