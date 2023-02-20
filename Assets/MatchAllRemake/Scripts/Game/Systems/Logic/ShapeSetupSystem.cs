using System;
using Entitas;
using ACFW;
using System.Collections.Generic;
using MatchAll.Settings;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll.Game
{
    public class ShapeSetupSystem : ReactiveSystem<GameEntity>, ITearDownSystem
    {
        private List<Vector2Int> emptySpaces;

        private int totalMaxObjectsCount;
        private int typeMaxObjectCount;
        private int objectGenRate;
        private ShapeType[] availableShapes;
        private int[] availableColors;
        private GameContext gameContext;
        private IGroup<GameEntity> shapeObjects;

        public ShapeSetupSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
        {
            gameContext = contexts.game;
            shapeObjects = gameContext.GetGroup(GameMatcher.ShapePosition);

            var settingsManager = environment.Get<ISettingsManager>();
            var sessionSettings = settingsManager.Get<GameSessionSettings>();
            totalMaxObjectsCount = sessionSettings.totalMaxObjectCount;
            typeMaxObjectCount = sessionSettings.typeMaxObjectCount;
            objectGenRate = sessionSettings.objectGenRate;

            var shapeSettings = settingsManager.Get<ShapeSettings>();
            availableShapes = shapeSettings.AvailableShapeTypes;
            availableColors = shapeSettings.AvailableShapeColors;

            var xIntCount = (int)(sessionSettings.areaWidth / sessionSettings.objectSlotStep) + 1;
            var yIntCount = (int)(sessionSettings.areaHeight / sessionSettings.objectSlotStep) + 1;
            emptySpaces = new List<Vector2Int>(xIntCount * yIntCount);
            var position = new Vector2Int { x = 0, y = 0 };
            for (position.y = 0; position.y < yIntCount; ++position.y)
            {
                for (position.x = 0; position.x<xIntCount; ++position.x)
                {
                    emptySpaces.Add(position);
                }
            }
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
            var r = new System.Random();
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
                        shape.AddShapeDefinition(new ShapeDefinition { shapeType = type, colorIndex = color });
                        shape.AddShapePosition(new Vector2Int { x = emptySpace.x, y = emptySpace.y });
                        shape.isCreateShapeObject = true;
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

        public void TearDown()
        {
            emptySpaces.Clear();
            emptySpaces = null;
            availableShapes = null;
            availableColors = null;
            gameContext = null;
            shapeObjects = null;
        }
    }
}
