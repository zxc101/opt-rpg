using UnityEngine;

namespace NyaGames.Statistics
{
    [System.Serializable]
    public class Characteristics
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

        public void Add(Characteristics addedVal)
        {
            power += addedVal.power;
            endurance += addedVal.endurance;
            agility += addedVal.agility;
            shield += addedVal.shield;
            luck += addedVal.luck;
        }
    }
}
