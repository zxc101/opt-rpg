using UnityEngine.UI;
using UnityEngine;

using NyaGames.Hero;

namespace NyaGames.UI.Canvas
{
    public class Characteristic : MonoBehaviour
    {
        public SoHero hero;

        public Text freePoints;

        public Text powerText;
        public Text enduranceText;
        public Text agilityText;
        public Text shieldText;
        public Text luckText;

        private SoCharacteristics newCharacteristics;

        public void MinusPower() => Minus(ref newCharacteristics.power, ref powerText);
        public void PlusPower() => Plus(ref newCharacteristics.power, ref powerText);

        public void MinusEndurance() => Minus(ref newCharacteristics.endurance, ref enduranceText);
        public void PlusEndurance() => Plus(ref newCharacteristics.endurance, ref enduranceText);

        public void MinusAgility() => Minus(ref newCharacteristics.agility, ref agilityText);
        public void PlusAgility() => Plus(ref newCharacteristics.agility, ref agilityText);

        public void MinusShield() => Minus(ref newCharacteristics.shield, ref shieldText);
        public void PlusShield() => Plus(ref newCharacteristics.shield, ref shieldText);

        public void MinusLuck() => Minus(ref newCharacteristics.luck, ref luckText);
        public void PlusLuck() => Plus(ref newCharacteristics.luck, ref luckText);

        public void Enter() => SaveCharacteristics();

        private void OnEnable()
        {
            InitNewCharacteristics();
            ShowTexts();
        }

        private void InitNewCharacteristics()
        {
            newCharacteristics = new SoCharacteristics();
            newCharacteristics.freePoints = hero.characteristics.freePoints;
            newCharacteristics.power = hero.characteristics.power;
            newCharacteristics.endurance = hero.characteristics.endurance;
            newCharacteristics.agility = hero.characteristics.agility;
            newCharacteristics.shield = hero.characteristics.shield;
            newCharacteristics.luck = hero.characteristics.luck;
        }

        private void ShowTexts()
        {
            freePoints.text = hero.characteristics.freePoints.ToString();

            powerText.text = hero.characteristics.power.ToString();
            enduranceText.text = hero.characteristics.endurance.ToString();
            agilityText.text = hero.characteristics.agility.ToString();
            shieldText.text = hero.characteristics.shield.ToString();
            luckText.text = hero.characteristics.luck.ToString();
        }

        private void Minus(ref int newStat, ref Text text)
        {
            if(newCharacteristics.freePoints < hero.characteristics.freePoints && newStat > 0)
            {
                newStat--;
                text.text = newStat.ToString();
                freePoints.text = (++newCharacteristics.freePoints).ToString();
            }
        }

        private void Plus(ref int newStat, ref Text text)
        {
            if (newCharacteristics.freePoints > 0)
            {
                freePoints.text = (--newCharacteristics.freePoints).ToString();
                newStat++;
                text.text = newStat.ToString();
            }
        }

        private void SaveCharacteristics()
        {
            hero.characteristics.freePoints = newCharacteristics.freePoints;

            hero.characteristics.power = newCharacteristics.power;
            hero.characteristics.endurance = newCharacteristics.endurance;
            hero.characteristics.agility = newCharacteristics.agility;
            hero.characteristics.shield = newCharacteristics.shield;
            hero.characteristics.luck = newCharacteristics.luck;
        }
    }
}
