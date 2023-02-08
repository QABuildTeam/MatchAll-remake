using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class ScoreSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
    {
        private IGameManager gameManager;
        private GameContext gameContext;
        private GameEntity scoreEntity;
        public ScoreSystem(Contexts contexts, UniversalEnvironment environment)
        {
            gameManager = environment.Get<IGameManager>();
            gameContext = contexts.game;
        }
        public void Initialize()
        {
            gameContext.SetScore(0);
            scoreEntity = gameContext.scoreEntity;
            gameManager.CurrentScore = 0;
        }

        public void Execute()
        {
            gameManager.CurrentScore = scoreEntity.score.currentScore;
        }

        public void TearDown()
        {
            gameContext.RemoveScore();
        }
    }
}
