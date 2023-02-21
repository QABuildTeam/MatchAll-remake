using System;
using System.Linq;
using Entitas;
using ACFW;
using System.Collections.Generic;
using MatchAll.Settings;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll.Game
{
    public class ShapeSetupSystem : ReactiveSystem<GameEntity>, ICleanupSystem, ITearDownSystem
    {
        private GameContext gameContext;

        private int totalMaxObjectsCount;
        private int typeMaxObjectCount;
        private int objectGenRate;
        private ShapeType[] availableShapes;
        private int[] availableColors;

        public ShapeSetupSystem(Contexts contexts, IServiceLocator environment) : base(contexts.game)
        {
            gameContext = contexts.game;

            var settingsManager = environment.Get<ISettingsManager>();
            var sessionSettings = settingsManager.Get<GameSessionSettings>();
            totalMaxObjectsCount = sessionSettings.totalMaxObjectCount;
            typeMaxObjectCount = sessionSettings.typeMaxObjectCount;
            objectGenRate = sessionSettings.objectGenRate;

            var shapeSettings = settingsManager.Get<ShapeSettings>();
            availableShapes = shapeSettings.AvailableShapeTypes;
            availableColors = shapeSettings.AvailableShapeColors;
        }

        private (bool, Vector2Int) GetEmptySpace(GameEntity shapeStatsEntity)
        {
            if (shapeStatsEntity.shapeStats.emptySpaces.Count > 0)
            {
                var index = UnityEngine.Random.Range(0, shapeStatsEntity.shapeStats.emptySpaces.Count);
                var position = shapeStatsEntity.shapeStats.emptySpaces[index];
                return (true, position);
            }
            return (false, new Vector2Int { x = 0, y = 0 });
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var r = new System.Random();
            var shapeStatsEntity = gameContext.shapeStatsEntity;
            var currentAvailableShapeTypes = availableShapes.ToList();
            foreach (var entity in entities)
            {
                var totalObjectsCount = shapeStatsEntity.shapeStats.shapeObjectsCount;
                var objectsToGenerate = Math.Min(totalMaxObjectsCount - totalObjectsCount, objectGenRate);
                for (int i = 0; i < objectsToGenerate; ++i)
                {
                    var (hasEmptySpace, emptySpace) = GetEmptySpace(shapeStatsEntity);
                    if (hasEmptySpace)
                    {
                        var typeIndex = r.Next(0, currentAvailableShapeTypes.Count);
                        var type = currentAvailableShapeTypes[typeIndex];
                        if (shapeStatsEntity.shapeStats.shapeCount[type] < typeMaxObjectCount)
                        {
                            var color = availableColors[r.Next(0, availableColors.Length)];
                            var shape = gameContext.CreateEntity();
                            shape.AddShapeDefinition(new ShapeDefinition { shapeType = type, colorIndex = color });
                            shape.AddShapePosition(new Vector2Int { x = emptySpace.x, y = emptySpace.y });
                            shape.isCreateShapeObject = true;
                        }
                        else
                        {
                            currentAvailableShapeTypes.RemoveAt(typeIndex);
                            if (currentAvailableShapeTypes.Count > 0)
                            {
                                --i;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
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

        public void Cleanup()
        {
            if (gameContext.isGenerateShapes)
            {
                gameContext.isGenerateShapes = false;
            }
        }

        public void TearDown()
        {
            availableShapes = null;
            availableColors = null;
        }
    }
}
