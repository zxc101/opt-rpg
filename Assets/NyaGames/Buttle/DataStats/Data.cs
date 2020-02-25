using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace NyaGames
{
    [System.Serializable]
    public class Data
    {
        public Dictionary<EEquipStat, AStat> stats = new Dictionary<EEquipStat, AStat>();

        public Data()
        {
            stats.Add(EEquipStat.Identifier, new Identifier());
            stats.Add(EEquipStat.Power, new Power());
            stats.Add(EEquipStat.Health, new Health());
            stats.Add(EEquipStat.Regeneration, new Regeneration());
            stats.Add(EEquipStat.Agility, new Agility());
            stats.Add(EEquipStat.Shield, new Shield());
            stats.Add(EEquipStat.Luck, new Crit());
            stats.Add(EEquipStat.Vampire, new Vampire());
            stats.Add(EEquipStat.Poison, new Poison());
            stats.Add(EEquipStat.Characteristics, new Characteristics());
            stats.Add(EEquipStat.Rarity, new Rarity());
        }

        public void Show(ETypeStatObj typeObj)
        {
            if (typeObj == ETypeStatObj.Enemy)
                foreach (EEquipStat key in stats.Keys)
                    if (stats[key] as IEnemyStat != null)
                        ((IEnemyStat)stats[key]).Show();

            if (typeObj == ETypeStatObj.Equip)
                foreach (EEquipStat key in stats.Keys)
                    if (stats[key] as IEquipStat != null)
                        ((IEquipStat)stats[key]).Show();
        }

        public void DoNotUseAnyChar()
        {
            foreach (EEquipStat key in stats.Keys)
                stats[key].isUsing = false;
        }

        public Stats Write()
        {
            Stats newStat = new Stats();
            newStat.identifier = (Identifier)stats[EEquipStat.Identifier];
            newStat.power = (Power)stats[EEquipStat.Power];
            newStat.health = (Health)stats[EEquipStat.Health];
            newStat.agility = (Agility)stats[EEquipStat.Agility];
            newStat.shield = (Shield)stats[EEquipStat.Shield];
            newStat.crit = (Crit)stats[EEquipStat.Luck];
            newStat.vampire = (Vampire)stats[EEquipStat.Vampire];
            newStat.regen = (Regeneration)stats[EEquipStat.Regeneration];
            newStat.poison = (Poison)stats[EEquipStat.Poison];
            newStat.characteristics = (Characteristics)stats[EEquipStat.Characteristics];
            newStat.rarity = (Rarity)stats[EEquipStat.Rarity];
            return newStat;
        }

        public void Read(Stats readStat)
        {
            ((Identifier)stats[EEquipStat.Identifier]).SetData(readStat.identifier);
            ((Power)stats[EEquipStat.Power]).SetData(readStat.power);
            ((Health)stats[EEquipStat.Health]).SetData(readStat.health);
            ((Agility)stats[EEquipStat.Agility]).SetData(readStat.agility);
            ((Shield)stats[EEquipStat.Shield]).SetData(readStat.shield);
            ((Crit)stats[EEquipStat.Luck]).SetData(readStat.crit);
            ((Vampire)stats[EEquipStat.Vampire]).SetData(readStat.vampire);
            ((Regeneration)stats[EEquipStat.Regeneration]).SetData(readStat.regen);
            ((Poison)stats[EEquipStat.Poison]).SetData(readStat.poison);
            ((Characteristics)stats[EEquipStat.Characteristics]).SetData(readStat.characteristics);
            ((Rarity)stats[EEquipStat.Rarity]).SetData(readStat.rarity);
        }

        public Stats[] GetData(Object[] objs, ETypeStatObj typeObj)
        {
            Stats[] res = new Stats[objs.Length];
            for(int i = 0; i < objs.Length; i++)
            {
                res[i] = GetData(objs[i], typeObj);
            }
            return res;
        }

        public Stats GetData(Object obj, ETypeStatObj typeObj)
        {
            string filePath;

            if (typeObj == ETypeStatObj.Enemy)
                filePath = $"{Application.streamingAssetsPath}/NyaGames/Enemies/{obj.name}.json";
            else if (typeObj == ETypeStatObj.Equip)
                filePath = $"{Application.streamingAssetsPath}/NyaGames/Equips/{obj.name}.json";
            else
                filePath = EditorUtility.SaveFilePanel("Save", Application.streamingAssetsPath, obj.name, "json");
            
            return GetData(filePath);
        }

        public Stats GetData(string filePath)
        {
            Stats objStats = null;

            if (!string.IsNullOrEmpty(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                Read(JsonUtility.FromJson<Stats>(dataAsJson));
            }

            objStats = Write();

            return objStats;
        }
    }
}
