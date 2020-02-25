using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    [System.Serializable]
    public class Agility : AStat, IEquipStat, IEnemyStat
    {
        public int attackSpeed;
        public int evasion;
        public float procentAttackYourself;

        public override void SetData(AStat stat)
        {
            attackSpeed           = ((Agility)stat).attackSpeed;
            evasion               = ((Agility)stat).evasion;
            procentAttackYourself = ((Agility)stat).procentAttackYourself;
        }

        public void Add(Agility addedVal)
        {
            attackSpeed += addedVal.attackSpeed;
            evasion = Mathf.Clamp(addedVal.evasion + evasion, 0, 100);
            procentAttackYourself = Mathf.Clamp(addedVal.procentAttackYourself + procentAttackYourself, 1, 60);
        }

        public void Show()
        {
            isUsing = true;
            ShowLabel();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            ShowAttackSpeed();
            ShowPercent();
            ShowProcentAttackYourself();
            EditorGUILayout.EndVertical();
        }

        private void ShowLabel()
        {
            GUILayout.Label("Ловкость", EditorStyles.boldLabel);
        }

        private void ShowAttackSpeed()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Скорость ударов");
            attackSpeed = EditorGUILayout.IntField(attackSpeed);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowPercent()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Процент шанса уворота");
            evasion = EditorGUILayout.IntSlider(evasion, 0, 100);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowProcentAttackYourself()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Процент шанса ударить по себе");
            procentAttackYourself = EditorGUILayout.FloatField(procentAttackYourself);
            EditorGUILayout.EndHorizontal();
        }
    }
}
