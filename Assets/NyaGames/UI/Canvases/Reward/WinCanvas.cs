namespace NyaGames.UI.Canvases
{
    public class WinCanvas : ARewardCanvas
    {
        private void OnEnable()
        {
            rewards = dataHolder.enemy.rewards;
            DoOnEnable();
        }
    }
}
