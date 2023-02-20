using System;
using Entitas;
using ACFW;
using MatchAll.Settings;
using System.Collections.Generic;

namespace MatchAll.Game
{
    public class SampleSetupSystem : ReactiveSystem<GameEntity>
    {
        private GameContext gameContext;
        private ShapeType[] availableShapeTypes;
        private int[] availableShapeColors;
        private int sampleChangedPenalty;
        public SampleSetupSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
        {
            var settingsManager = environment.Get<ISettingsManager>();
            var shapeSettings = settingsManager.Get<ShapeSettings>();
            availableShapeTypes = shapeSettings.AvailableShapeTypes;
            availableShapeColors = shapeSettings.AvailableShapeColors;
            var sessionSettings = settingsManager.Get<GameSessionSettings>();
            sampleChangedPenalty = sessionSettings.sampleChangedPenalty;

            gameContext = contexts.game;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var r = new Random();
            ShapeType shapeType = availableShapeTypes[r.Next(0, availableShapeTypes.Length)];
            int colorIndex = availableShapeColors[r.Next(0, availableShapeColors.Length)];
            foreach (var entity in entities)
            {
                entity.ReplaceShapeDefinition(new ShapeDefinition { shapeType = shapeType, colorIndex = colorIndex });
                var scoreDelta = gameContext.CreateEntity();
                scoreDelta.AddScoreDelta(-sampleChangedPenalty);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGenerateSample && entity.hasShapeDefinition;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GenerateSample);
        }
    }
}
