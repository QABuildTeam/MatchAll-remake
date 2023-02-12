using Entitas;
using System.Collections.Generic;
using ACFW;

namespace MatchAll.Game
{
    public class ScoreManagementSystem : ReactiveSystem<GameEntity>
    {
        private GameContext gameContext;
        public ScoreManagementSystem(Contexts contexts, UniversalEnvironment environment) : base(contexts.game)
        {
            gameContext = contexts.game;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var scoreEntity = gameContext.scoreEntity;
            foreach (var entity in entities)
            {
                scoreEntity.ReplaceScore(scoreEntity.score.currentScore + entity.scoreDelta.scoreDelta);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasScoreDelta;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ScoreDelta);
        }
    }
}
