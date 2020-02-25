using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyaGames
{
    [System.Serializable]
    public class Reward
    {
        public string Name;
        public Object equip;
        [Range(0, 100)]
        public int chance;

        private Stats _stats;

        public Stats stats
        {
            get
            {
                if(_stats == null)
                {
                    Data data = new Data();
                    _stats = data.GetData(equip, ETypeStatObj.Equip);
                }
                return _stats;
            }
            set => _stats = value;
        }
    }
}
