using UnityEngine;

namespace NyaGames.Statistics
{
    [System.Serializable]
    public class Crit
    {
        public int value;
        [Range(0, 100)]
        public int percent;

        public void Add(Crit addedVal)
        {
            value += addedVal.value;
            percent = Mathf.Clamp(addedVal.percent + percent, 0, 100);
        }
    }
}
