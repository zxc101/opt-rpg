using UnityEngine;

namespace NyaGames.Statistics
{
    [System.Serializable]
    public class Regeneration
    {
        public int value;
        [Range(0,100)]
        public int percent;
        public int countSteps;

        public void Add(Regeneration addedVal)
        {
            value += addedVal.value;
            percent = Mathf.Clamp(addedVal.percent + percent, 0, 100);
            countSteps = Mathf.Max(addedVal.countSteps, countSteps);
        }
    }
}
