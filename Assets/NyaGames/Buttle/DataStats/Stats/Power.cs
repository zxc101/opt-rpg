using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    [System.Serializable]
    public class Power : AStat, IEquipStat, IEnemyStat
    {
        public int value;

        public override void SetData(AStat stat)
        {
            value = ((Power)stat).value;
        }

        public void Add(Power addedVal)
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
            GUILayout.Label("Сила", EditorStyles.boldLabel);
        }

        private void ShowValue()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Сила удара");
            value = EditorGUILayout.IntField(value);
            EditorGUILayout.EndHorizontal();
        }
    }
}
