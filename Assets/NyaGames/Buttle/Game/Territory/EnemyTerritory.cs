using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyaGames
{
    public class EnemyTerritory : ATerritory
    {
        [SerializeField] private BattleСanvas buttleCanvas;
        [SerializeField] private DB_Territory DB;
        [SerializeField] private Object enemy;
        [SerializeField] private Reward[] rewards;

        public override void OnClick()
        {
            DB.SetEnemy(enemy);
            DB.Rewards = rewards;
            buttleCanvas.gameObject.SetActive(true);
        }
    }
}
