using Entitas;
using System.Collections.Generic;
using ACFW;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class ShapeObjectHitSystem : ReactiveSystem<GameEntity>, ICleanupSystem
    {
        private GameContext gameContext;
        private int matchScoreBonus;
        private int mismatchScorePenalty;
        public ShapeObjectHitSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
        {
            gameContext = contexts.game;
            var settings = environment.Get<ISettingsManager>().Get<GameSessionSettings>();
            matchScoreBonus = settings.matchScoreBonus;
            mismatchScorePenalty = settings.mismatchScorePenalty;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var shapeSampleEntity = gameContext.shapeSampleEntity;
            foreach (var entity in entities)
            {
                var targets = gameContext.GetEntitiesWithShapePosition(entity.shapeObjectPoint.position);
                if (targets.Count == 1)
                {
                    foreach (var target in targets)
                    {
                        if (target.hasShapePosition && target.hasShapeDefinition)
                        {
                            var scoreDelta = gameContext.CreateEntity();
                            if (target.shapeDefinition.definition == shapeSampleEntity.shapeDefinition.definition)
                            {
                                UnityEngine.Debug.Log($"Entity matches: ({target.shapeDefinition.definition.shapeType},{target.shapeDefinition.definition.colorIndex})");
                                scoreDelta.AddScoreDelta(matchScoreBonus);
                                gameContext.SetRemoveTypeAndColor(target.shapeDefinition.definition);
                                gameContext.SetRepaintNeightbours(target.shapePosition.position, target.shapeDefinition.definition.colorIndex);
                            }
                            else
                            {
                                UnityEngine.Debug.Log($"Entity does not match: ({target.shapeDefinition.definition.shapeType},{target.shapeDefinition.definition.colorIndex})");
                                scoreDelta.AddScoreDelta(-mismatchScorePenalty);
                                gameContext.SetRepaintTypeAndColor(target.shapeDefinition.definition);
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

        public void Cleanup()
        {
            if (gameContext.hasShapeObjectPoint)
            {
                gameContext.RemoveShapeObjectPoint();
            }
        }
    }
}
