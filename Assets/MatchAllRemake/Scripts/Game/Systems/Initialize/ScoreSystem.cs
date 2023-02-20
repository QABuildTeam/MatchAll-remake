using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class ScoreSystem : IInitializeSystem, ITearDownSystem
    {
        private GameContext gameContext;
        public ScoreSystem(Contexts contexts, IServiceLocator environment)
        {
            gameContext = contexts.game;
        }
        public void Initialize()
        {
            gameContext.SetScore(0);
        }

        public void TearDown()
        {
            gameContext.RemoveScore();
        }
    }
}
