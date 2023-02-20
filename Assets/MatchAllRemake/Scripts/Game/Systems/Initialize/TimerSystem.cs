using Entitas;
using ACFW;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class TimerSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly GameContext gameContext;
        private readonly float sessionPeriod;
        public TimerSystem(Contexts contexts, IServiceLocator environment)
        {
            gameContext = contexts.game;
            sessionPeriod = environment.Get<ISettingsManager>().Get<GameSessionSettings>().sessionDuration;
        }

        public void Initialize()
        {
            gameContext.isTimer = true;
            gameContext.timerEntity.AddRemainingTime(sessionPeriod);
        }
        public void TearDown()
        {
            gameContext.isTimer = false;
        }
    }
}
