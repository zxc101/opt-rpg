using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace NyaGames
{
    public class JSON_Manager
    {
        public static void SaveEquip(Data data)
        {
            string filePath = $"{ Application.streamingAssetsPath }/NyaGames/Equips/";
            SaveStats(data, filePath);
        }

        public static void SaveEnemy(Data data)
        {
            string filePath = $"{ Application.streamingAssetsPath }/NyaGames/Enemies/";
            filePath += $"Equips/";
            ELootBoxLVL rarityBox = ((Rarity)data.stats[EEquipStat.Rarity]).lootBoxLVL;
            ERarity rarity = ((Rarity)data.stats[EEquipStat.Rarity]).rarity;

            if (rarityBox == ELootBoxLVL.LVL1) filePath += $"LVL 1/";
            if (rarityBox == ELootBoxLVL.LVL2) filePath += $"LVL 2/";
            if (rarityBox == ELootBoxLVL.LVL3) filePath += $"LVL 3/";

            if (rarity == ERarity.A) filePath += $"A";
            if (rarity == ERarity.B) filePath += $"B";
            if (rarity == ERarity.C) filePath += $"C";
            if (rarity == ERarity.D) filePath += $"D";
            if (rarity == ERarity.E) filePath += $"E";
            if (rarity == ERarity.F) filePath += $"F";
            if (rarity == ERarity.S) filePath += $"S";

            SaveStats(data, filePath);
        }

        public static void LoadStats(ref Data data, string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                string dataAsJson = File.ReadAllText(path);
                data.Read(JsonUtility.FromJson<Stats>(dataAsJson));
            }
        }

        private static void SaveStats(Data data, string filePath)
        {
            Directory.CreateDirectory(filePath);
            filePath += $"/{((Identifier)data.stats[EEquipStat.Identifier]).name}.json";

            if (!string.IsNullOrEmpty(filePath))
            {
                string dataAsJson = JsonUtility.ToJson(data.Write());
                File.WriteAllText(filePath, dataAsJson);
            }
        }
    }
}
