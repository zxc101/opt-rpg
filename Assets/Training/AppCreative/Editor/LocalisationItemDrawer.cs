using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AppCreate.Localisation
{
    [CustomPropertyDrawer(typeof(LocalisationItem))]
    public class LocalisationItemDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var keyRect = new Rect(position.x + 30, position.y, 160, position.height);
            var labelRect = new Rect(position.x + 165, position.y, 60, position.height);
            var valueRect = new Rect(position.x + 205, position.y, 200, position.height);

            EditorGUI.LabelField(position, "Key", "");
            EditorGUI.PropertyField(keyRect, property.FindPropertyRelative("key"), GUIContent.none);
            EditorGUI.LabelField(labelRect, "Value", "");
            EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);

            EditorGUI.EndProperty();
        }
    }
}
