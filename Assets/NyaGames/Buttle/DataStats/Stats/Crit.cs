using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    [System.Serializable]
    public class Crit : AStat, IEquipStat, IEnemyStat
    {
        public int value;
        public int percent;

        public override void SetData(AStat stat)
        {
            value   = ((Crit)stat).value;
            percent = ((Crit)stat).percent;
        }

        public void Add(Crit addedVal)
        {
            value += addedVal.value;
            percent = Mathf.Clamp(addedVal.percent + percent, 0, 100);
        }

        public void Show()
        {
            isUsing = true;
            ShowLabel();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            ShowValue();
            ShowPercent();
            EditorGUILayout.EndVertical();
        }

        private void ShowLabel()
        {
            GUILayout.Label("Критическая атака", EditorStyles.boldLabel);
        }

        private void ShowValue()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Значение прибавляемое к силе удара");
            value = EditorGUILayout.IntField(value);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowPercent()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Процент шанса ударить критической силой");
            percent = EditorGUILayout.IntSlider(percent, 0, 100);
            EditorGUILayout.EndHorizontal();
        }
    }
}
