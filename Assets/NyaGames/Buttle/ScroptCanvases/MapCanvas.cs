using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyaGames
{
    public class MapCanvas : MonoBehaviour
    {
        [SerializeField] private BattleСanvas buttleCanvas;
        [SerializeField] private LootBoxRewardCanvas lootBoxCanvas;
        [SerializeField] private RectTransform menu;
        [SerializeField] private RectTransform characteristics;

        public void MoveToButtle()
        {
            gameObject.SetActive(false);
            buttleCanvas.gameObject.SetActive(true);
        }

        public void MoveToLootBox()
        {
            gameObject.SetActive(false);
            lootBoxCanvas.gameObject.SetActive(true);
        }

        public void OpenCharacteristics()
        {
            characteristics.gameObject.SetActive(true);
        }

        public void Close()
        {
            characteristics.gameObject.SetActive(false);
            menu.gameObject.SetActive(false);
        }

        public void Enter()
        {
            characteristics.gameObject.SetActive(false);
            menu.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menu.gameObject.SetActive(!menu.gameObject.activeInHierarchy);
            }
        }

        private void OnDisable()
        {
            menu.gameObject.SetActive(false);
            characteristics.gameObject.SetActive(false);
        }
    }
}
