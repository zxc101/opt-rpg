using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace NyaGames
{
    public class StatsEditor : EditorWindow
    {
        private Data data;
        private EEnemyStat enemyStat;
        private EEquipStat equipChar;
        private float enumStats;
        private ETypeStatObj typeObj;
        private Vector2 scroll;

        [MenuItem("Window/NyaGames/CharacteristicObjectCreater")]
        private static void Init()
        {
            GetWindow(typeof(StatsEditor), false, "CharacteristicObjectCreater", true).Show();
        }

        private void OnEnable()
        {
            data = new Data();
        }

        private void OnGUI()
        {
            scroll = EditorGUILayout.BeginScrollView(scroll);
            EditorGUILayout.Space();
            GUIHelper.ShowHeaderLogo();
            GUILayout.Label("CharacteristicObjectCreater", EditorStyles.boldLabel);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Drag&Drop-ни JSON со статами на панель, чтобы загрузить данные", GUIHelper.GUIMessageStyle);
            EditorGUILayout.EndVertical();

            typeObj = (ETypeStatObj)EditorGUILayout.EnumPopup(typeObj);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            if (typeObj == ETypeStatObj.Enemy)
            {
                enemyStat = (EEnemyStat)EditorGUILayout.EnumFlagsField(GUIContent.none, enemyStat, false);
                enumStats = (int)enemyStat;
            }
            if (typeObj == ETypeStatObj.Equip)
            {
                equipChar = (EEquipStat)EditorGUILayout.EnumFlagsField(GUIContent.none, equipChar, false);
                enumStats = (int)equipChar;
            }

            ShowConstChars();

            ShowClearButton();
            ShowSaveButton();

            EditorGUILayout.EndVertical();

            EditorGUILayout.EndScrollView();

            DropAreaGUI();
        }

        private void ShowConstChars()
        {
            data.DoNotUseAnyChar();

            EEquipStat[] charsIndex = GetChars((int)enumStats);

            if ((int)enumStats == -1)
                data.Show(typeObj);
            else
                for (int i = charsIndex.Length - 1; i >= 0; i--)
                    ((IEquipStat)data.stats[charsIndex[i]]).Show();

        }

        private void ShowClearButton()
        {
            if (GUILayout.Button("Удалить все данные"))
                if (EditorUtility.DisplayDialog("Проверка", "Вы уверены что хотите удалить ВСЕ данные?", "Да", "Нет"))
                    ClearData();
        }

        private void ShowSaveButton()
        {
            if (typeObj == ETypeStatObj.Equip)
                if (GUILayout.Button("Сохранить предмет"))
                    JSON_Manager.SaveEquip(data);

            if (typeObj == ETypeStatObj.Enemy)
                if (GUILayout.Button("Сохранить противника"))
                    JSON_Manager.SaveEnemy(data);
        }

        private EEquipStat[] GetChars(int _enumChar)
        {
            int charIndex;
            List<EEquipStat> enumCharList = new List<EEquipStat>();

            while (_enumChar > 0)
            {
                for (charIndex = 0; Mathf.Pow(2, charIndex + 1) <= _enumChar; charIndex++) { }
                _enumChar -= (int)Mathf.Pow(2, charIndex);
                enumCharList.Add((EEquipStat)(int)Mathf.Pow(2, charIndex));
            }
            return enumCharList.ToArray();
        }

        private void ClearData()
        {
            data = new Data();
        }

        private void DropAreaGUI()
        {
            var e = Event.current.type;

            if (e == EventType.DragUpdated)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
            }
            else if (e == EventType.DragPerform)
            {
                DragAndDrop.AcceptDrag();

                foreach (Object draggedObject in DragAndDrop.objectReferences)
                {
                    if (draggedObject is DefaultAsset)
                    {
                        JSON_Manager.LoadStats(ref data, DragAndDrop.paths[0]);
                        break;
                    }
                }
            }
        }
    }
}
