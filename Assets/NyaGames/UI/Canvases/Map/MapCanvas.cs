using UnityEngine;

using NyaGames.Hero;
using NyaGames.Settings;

namespace NyaGames.UI.Canvases
{
    public class MapCanvas : MonoBehaviour
    {
        [SerializeField] private RectTransform menu;
        [SerializeField] private RectTransform characteristics;

        [SerializeField] private SoHero hero;

        public void OpenCharacteristics()
        {
            characteristics.gameObject.SetActive(true);
        }

        public void Close_Characteristics()
        {
            characteristics.gameObject.SetActive(false);
            menu.gameObject.SetActive(false);
        }

        private void Start()
        {
            //hero.ClearCharacteristics();
            Debug.Log($"Hero RegenPercent: {hero.RegenPercent}");
            Debug.Log($"Hero Count Inventary: {hero.inventary.Count}");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menu.gameObject.SetActive(!menu.gameObject.activeInHierarchy);
            }
        }
    }
}
