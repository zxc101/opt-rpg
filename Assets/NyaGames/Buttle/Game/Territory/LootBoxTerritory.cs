using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace NyaGames
{
    public class LootBoxTerritory : ATerritory
    {
        [SerializeField] private DB_Territory DB;
        [SerializeField] private ELootBoxLVL lootBoxLVL;

        public override void OnClick()
        {
            DB.lootBoxLVL = lootBoxLVL;
        }
    }
}
