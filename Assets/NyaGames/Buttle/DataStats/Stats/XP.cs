using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    public class XP : AStat, IEnemyStat
    {
        public int charXP;
        public int lvlXP;

        public override void SetData(AStat stat)
        {
            charXP = ((XP)stat).charXP;
            lvlXP = ((XP)stat).lvlXP;
        }

        public void Add(XP addedVal)
        {
            charXP += addedVal.charXP;
            lvlXP += addedVal.lvlXP;
        }

        public void Show()
        {
            isUsing = true;
            ShowLabel();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            ShowCharXP();
            ShowLvlXP();
            EditorGUILayout.EndVertical();
        }

        private void ShowLabel()
        {
            GUILayout.Label("XP", EditorStyles.boldLabel);
        }

        private void ShowCharXP()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("ХР персонажу");
            charXP = EditorGUILayout.IntField(charXP);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowLvlXP()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("ХР LVL-у");
            lvlXP = EditorGUILayout.IntField(lvlXP);
            EditorGUILayout.EndHorizontal();
        }
    }
}
