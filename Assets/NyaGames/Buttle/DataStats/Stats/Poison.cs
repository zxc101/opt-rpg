using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    [System.Serializable]
    public class Poison : AStat, IEquipStat, IEnemyStat
    {
        public int value;
        public int percent;
        public int countSteps;

        public override void SetData(AStat stat)
        {
            value      = ((Poison)stat).value;
            percent    = ((Poison)stat).percent;
            countSteps = ((Poison)stat).countSteps;
        }

        public void Add(Poison addedVal)
        {
            value += addedVal.value;
            percent = Mathf.Clamp(addedVal.percent + percent, 0, 80);
            countSteps = Mathf.Max(addedVal.countSteps, countSteps);
        }

        public void Show()
        {
            isUsing = true;
            ShowLabel();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            ShowValue();
            ShowPercent();
            ShowСountSteps();
            EditorGUILayout.EndVertical();
        }

        private void ShowLabel()
        {
            GUILayout.Label("Отравление", EditorStyles.boldLabel);
        }

        private void ShowValue()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Сила удара за раз");
            value = EditorGUILayout.IntField(value);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowPercent()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Процент шанса наложить яд");
            percent = EditorGUILayout.IntSlider(percent, 0, 100);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowСountSteps()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Количество ходов в течении которых действует яд");
            countSteps = EditorGUILayout.IntField(countSteps);
            EditorGUILayout.EndHorizontal();
        }
    }
}
