using UnityEngine;

namespace NyaGames.Statistics
{
    [System.Serializable]
    public class Shield
    {
        [Range(0, 100)]
        public int value;

        public void Add(Shield addedVal)
        {
            value = Mathf.Clamp(addedVal.value + value, 0, 100);
        }
    }
}
