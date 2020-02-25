using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyaGames
{
    public class DB_Territory : MonoBehaviour
    {
        private Stats enemy;
        private Data data;
        public ELootBoxLVL lootBoxLVL;

        private void Awake()
        {
            data = new Data();
        }

        public Stats GetEnemy() => enemy;
        public void SetEnemy(Object _enemy) => enemy = data.GetData(_enemy, ETypeStatObj.Enemy);
        public void SetEnemy(Stats _enemy) => enemy = _enemy;
        
        public Reward[] Rewards { get; set; }
    }
}
