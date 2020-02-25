using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AppCreate.Localisation
{
    public class LocaliseObject : MonoBehaviour
    {
        [Header("Localisation")]
        public string key;
        [Header("Affected Components")]
        public bool textUI;
        public bool buttonUI;
        public bool imageUI;
        public bool texture2D;
        [Header("Modifiers")]
        public bool useButtonToSetLocale;
        public int localisionIndex;
        public bool goToNextSceneOnClick;
        public string nextSceneName;

        private void Start()
        {
            SetLocalisedObject();
        }

        public void SetLocalisedObject()
        {
            if (textUI)
            {
                Text comp = GetComponent<Text>();
                comp.text = LocalisationManager.instance.GetLocalisedValue(key);
            }
            if(buttonUI && !useButtonToSetLocale)
            {
                Text comp = transform.GetChild(0).GetComponent<Text>();
                comp.text = LocalisationManager.instance.GetLocalisedValue(key);
            }
            if(buttonUI && useButtonToSetLocale)
            {
                Text comp = transform.GetChild(0).GetComponent<Text>();
                comp.text = LocalisationManager.instance.availableLanguages[localisionIndex].name;
                Button btn = GetComponent<Button>();
                btn.onClick.AddListener(() => LocalisationManager.instance.LoadLocalisedText(LocalisationManager.instance.availableLanguages[localisionIndex].fileName));
                btn.onClick.AddListener(() => LocalisationManager.instance.SaveDefault(localisionIndex));
                if (goToNextSceneOnClick)
                {
                    if (PlayerPrefs.HasKey("ACGLocalisationIndex"))
                    {
                        LocalisationManager.instance.LoadDefault();
                        SceneManager.LoadScene(nextSceneName);
                    }
                    else
                    {
                        btn.onClick.AddListener(() => SceneManager.LoadScene(nextSceneName));
                    }
                }
            }
            if (imageUI)
            {
                Image comp = GetComponent<Image>();
                comp.sprite = (Sprite)Resources.Load(LocalisationManager.instance.GetLocalisedValue(key));
            }
            if (texture2D)
            {
                Texture2D comp = GetComponent<Texture2D>();
                comp = (Texture2D)Resources.Load(LocalisationManager.instance.GetLocalisedValue(key));
            }
        }
    }
}
