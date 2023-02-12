using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class RenderScoreSystem : IExecuteSystem
    {
        private IGameManager gameManager;
        private GameContext gameContext;
        public RenderScoreSystem(Contexts contexts, UniversalEnvironment environment)
        {
            gameManager = environment.Get<IGameManager>();
            gameContext = contexts.game;
        }

        public void Execute()
        {
            gameManager.CurrentScore = gameContext.scoreEntity.score.currentScore;
        }
    }
}
