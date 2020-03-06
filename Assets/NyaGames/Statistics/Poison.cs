using UnityEngine;

namespace NyaGames.Statistics
{
    [System.Serializable]
    public class Poison
    {
        public int value;
        [Range(0, 100)]
        public int percent;
        public int countSteps;

        public void Add(Poison addedVal)
        {
            value += addedVal.value;
            percent = Mathf.Clamp(addedVal.percent + percent, 0, 80);
            countSteps = Mathf.Max(addedVal.countSteps, countSteps);
        }
    }
}
