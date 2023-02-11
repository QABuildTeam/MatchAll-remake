using System;
using Entitas;
using ACFW;
using MatchAll.Settings;
using System.Collections.Generic;

namespace MatchAll.Game
{
    public class SampleSetupSystem : ReactiveSystem<GameEntity>, IInitializeSystem, ITearDownSystem
    {
        private UniversalEnvironment environment;
        private IGameManager gameManager;
        private ShapeType[] availableShapeTypes;
        private int[] availableShapeColors;
        public SampleSetupSystem(Contexts contexts, UniversalEnvironment environment) : base(contexts.game)
        {
            this.environment = environment;
            gameManager = environment.Get<IGameManager>();
        }

        public void Initialize()
        {
            var shapeSettings = environment.Get<UniversalSettingsManager>().Get<ShapeSettings>();
            availableShapeTypes = shapeSettings.AvailableShapeTypes;
            availableShapeColors = shapeSettings.AvailableShapeColors;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var r = new Random();
            ShapeType shapeType = availableShapeTypes[r.Next(0, availableShapeTypes.Length)];
            int colorIndex = availableShapeColors[r.Next(0, availableShapeColors.Length)];
            foreach (var entity in entities)
            {
                entity.ReplaceShape(shapeType);
                entity.ReplaceColor(colorIndex);
                gameManager.SetShapeSample(shapeType, colorIndex);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGenerateSample && entity.hasShape && entity.hasColor;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GenerateSample);
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
