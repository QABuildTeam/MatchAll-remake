using Entitas;
using ACFW;
using UnityEngine;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class TimeManagementSystem : IExecuteSystem
    {
        private GameContext gameContext;

        public TimeManagementSystem(Contexts contexts, UniversalEnvironment environment)
        {
            gameContext = contexts.game;
        }

        public void Execute()
        {
            var timer = gameContext.timerEntity;
            if (timer.isTimerRunning)
            {
                var newTime = timer.remainingTime.time - Time.deltaTime;
                if (newTime <= 0)
                {
                    newTime = 0;
                    gameContext.isFinishGame = true;
                }
                timer.ReplaceRemainingTime(newTime);
            }
        }
    }
}
