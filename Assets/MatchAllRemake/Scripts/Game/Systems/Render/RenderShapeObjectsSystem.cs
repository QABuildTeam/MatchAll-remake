using System;
using Entitas;
using ACFW;
using System.Collections.Generic;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class RenderShapeObjectsSystem : ReactiveSystem<GameEntity>, ITearDownSystem
    {
        private IGameManager gameManager;

        public RenderShapeObjectsSystem(Contexts contexts, UniversalEnvironment environment) : base(contexts.game)
        {
            gameManager = environment.Get<IGameManager>();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                gameManager.CreateShapeObject(entity.shape.shape, entity.color.colorIndex, entity.shapePosition.position.x, entity.shapePosition.position.y);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isNewShapeObject && entity.hasShape && entity.hasColor && entity.hasShapePosition;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.NewShapeObject);
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
