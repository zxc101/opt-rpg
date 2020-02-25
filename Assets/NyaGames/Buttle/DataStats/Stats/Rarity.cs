using UnityEngine;
using UnityEditor;

namespace NyaGames
{
    [System.Serializable]
    public class Rarity : AStat, IEquipStat
    {
        public ELootBoxLVL lootBoxLVL;
        public ERarity rarity;
        public int percent;

        public override void SetData(AStat stat)
        {
            lootBoxLVL = ((Rarity)stat).lootBoxLVL;
            rarity = ((Rarity)stat).rarity;
            percent = ((Rarity)stat).percent;
        }

        public void Show()
        {
            isUsing = true;
            ShowLabel();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            ShowBoxLVL();
            ShowRarity();
            ShowPercent();
            EditorGUILayout.EndVertical();
        }

        private void ShowLabel()
        {
            GUILayout.Label("Редкость", EditorStyles.boldLabel);
        }

        private void ShowRarity()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Редкость предмета");
            rarity = (ERarity)EditorGUILayout.EnumPopup(rarity);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowBoxLVL()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Редкость сундука");
            lootBoxLVL = (ELootBoxLVL)EditorGUILayout.EnumPopup(lootBoxLVL);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowPercent()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Процент шанса получить предмет");
            percent = EditorGUILayout.IntSlider(percent, 0, 100);
            EditorGUILayout.EndHorizontal();
        }
    }
}
