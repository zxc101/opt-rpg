using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace AppCreate.Localisation
{
    public class LocalisationEditor : EditorWindow
    {
        public LocalisationData localisedData;

        private bool showDebug;

        [MenuItem("Window/AppCreate/Localisation Editor")]
        static void Init()
        {
            GetWindow(typeof(LocalisationEditor), false, "Localisation", true).Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            GUIHelperACG.ShowHeaderLogo();
            GUILayout.Label("Localisation Editor", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Load or create new lists of keys and values. Make sure " +
                                       "each language you are using has the same set of keys and " +
                                       "the values for each language are the localised items for " +
                                       "that specific audience", GUIHelperACG.GUIMessageStyle);
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
            
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            GUILayout.Label("Add / Modify Language", EditorStyles.boldLabel);
            
            if (localisedData != null)
            {
                SerializedObject serializedObject = new SerializedObject(this);
                SerializedProperty serializedProperty = serializedObject.FindProperty("localisedData");
                EditorGUILayout.PropertyField(serializedProperty, true);
                serializedObject.ApplyModifiedProperties();
            }

            EditorGUILayout.Space();
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Create New Language"))
            {
                CreateNewData();
            }

            if(GUILayout.Button("Clear Values"))
            {
                ClearValues();
            }

            GUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            GUILayout.Label("Data Managment", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();

            if (localisedData != null)
            {
                if(GUILayout.Button("Save Language - JSON"))
                {
                    SaveGameDataJSON();
                }
            }

            if(GUILayout.Button("Load Language - JSON"))
            {
                LoadGameDataJSON();
            }

            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();

            if (localisedData != null)
            {
                if (GUILayout.Button("Save Language - Strings"))
                {
                    SaveGameDataStrings();
                }
            }

            if (GUILayout.Button("Load Language - Strings"))
            {
                LoadGameDataStrings();
            }

            GUILayout.EndHorizontal();
            EditorGUILayout.Space();

            showDebug = EditorGUILayout.Foldout(showDebug, "Debugging");

            if (showDebug)
            {
                if (GUILayout.Button("Clear Language PalyerPref"))
                {
                    ClearPlayerPref();
                }

                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                EditorGUILayout.LabelField("While testing you may need to reset the selected language, you can do this by removing the PlayerPref. Note that this will only affect the language preferences.", GUIHelperACG.GUIMessageStyle);
                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }

        private void LoadGameDataJSON()
        {
            string filePath = EditorUtility.OpenFilePanel("Select localisation data file", Application.streamingAssetsPath, "json");

            if (!string.IsNullOrEmpty(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                localisedData = JsonUtility.FromJson<LocalisationData>(dataAsJson);
            }
        }

        private void SaveGameDataJSON()
        {
            string filePath = EditorUtility.SaveFilePanel("Save localisation data file", Application.streamingAssetsPath, "", "json");

            if (!string.IsNullOrEmpty(filePath))
            {
                string dataAsJson = JsonUtility.ToJson(localisedData);
                File.WriteAllText(filePath, dataAsJson);
            }
        }

        private void LoadGameDataStrings()
        {
            string filePath = EditorUtility.OpenFilePanel("Select localisation data file", Application.streamingAssetsPath, "strings");

            if (!string.IsNullOrEmpty(filePath))
            {
                StreamReader reader = File.OpenText(filePath);
                string line;
                List<LocalisationItem> localisedText = new List<LocalisationItem>();

                while((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("\""))
                    {
                        string[] items = line.Split('"');
                        LocalisationItem item = new LocalisationItem();
                        item.key = items[1];
                        item.value = items[3];
                        localisedText.Add(item);
                    }
                }

                localisedData = new LocalisationData();
                localisedData.items = new LocalisationItem[localisedText.Count];
                localisedData.items = localisedText.ToArray();
            }
        }

        private void SaveGameDataStrings()
        {
            string filePath = EditorUtility.SaveFilePanel("Save localisation data file", Application.streamingAssetsPath, "", "strings");
            if (!string.IsNullOrEmpty(filePath))
            {
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    foreach(LocalisationItem item in localisedData.items)
                    {
                        file.WriteLine(string.Format("\"{0}\" = \"{1}\";", item.key, item.value));
                    }
                }
            }
        }

        private void CreateNewData()
        {
            localisedData = new LocalisationData();
        }

        private void ClearValues()
        {
            foreach(LocalisationItem item in localisedData.items)
            {
                item.value = "";
            }
        }

        private void ClearPlayerPref()
        {
            if (PlayerPrefs.HasKey("ACGLocalisationIndex"))
            {
                PlayerPrefs.DeleteKey("ACGLocalisationIndex");
            }
        }
    }
}
