using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    public class Characteristics : AStat, IEquipStat
    {
        public int power;
        public int endurance;
        public int agility;
        public int shield;
        public int luck;

        public override void SetData(AStat stat)
        {
            power = ((Characteristics)stat).power;
            endurance = ((Characteristics)stat).endurance;
            agility = ((Characteristics)stat).agility;
            shield = ((Characteristics)stat).shield;
            luck = ((Characteristics)stat).luck;
        }

        public void Add(Characteristics addedVal)
        {
            power += addedVal.power;
            endurance += addedVal.endurance;
            agility += addedVal.agility;
            shield += addedVal.shield;
            luck += addedVal.luck;
        }

        public void Show()
        {
            isUsing = true;
            ShowLabel();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            ShowPower();
            ShowEndurance();
            ShowAgility();
            ShowShield();
            ShowLuck();
            EditorGUILayout.EndVertical();
        }

        private void ShowLabel()
        {
            GUILayout.Label("Характеристики", EditorStyles.boldLabel);
        }

        private void ShowPower()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Сила");
            power = EditorGUILayout.IntSlider(power, 0, 100);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowEndurance()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Выносливость");
            endurance = EditorGUILayout.IntSlider(endurance, 0, 100);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowAgility()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Ловкость");
            agility = EditorGUILayout.IntSlider(agility, 0, 100);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowShield()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Щит");
            shield = EditorGUILayout.IntSlider(shield, 0, 100);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowLuck()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Удача");
            luck = EditorGUILayout.IntSlider(luck, 0, 100);
            EditorGUILayout.EndHorizontal();
        }
    }
}
