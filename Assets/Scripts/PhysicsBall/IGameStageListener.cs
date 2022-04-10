namespace ClassicGames.PhysicsBall
{
    internal interface IGameStageListener
    {
        void OnGameInitialized();
        void OnGameStarted();
        void OnGameWasOver(int score);
    }
}