using Entitas;
using ACFW;
using UnityEngine;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class RenderTimerSystem : IExecuteSystem
    {
        private IGameManager gameManager;
        private GameContext gameContext;

        public RenderTimerSystem(Contexts contexts, UniversalEnvironment environment)
        {
            gameManager = environment.Get<IGameManager>();
            gameContext = contexts.game;
        }

        public void Execute()
        {
            if (gameContext.timerEntity.isTimerRunning)
            {
                gameManager.RemainingTime = gameContext.timerEntity.remainingTime.time;
            }
        }
    }
}
