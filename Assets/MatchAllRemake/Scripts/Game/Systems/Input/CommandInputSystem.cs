using Entitas;
using ACFW;
using MatchAll.Settings;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll.Game
{
    public class CommandInputSystem : IExecuteSystem, ICleanupSystem, ITearDownSystem
    {
        private readonly GameContext gameContext;
        private IGameManager gameManager;
        private float areaXMin;
        private float areaYMin;
        private float objectSlotStep;

        public CommandInputSystem(Contexts contexts, IServiceLocator environment)
        {
            gameContext = contexts.game;
            gameManager = environment.Get<IGameManager>();
            var settings = environment.Get<ISettingsManager>().Get<GameSessionSettings>();
            areaXMin = settings.areaXMin;
            areaYMin = settings.areaYMin;
            objectSlotStep = settings.objectSlotStep;
        }

        public void Execute()
        {
            var cameraEntity = gameContext.cameraEntity;
            if (gameContext.timerEntity.isTimerRunning)
            {
                var velocity = gameManager.CameraMovementVelocity;
                cameraEntity.ReplaceVelocity(velocity);
                if (gameManager.IsFieldPointed == true)
                {
                    var position = ShapeObjectCellHelper.GetShapeObjectIndex(gameManager.FieldPointer, areaXMin, areaYMin, objectSlotStep);
                    gameContext.SetShapeObjectPoint(position);
                }
            }
            else
            {
                cameraEntity.ReplaceVelocity(Vector2.zero);
            }
        }

        public void Cleanup()
        {
            if (gameContext.hasShapeObjectPoint)
            {
                gameContext.RemoveShapeObjectPoint();
            }
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
