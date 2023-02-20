using Entitas;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACFW;

namespace MatchAll.Game
{
    public class RemoveObjectsOfColorAndTypeSystem : ReactiveSystem<GameEntity>
    {
        private GameContext gameContext;
        public RemoveObjectsOfColorAndTypeSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
        {
            gameContext = contexts.game;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var removeDef in entities)
            {
                foreach (var entity in gameContext.GetEntitiesWithShapeDefinition(removeDef.removeTypeAndColor.shapeDefinition).ToList())
                {
                    if (entity.hasShapePosition)
                    {
                        entity.isDestroyShapeObject = true;
                    }
                }
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.RemoveTypeAndColor);
        }
    }
}
