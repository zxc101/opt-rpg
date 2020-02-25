using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace NyaGames
{
    public class NewBehaviourScript : MonoBehaviour
    {
        public Object obj;
        private Data data;
        Stats stats;

        private void Start()
        {
            data = new Data();
            stats = data.GetData(obj, ETypeStatObj.Equip);
            Debug.Log($"Attack speed: {stats.agility.attackSpeed}");

            string filePath = $"{Application.streamingAssetsPath}/NyaGames/Equips";
            DirectoryInfo dir = new DirectoryInfo(filePath);
            foreach (var equip in dir.GetFileSystemInfos())
            {
                if(equip.Name.IndexOf(".meta") == -1)
                    Debug.Log(equip.Name);
            }
        }
    }
}
