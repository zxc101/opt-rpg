using UnityEngine;

namespace NyaGames.Hero
{
    [System.Serializable]
    public class SoCharacteristics
    {
        [Range(0, 100)]
        public int power;
        [Range(0, 100)]
        public int endurance;
        [Range(0, 100)]
        public int agility;
        [Range(0, 100)]
        public int shield;
        [Range(0, 100)]
        public int luck;

        [HideInInspector] public int freePoints;

        public int LVL { get; private set; }

        public void AddLVL()
        {
            LVL++;
            freePoints += LVL % 2 == 0 && LVL != 0 ? 2 : 3;
        }

        public void ClearCharacteristics()
        {
            freePoints = 3;

            power = 0;
            endurance = 0;
            agility = 0;
            shield = 0;
            luck = 0;

            LVL = 1;
        }
    }
}
