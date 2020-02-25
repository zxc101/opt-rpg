using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

namespace NyaGames
{
    //[DisallowMultipleComponent]
    //[RequireComponent(typeof(Image))]
    public class LootBox
    {
        public Reward[] GetRewards(ELootBoxLVL LootBoxLVL)
        {
            Data data = new Data();
            string[] equipPath = new string[7];
            string filePath = $"{ Application.streamingAssetsPath}/NyaGames/Equips/";

            if (LootBoxLVL == ELootBoxLVL.LVL1) filePath += "LVL 1";
            else if (LootBoxLVL == ELootBoxLVL.LVL2) filePath += "LVL 2";
            else if (LootBoxLVL == ELootBoxLVL.LVL3) filePath += "LVL 3";

            equipPath[0] = $"{filePath}/F";
            equipPath[1] = $"{filePath}/E";
            equipPath[2] = $"{filePath}/D";
            equipPath[3] = $"{filePath}/C";
            equipPath[4] = $"{filePath}/B";
            equipPath[5] = $"{filePath}/A";
            equipPath[6] = $"{filePath}/S";

            List<Reward> rewardList = new List<Reward>();

            for(int i = 0; i < equipPath.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(equipPath[i]);
                foreach (var equip in dir.GetFileSystemInfos())
                {
                    if (equip.Name.IndexOf(".meta") == -1)
                    {
                        filePath = $"{equipPath[i]}/{equip.Name}";
                        Stats s = data.GetData(filePath);
                        Reward r = new Reward();
                        r.stats = s;
                        r.chance = s.rarity.percent;
                        rewardList.Add(r);
                    }
                }
            }

            return rewardList.ToArray();
        }

        public Sprite GetSpriteLootBox(ELootBoxLVL boxLVL)
        {
            string filePath = $"Sprites/Boxes/";
            if (boxLVL == ELootBoxLVL.LVL1) filePath += "LVL 1";
            else if (boxLVL == ELootBoxLVL.LVL2) filePath += "LVL 2";
            else if (boxLVL == ELootBoxLVL.LVL3) filePath += "LVL 3";
            return Resources.Load<Sprite>(filePath);
        }
    }
}
