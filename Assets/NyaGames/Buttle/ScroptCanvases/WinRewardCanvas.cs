using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace NyaGames
{
    public class WinRewardCanvas : RewardCanvas
    {
        private void OnEnable()
        {
            rewards = DB.Rewards;
            DoOnEnable();
        }
    }
}
