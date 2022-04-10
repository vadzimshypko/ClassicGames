namespace ClassicGames.PhysicsBall
{
/**
 * Your component implementing this interface must be in GameObject.
 * That GameObject must be child for GameObject containing the GameStageSystem.
*/
    public interface IGameStage
    {
        public void OnGameStarted();
        public void OnGameOver();
        public void OnNewGameInitialized();
    }
}