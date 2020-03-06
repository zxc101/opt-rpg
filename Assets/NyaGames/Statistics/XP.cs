namespace NyaGames.Statistics
{
    [System.Serializable]
    public class XP
    {
        public int charXP;
        public int lvlXP;

        public void Add(XP addedVal)
        {
            charXP += addedVal.charXP;
            lvlXP += addedVal.lvlXP;
        }
    }
}
