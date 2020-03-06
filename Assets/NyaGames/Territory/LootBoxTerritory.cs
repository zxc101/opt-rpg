using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using NyaGames.Settings;
using NyaGames.LootBox;

namespace NyaGames.Territory
{
    public class LootBoxTerritory : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SoLootBox lootBox;

        private DataHolder dataHolder;
        
        private void OnEnable()
        {
            dataHolder = FindObjectOfType<DataHolder>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            dataHolder.lootBox = lootBox;
            SceneManager.LoadScene("LootBox");
        }
    }
}
