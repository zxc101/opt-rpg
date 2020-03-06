using UnityEngine;

namespace NyaGames.Statistics
{
    [System.Serializable]
    public class Vampire
    {
        [Range(0, 100)]
        public int value;

        public void Add(Vampire addedVal)
        {
            value += addedVal.value;
        }
    }
}
