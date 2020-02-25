using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AppCreate
{
    public class GUIHelperACG
    {
        #region Skinning
        private static bool IsDarkSkin { get => EditorPrefs.GetInt("UsetSkin") == 1; }
        #endregion

        #region Styling
        public static GUIStyle GUIMessageStyle
        {
            get
            {
                var messageStyle = new GUIStyle(GUI.skin.label);
                messageStyle.wordWrap = true;

                return messageStyle;
            }
        }
        #endregion

        #region Layout
        public static void ShowHeaderLogo()
        {
            Texture tex = Resources.Load<Texture>("Sprites/HeaderLogo") as Texture;
            var rect = GUILayoutUtility.GetRect(0f, 0f);
            rect.width = tex.width;
            rect.height = tex.height;
            GUILayout.Space(rect.height);
            GUI.DrawTexture(rect, tex);

            var e = Event.current;
            if (e.type != EventType.MouseUp) return;
            if (!rect.Contains(e.mousePosition)) return;
        }
        #endregion
    }
}
