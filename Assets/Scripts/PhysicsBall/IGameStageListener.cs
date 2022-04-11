namespace ClassicGames.PhysicsBall
{
    /**
     * All scripts implementing this interface will be subscribed on {@link GameStageSystem} in Awake.
     */
    internal interface IGameStageListener
    {
        void OnGameInitialized();
        void OnGameStarted();
        void OnGameWasOver(int score);
    }
}