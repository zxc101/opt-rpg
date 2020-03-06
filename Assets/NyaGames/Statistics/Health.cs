namespace NyaGames.Statistics
{
    [System.Serializable]
    public class Health
    {
        public int value;

        public void Add(Health addedVal)
        {
            value += addedVal.value;
        }
    }
}
