using Entitas;
using ACFW;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Game
{
    public class RenderDestroyObjectsSystem : ReactiveSystem<GameEntity>, ITearDownSystem
    {
        private IGameManager gameManager;

        public RenderDestroyObjectsSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
        {
            gameManager = environment.Get<IGameManager>();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                Debug.Log($"Send to destroy entity {entity.shapeDefinition.definition} at {entity.shapePosition.position}");
                gameManager.DestroyShapeObject(entity.shapePosition.position);
                entity.Destroy();
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroyShapeObject;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DestroyShapeObject);
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
