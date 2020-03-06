using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using NyaGames.Hero;

namespace NyaGames.UI.Canvases
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GridLayoutGroup))]
    public class Inventary : MonoBehaviour
    {
        [SerializeField] private Elements.CaseInventary item;
        [SerializeField] private SoHero hero;
        [SerializeField] private int stepItems;
        [SerializeField] private int maxItems;

        private List<Elements.CaseInventary>  itemList;
        private int countItems;
                
        private void Awake()
        {
            Init();
            ItemListFilling();
        }

        private void Init()
        {
            itemList = new List<Elements.CaseInventary>();
            countItems = stepItems;
        }

        private void ItemListFilling()
        {
            for (int i = 0; i < stepItems; i++)
            {
                itemList.Add(Instantiate(item, transform));
                itemList[i].SetActive(true);
            }
            for (int i = stepItems; i < maxItems; i++)
            {
                itemList.Add(Instantiate(item, transform));
                itemList[i].SetActive(false);
            }
        }

        public void AddCases()
        {
            int lastItem = countItems + stepItems;
            for (; countItems < lastItem && lastItem <= maxItems; countItems++)
                itemList[countItems].SetActive(true);
        }
    }
}
