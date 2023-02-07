using Entitas;
using System.Collections;
using System.Collections.Generic;
using ACFW;
using UnityEngine;
using MatchAll.Environment;

namespace MatchAll.Game
{
    public class TimerSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
    {
        private readonly UniversalEnvironment environment;
        private IGameManager gameManager;
        private readonly GameContext gameContext;
        private GameEntity timer;

        public TimerSystem(Contexts contexts, UniversalEnvironment environment)
        {
            this.environment = environment;
            gameContext = contexts.game;
        }

        public void Initialize()
        {
            gameManager = environment.Get<IGameManager>();
            gameContext.isTimer = true;
            timer = gameContext.timerEntity;
            timer.AddRemainingTime(60);
        }

        public void Execute()
        {
            if (timer.isTimerRun)
            {
                var newTime = timer.remainingTime.time - Time.deltaTime;
                if (newTime <= 0)
                {
                    newTime = 0;
                }
                timer.ReplaceRemainingTime(newTime);
                gameManager.RemainingTime = newTime;
            }
        }

        public void TearDown()
        {
            gameContext.isTimer = false;
        }
    }
}
