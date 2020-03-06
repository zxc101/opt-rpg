using UnityEngine;

namespace NyaGames.Statistics
{
    [System.Serializable]
    public class Agility
    {
        public int attackSpeed;
        [Range(0, 100)]
        public int evasion;
        public float percentAttackYourself;

        public void Add(Agility addedVal)
        {
            attackSpeed += addedVal.attackSpeed;
            evasion = Mathf.Clamp(addedVal.evasion + evasion, 0, 100);
            percentAttackYourself = Mathf.Clamp(addedVal.percentAttackYourself + percentAttackYourself, 1, 60);
        }
    }
}
