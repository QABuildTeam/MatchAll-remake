using Entitas;
using System.Linq;
using System.Collections.Generic;
using ACFW;

namespace MatchAll.Game
{
    public class RemoveTypeAndColorSystem : ReactiveSystem<GameEntity>, ICleanupSystem
    {
        private GameContext gameContext;
        public RemoveTypeAndColorSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
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
            return entity.hasRemoveTypeAndColor;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.RemoveTypeAndColor);
        }

        public void Cleanup()
        {
            if (gameContext.hasRemoveTypeAndColor)
            {
                gameContext.RemoveRemoveTypeAndColor();
            }
        }
    }
}
