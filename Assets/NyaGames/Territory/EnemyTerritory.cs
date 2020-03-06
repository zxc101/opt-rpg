using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using NyaGames.Enemy;
using NyaGames.Settings;

namespace NyaGames.Territory
{
    public class EnemyTerritory : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SoEnemy enemy;
        
        private DataHolder dataHolder;

        private void OnEnable()
        {
            dataHolder = FindObjectOfType<DataHolder>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            dataHolder.enemy = enemy;
            SceneManager.LoadScene("Buttle");
        }
    }
}
