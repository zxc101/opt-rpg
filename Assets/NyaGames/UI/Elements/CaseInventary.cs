using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

using NyaGames.Equipment;

namespace NyaGames.UI.Elements
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class CaseInventary : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Sprite unlocked;
        [SerializeField] private Sprite blocked;

        [SerializeField] private Image equip_IMG;
        [SerializeField] private Image destroy_IMG;

        private Image case_IMG;
        private SoEquipment equipment;
        
        private void СonnectionComponents()
        {
            case_IMG = GetComponent<Image>();
        }

        private void Awake()
        {
            СonnectionComponents();
        }

        public void SetActive(bool isActive)
        {
            if (isActive)
                case_IMG.sprite = unlocked;
            else
                case_IMG.sprite = blocked;
        }

        public void SetEquipment()
        {
            equip_IMG.sprite = equipment.identifier.appearance;
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }
    }
}
