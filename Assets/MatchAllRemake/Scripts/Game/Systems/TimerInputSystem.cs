using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class TimerInputSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
    {
        private UniversalEnvironment environment;
        private readonly GameContext gameContext;
        private IGameManager gameManager;

        public TimerInputSystem(Contexts contexts, UniversalEnvironment environment)
        {
            this.environment = environment;
            gameContext = contexts.game;
        }

        public void Initialize()
        {
            gameManager = environment.Get<IGameManager>();
        }

        public void Execute()
        {
            var timer = gameContext.timerEntity;
            timer.isTimerRun = gameManager.IsTimerRun;
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
