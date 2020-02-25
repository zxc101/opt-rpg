using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    [System.Serializable]
    public class Health : AStat, IEquipStat, IEnemyStat
    {
        public int value;

        public override void SetData(AStat stat)
        {
            value      = ((Health)stat).value;
        }

        public void Add(Health addedVal)
        {
            value += addedVal.value;
        }

        public void Show()
        {
            isUsing = true;
            ShowLabel();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            ShowValue();
            EditorGUILayout.EndVertical();
        }

        private void ShowLabel()
        {
            GUILayout.Label("Жизнь", EditorStyles.boldLabel);
        }

        private void ShowValue()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Количество жизни");
            value = EditorGUILayout.IntField(value);
            EditorGUILayout.EndHorizontal();
        }
    }
}
