namespace NyaGames.Statistics
{
    [System.Serializable]
    public class Power
    {
        public int value;

        public void Add(Power addedVal)
        {
            value += addedVal.value;
        }
    }
}
