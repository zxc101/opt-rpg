using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    [System.Serializable]
    public class Regeneration : AStat, IEquipStat
    {
        public int value;
        public int percent;
        public int countSteps;

        public override void SetData(AStat stat)
        {
            value      = ((Regeneration)stat).value;
            percent    = ((Regeneration)stat).percent;
            countSteps = ((Regeneration)stat).countSteps;
        }

        public void Add(Regeneration addedVal)
        {
            value += addedVal.value;
            percent = Mathf.Clamp(addedVal.percent + percent, 0, 100);
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
            GUILayout.Label("Регенерация", EditorStyles.boldLabel);
        }

        private void ShowValue()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Сила регенерации за раз");
            value = EditorGUILayout.IntField(value);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowPercent()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Процент шанса начать регенерировать");
            percent = EditorGUILayout.IntSlider(percent, 0, 100);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowСountSteps()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Количество ходов в течении которых действует регенерация");
            countSteps = EditorGUILayout.IntField(countSteps);
            EditorGUILayout.EndHorizontal();
        }
    }
}
