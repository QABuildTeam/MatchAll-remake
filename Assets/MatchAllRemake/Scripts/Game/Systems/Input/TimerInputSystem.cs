using Entitas;
using ACFW;

namespace MatchAll.Game
{
    public class TimerInputSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
    {
        private IServiceLocator environment;
        private readonly GameContext gameContext;
        private IGameManager gameManager;

        public TimerInputSystem(Contexts contexts, IServiceLocator environment)
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
            timer.isTimerRunning = gameManager.IsTimerRunning;
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
