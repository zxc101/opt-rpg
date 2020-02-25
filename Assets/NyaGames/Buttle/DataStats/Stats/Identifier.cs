using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    [System.Serializable]
    public class Identifier : AStat, IEquipStat, IEnemyStat
    {
        public string name;
        public string appearanceName;
        public int price;

        public override void SetData(AStat stat)
        {
            name           = ((Identifier)stat).name;
            appearanceName = ((Identifier)stat).appearanceName;
            price          = ((Identifier)stat).price;
        }

        public void Show()
        {
            isUsing = true;
            ShowName();
            ShowAppearanceName();
            ShowPrice();
        }

        private void ShowName()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Имя");
            name = EditorGUILayout.TextField(name);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowAppearanceName()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Имя пути внешнего вида");
            appearanceName = EditorGUILayout.TextField(appearanceName);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowPrice()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Цена");
            price = EditorGUILayout.IntField(price);
            EditorGUILayout.EndHorizontal();
        }
    }
}
