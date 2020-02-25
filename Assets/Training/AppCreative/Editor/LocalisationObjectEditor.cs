using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

namespace AppCreate.Localisation
{
    [CustomEditor(typeof(LocaliseObject))]
    public class LocalisationObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.Space();
            GUIHelperACG.ShowHeaderLogo();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Insert the key and tick on the relevant components on this game object you would like to be affected.", GUIHelperACG.GUIMessageStyle);
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            DrawDefaultInspector();

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }
    }
}
#endif
