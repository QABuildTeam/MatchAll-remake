using Entitas;
using ACFW;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Game
{
    public class RenderCreateObjectsSystem : ReactiveSystem<GameEntity>, ITearDownSystem
    {
        private IGameManager gameManager;

        public RenderCreateObjectsSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
        {
            gameManager = environment.Get<IGameManager>();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                gameManager.CreateShapeObject(entity.shapeDefinition.definition, entity.shapePosition.position);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isCreateShapeObject;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CreateShapeObject);
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
