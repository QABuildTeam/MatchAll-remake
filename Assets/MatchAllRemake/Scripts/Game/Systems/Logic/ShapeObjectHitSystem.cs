using Entitas;
using System.Collections.Generic;
using ACFW;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class ShapeObjectHitSystem : ReactiveSystem<GameEntity>
    {
        private GameContext gameContext;
        private int matchScoreBonus;
        private int mismatchScorePenalty;
        public ShapeObjectHitSystem(Contexts contexts, UniversalEnvironment environment) : base(contexts.game)
        {
            gameContext = contexts.game;
            var settings = environment.Get<UniversalSettingsManager>().Get<GameSessionSettings>();
            matchScoreBonus = settings.matchScoreBonus;
            mismatchScorePenalty = settings.mismatchScorePenalty;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var shapeSampleEntity = gameContext.shapeSampleEntity;
            foreach (var entity in entities)
            {
                UnityEngine.Debug.Log($"Checking pointer at ({entity.shapeObjectPoint.position.x},{entity.shapeObjectPoint.position.y})");
                var targets = gameContext.GetEntitiesWithShapePosition(entity.shapeObjectPoint.position);
                UnityEngine.Debug.Log($"Found {targets.Count} entities at ({entity.shapeObjectPoint.position.x},{entity.shapeObjectPoint.position.y})");
                if (targets.Count == 1)
                {
                    foreach (var target in targets)
                    {
                        if (target.hasShapePosition && target.hasShape && target.hasColor)
                        {
                            UnityEngine.Debug.Log($"Pointed to entity at ({target.shapePosition.position.x},{target.shapePosition.position.y})");
                            var scoreDelta = gameContext.CreateEntity();
                            if (target.shape.shape == shapeSampleEntity.shape.shape && target.color.colorIndex == shapeSampleEntity.color.colorIndex)
                            {
                                UnityEngine.Debug.Log($"Entity matches: ({target.shape.shape},{target.color.colorIndex})");
                                scoreDelta.AddScoreDelta(matchScoreBonus);
                            }
                            else
                            {
                                UnityEngine.Debug.Log($"Entity does not match: ({target.shape.shape},{target.color.colorIndex})");
                                scoreDelta.AddScoreDelta(-mismatchScorePenalty);
                            }
                        }
                    }
                }
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasShapeObjectPoint;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ShapeObjectPoint);
        }
    }
}
