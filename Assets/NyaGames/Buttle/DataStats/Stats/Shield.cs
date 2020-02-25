using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    [System.Serializable]
    public class Shield : AStat, IEquipStat, IEnemyStat
    {
        public int value;

        public override void SetData(AStat stat)
        {
            value = ((Shield)stat).value;
        }

        public void Add(Shield addedVal)
        {
            value = Mathf.Clamp(addedVal.value + value, 0, 100);
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
            GUILayout.Label("Щит", EditorStyles.boldLabel);
        }

        private void ShowValue()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Сила щита");
            value = EditorGUILayout.IntSlider(value, 0, 100);
            EditorGUILayout.EndHorizontal();
        }
    }
}
