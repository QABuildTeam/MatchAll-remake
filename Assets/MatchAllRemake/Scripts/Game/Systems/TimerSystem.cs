using Entitas;
using ACFW;
using UnityEngine;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class TimerSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
    {
        private UniversalEnvironment environment;
        private IGameManager gameManager;
        private GameContext gameContext;
        private GameEntity timer;
        private readonly float sessionPeriod;

        public TimerSystem(Contexts contexts, UniversalEnvironment environment)
        {
            this.environment = environment;
            sessionPeriod = environment.Get<UniversalSettingsManager>().Get<GameSessionSettings>().sessionDuration;
            gameContext = contexts.game;
        }

        public void Initialize()
        {
            gameManager = environment.Get<IGameManager>();
            gameContext.isTimer = true;
            gameContext.isFinishGame = false;
            timer = gameContext.timerEntity;
            timer.AddRemainingTime(sessionPeriod);
        }

        public void Execute()
        {
            if (timer.isTimerRunning)
            {
                var newTime = timer.remainingTime.time - Time.deltaTime;
                if (newTime <= 0)
                {
                    newTime = 0;
                    gameContext.isFinishGame = true;
                }
                timer.ReplaceRemainingTime(newTime);
                gameManager.RemainingTime = newTime;
            }
        }

        public void TearDown()
        {
            gameContext.isTimer = false;
            timer = null;
            gameManager = null;
            gameContext = null;
            environment = null;
        }
    }
}
