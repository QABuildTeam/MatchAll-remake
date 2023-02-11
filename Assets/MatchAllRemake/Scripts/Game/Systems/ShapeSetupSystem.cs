using System;
using Entitas;
using ACFW;
using System.Collections.Generic;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class ShapeSetupSystem : ReactiveSystem<GameEntity>, IInitializeSystem, ITearDownSystem
    {
        private struct Vector2Int
        {
            public float x;
            public float y;
        }
        private List<Vector2Int> emptySpaces;
        private UniversalEnvironment environment;
        private int totalMaxObjectsCount;
        private int typeMaxObjectCount;
        private int objectGenRate;
        private ShapeType[] availableShapes;
        private int[] availableColors;
        private IGameManager gameManager;
        private GameContext gameContext;
        private IGroup<GameEntity> shapeObjects;
        private int totalSlotsCount;

        public ShapeSetupSystem(Contexts contexts, UniversalEnvironment environment) : base(contexts.game)
        {
            this.environment = environment;
            gameManager = environment.Get<IGameManager>();
            gameContext = contexts.game;
            shapeObjects = gameContext.GetGroup(GameMatcher.ShapePosition);
        }

        private (bool, Vector2Int) GetEmptySpace()
        {
            if (emptySpaces.Count > 0)
            {
                var index = UnityEngine.Random.Range(0, emptySpaces.Count);
                var position = emptySpaces[index];
                emptySpaces.RemoveAt(index);
                return (true, position);
            }
            return (false, new Vector2Int { x = 0, y = 0 });
        }
        protected override void Execute(List<GameEntity> entities)
        {
            var r = new Random();
            foreach (var entity in entities)
            {
                var totalObjectsCount = shapeObjects.count;
                var objectsToGenerate = Math.Min(totalMaxObjectsCount - totalObjectsCount, objectGenRate);
                for (int i = 0; i < objectsToGenerate; ++i)
                {
                    var (hasEmptySpace, emptySpace) = GetEmptySpace();
                    if (hasEmptySpace)
                    {
                        var color = availableColors[r.Next(0, availableColors.Length)];
                        var type = availableShapes[r.Next(0, availableShapes.Length)];
                        var shape = gameContext.CreateEntity();
                        shape.AddShape(type);
                        shape.AddColor(color);
                        shape.AddShapePosition((int)emptySpace.x, (int)emptySpace.y);
                        gameManager.CreateShapeObject(type, color, (int)emptySpace.x, (int)emptySpace.y);
                    }
                }
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGenerateShapes;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GenerateShapes);
        }

        public void Initialize()
        {
            var settingsManager = environment.Get<UniversalSettingsManager>();
            var sessionSettings = settingsManager.Get<GameSessionSettings>();
            totalMaxObjectsCount = sessionSettings.totalMaxObjectCount;
            typeMaxObjectCount = sessionSettings.typeMaxObjectCount;
            objectGenRate = sessionSettings.objectGenRate;
            totalSlotsCount = ((int)(sessionSettings.areaWidth / sessionSettings.objectSlotStep) + 1) * ((int)(sessionSettings.areaHeight / sessionSettings.objectSlotStep) + 1);
            emptySpaces = new List<Vector2Int>(totalSlotsCount);
            for (float y = sessionSettings.areaYMin, h = 0; h <= sessionSettings.areaHeight; y += sessionSettings.objectSlotStep, h += sessionSettings.objectSlotStep)
            {
                for (float x = sessionSettings.areaXMin, w = 0; w < sessionSettings.areaWidth; x += sessionSettings.objectSlotStep, w += sessionSettings.objectSlotStep)
                {
                    emptySpaces.Add(new Vector2Int { x = x, y = y });
                }
            }
            var shapeSettings = settingsManager.Get<ShapeSettings>();
            availableShapes = shapeSettings.AvailableShapeTypes;
            availableColors = shapeSettings.AvailableShapeColors;
        }

        public void TearDown()
        {
            /*
            foreach (var entity in shapeObjects.GetEntities())
            {
                entity.Destroy();
            }
            */
            emptySpaces.Clear();
            emptySpaces = null;
            availableShapes = null;
            availableColors = null;
            gameManager = null;
            gameContext = null;
            shapeObjects = null;
            environment = null;
        }
    }
}
