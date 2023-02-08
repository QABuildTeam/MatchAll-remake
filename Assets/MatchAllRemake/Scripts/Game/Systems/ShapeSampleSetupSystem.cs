using System;
using System.Linq;
using Entitas;
using ACFW;
using MatchAll.Environment;
using MatchAll.Settings;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Game
{
    public class ShapeSampleSetupSystem : ReactiveSystem<GameEntity>, ITearDownSystem
    {
        private UniversalEnvironment environment;
        private IGameManager gameManager;
        private ShapeSettings shapeSettings;
        private ShapeType[] availableShapeTypes;
        private int[] availableShapeColors;
        public ShapeSampleSetupSystem(Contexts contexts, UniversalEnvironment environment) : base(contexts.game)
        {
            this.environment = environment;
            shapeSettings = environment.Get<UniversalSettingsManager>().Get<ShapeSettings>();
            gameManager = environment.Get<IGameManager>();
            availableShapeTypes = shapeSettings.ShapeTypes.Where(v => v != ShapeType.None).ToArray();
            availableShapeColors = shapeSettings.ShapeColors.Where(v => v != 0).ToArray();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            ShapeType shapeType = availableShapeTypes[UnityEngine.Random.Range(0, availableShapeTypes.Length)];
            int colorIndex = availableShapeColors[UnityEngine.Random.Range(0, availableShapeColors.Length)];
            foreach (var entity in entities)
            {
                entity.ReplaceShape(shapeType);
                entity.ReplaceColor(colorIndex);
                gameManager.SetShapeSample(shapeType, colorIndex);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGenerateShapes && entity.hasShape && entity.hasColor;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GenerateShapes);
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
