using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;

namespace AppCreate.Localisation
{
    [CustomEditor(typeof(LocalisationManager))]
    public class LocalisationManagerEditor : Editor
    {
        private ReorderableList langList;

        private void OnEnable()
        {
            langList = new ReorderableList(serializedObject, serializedObject.FindProperty("availableLanguages"), true, false, true, true);
            langList.headerHeight = 0;
            langList.onRemoveCallback += RemoveCallback;
            langList.drawElementCallback += OnDrawCallback;
        }

        private void OnDisable()
        {
            if(langList != null)
            {
                langList.onRemoveCallback -= RemoveCallback;
                langList.drawElementCallback -= OnDrawCallback;
            }
        }

        private void RemoveCallback(ReorderableList list)
        {
            if (EditorUtility.DisplayDialog("Warning!", "Remove localisation item?", "Yes", "No"))
            {
                ReorderableList.defaultBehaviours.DoRemoveButton(list);
            }
        }

        private void OnDrawCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            var item = langList.serializedProperty.GetArrayElementAtIndex(index);

            var labelKeyRect = new Rect(rect.x + 10, rect.y, EditorGUIUtility.currentViewWidth / 4, EditorGUIUtility.singleLineHeight);
            var keyRect = new Rect(rect.x + 52, rect.y, EditorGUIUtility.currentViewWidth / 4, EditorGUIUtility.singleLineHeight);
            var labelRect = new Rect(rect.x + (EditorGUIUtility.currentViewWidth - (EditorGUIUtility.currentViewWidth / 4)) - 120, rect.y, 60, EditorGUIUtility.singleLineHeight);
            var valueRect = new Rect(rect.x + (EditorGUIUtility.currentViewWidth - (EditorGUIUtility.currentViewWidth / 4)) - 55, rect.y, EditorGUIUtility.currentViewWidth / 4, EditorGUIUtility.singleLineHeight);

            EditorGUI.LabelField(rect, index.ToString(), "");
            EditorGUI.LabelField(labelKeyRect, "Name", "");
            EditorGUI.PropertyField(
                keyRect,
                item.FindPropertyRelative("name"),
                GUIContent.none
            );

            EditorGUI.LabelField(labelRect, "File Name", "");
            EditorGUI.PropertyField(
                valueRect,
                item.FindPropertyRelative("fileName"),
                GUIContent.none
            );
        }

        public override void OnInspectorGUI()
        {
            GUIHelperACG.ShowHeaderLogo();
            GUILayout.Label("Localisation Manager", EditorStyles.boldLabel);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("The below list stores available localisations. Please use the localisation editor ('Window' -> 'AppCreative' -> 'Localisation Editor')", GUIHelperACG.GUIMessageStyle);
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            GUILayout.Label("Available Languages", EditorStyles.boldLabel);
            langList.DoLayoutList();
            EditorGUILayout.Space();

            DropAreaGUI();

            if(langList.count == 0)
            {
                EditorGUILayout.HelpBox("You must have atleast 1 language available", MessageType.Error);
            }

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Make sure all language files are in .json or .string format and located in the 'StreamingAssets' folder. \n\n TIP: You cal also drah-n-drop the files in to this window.", GUIHelperACG.GUIMessageStyle);
            EditorGUILayout.EndVertical();

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
        }

        private void DropAreaGUI()
        {
            var e = Event.current.type;

            if(e == EventType.DragUpdated)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
            }
            else if(e == EventType.DragPerform)
            {
                DragAndDrop.AcceptDrag();

                foreach (Object draggedObject in DragAndDrop.objectReferences)
                {
                    if(draggedObject is DefaultAsset)
                    {
                        DefaultAsset asset = draggedObject as DefaultAsset;

                        var script = target as LocalisationManager;
                        LanguageItem newItem = new LanguageItem();
                        newItem.name = asset.name;
                        newItem.fileName = Path.GetFileName(AssetDatabase.GetAssetPath(asset));
                        if(script.availableLanguages == null)
                        {
                            script.availableLanguages = new List<LanguageItem>();
                            script.availableLanguages.Add(newItem);
                        }
                        else
                        {
                            script.availableLanguages.Add(newItem);
                        }
                    }
                }
            }
        }
    }
}
