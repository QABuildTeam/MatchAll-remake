using Entitas;
using ACFW;
using MatchAll.Settings;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Game
{
    public class FinishGameSystem : ReactiveSystem<GameEntity>, ITearDownSystem
    {
        private IGameManager gameManager;
        private GameContext gameContext;
        private int winScore;
        public FinishGameSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
        {
            var settings = environment.Get<ISettingsManager>().Get<GameSessionSettings>();
            gameManager = environment.Get<IGameManager>();
            winScore = settings.winScore;
            gameContext = contexts.game;
        }

        public void TearDown()
        {
            gameManager = null;
            gameContext = null;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var score = gameContext.scoreEntity.score.currentScore;
            if (score >= winScore)
            {
                gameManager.SessionWin();
            }
            else
            {
                gameManager.SessionFail();
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isFinishGame;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.FinishGame);
        }
    }
}
