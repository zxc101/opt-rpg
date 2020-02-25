using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    [System.Serializable]
    public class Vampire : AStat, IEquipStat
    {
        public int value;

        public override void SetData(AStat stat)
        {
            value = ((Vampire)stat).value;
        }

        public void Add(Vampire addedVal)
        {
            value += addedVal.value;
        }

        public void Show()
        {
            isUsing = true;
            ShowLabel();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            ShowVampireHealing();
            EditorGUILayout.EndVertical();
        }

        private void ShowLabel()
        {
            GUILayout.Label("Вампиризм", EditorStyles.boldLabel);
        }

        private void ShowVampireHealing()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Сила лечения");
            value = EditorGUILayout.IntSlider(value, 0, 100);
            EditorGUILayout.EndHorizontal();
        }

        public static Vampire operator +(Vampire res, Vampire added)
        {
            res.value += added.value;
            return res;
        }
    }
}
