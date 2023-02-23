using Entitas;
using System.Collections.Generic;
using ACFW;
using MatchAll.Settings;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll.Game
{
    public class ShapeStatsSystem : IInitializeSystem, ITearDownSystem
    {
        private ShapeType[] shapeTypes;
        private float areaWidth;
        private float areaHeight;
        private float objectSlotStep;
        private GameContext gameContext;
        private IGroup<GameEntity> shapeGroup;
        public ShapeStatsSystem(Contexts contexts, IServiceLocator environment)
        {
            gameContext = contexts.game;
            var sessionSettings = environment.Get<ISettingsManager>().Get<GameSessionSettings>();
            areaWidth = sessionSettings.areaWidth;
            areaHeight = sessionSettings.areaHeight;
            objectSlotStep = sessionSettings.objectSlotStep;

            shapeTypes = environment.Get<ISettingsManager>().Get<ShapeSettings>().AvailableShapeTypes;
            shapeGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.ShapeDefinition, GameMatcher.ShapePosition));
        }

        public void Initialize()
        {
            var xIntCount = (int)(areaWidth / objectSlotStep) + 1;
            var yIntCount = (int)(areaHeight / objectSlotStep) + 1;
            gameContext.SetShapeStats(0, new Dictionary<ShapeType, int>(shapeTypes.Length), new List<Vector2Int>(xIntCount * yIntCount));
            foreach (var shapeType in shapeTypes)
            {
                gameContext.shapeStatsEntity.shapeStats.shapeCount[shapeType] = 0;
            }
            var position = Vector2Int.zero;
            for (position.y = 0; position.y < yIntCount; ++position.y)
            {
                for (position.x = 0; position.x < xIntCount; ++position.x)
                {
                    gameContext.shapeStatsEntity.shapeStats.emptySpaces.Add(position);
                }
            }
            shapeGroup.OnEntityAdded += OnEntityAdded;
            shapeGroup.OnEntityRemoved += OnEntityRemoved;
        }

        private void OnEntityAdded(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
        {
            if (entity.hasShapeDefinition && entity.hasShapePosition)
            {
                ++gameContext.shapeStatsEntity.shapeStats.shapeObjectsCount;
                ++gameContext.shapeStatsEntity.shapeStats.shapeCount[entity.shapeDefinition.definition.shapeType];
                gameContext.shapeStatsEntity.shapeStats.emptySpaces.Remove(entity.shapePosition.position);
            }
        }

        private void OnEntityRemoved(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
        {
            if (entity.hasShapeDefinition && entity.hasShapePosition)
            {
                --gameContext.shapeStatsEntity.shapeStats.shapeObjectsCount;
                --gameContext.shapeStatsEntity.shapeStats.shapeCount[entity.shapeDefinition.definition.shapeType];
                gameContext.shapeStatsEntity.shapeStats.emptySpaces.Add(entity.shapePosition.position);
            }
        }

        public void TearDown()
        {
            shapeGroup.OnEntityAdded -= OnEntityAdded;
            shapeGroup.OnEntityRemoved -= OnEntityRemoved;
        }
    }
}
