using Entitas;
using ACFW;
using MatchAll.Settings;

namespace MatchAll.Game
{
    public class CommandInputSystem : IExecuteSystem, ICleanupSystem, ITearDownSystem
    {
        private readonly GameContext gameContext;
        private IGameManager gameManager;
        private float areaXMin;
        private float areaYMin;
        private float objectSlotStep;

        public CommandInputSystem(Contexts contexts, UniversalEnvironment environment)
        {
            gameContext = contexts.game;
            gameManager = environment.Get<IGameManager>();
            var settings = environment.Get<UniversalSettingsManager>().Get<GameSessionSettings>();
            areaXMin = settings.areaXMin;
            areaYMin = settings.areaYMin;
            objectSlotStep = settings.objectSlotStep;
        }

        public void Execute()
        {
            if (gameContext.timerEntity.isTimerRunning)
            {
                var cameraEntity = gameContext.cameraEntity;
                var velocity = gameManager.CameraMovementVelocity;
                cameraEntity.ReplaceVelocity(velocity.x, velocity.y);
                if (gameManager.IsFieldPointed == true)
                {
                    var fieldPosition = gameManager.FieldPointer;
                    var position = ShapeObjectCellHelper.GetShapeObjectIndex(fieldPosition.x, fieldPosition.y, areaXMin, areaYMin, objectSlotStep);
                    UnityEngine.Debug.Log($"Pointing at ({fieldPosition.x},{fieldPosition.y}), cameraPosition=({cameraEntity.cameraPosition.x},{cameraEntity.cameraPosition.y}), index ({position.x},{position.y})");
                    gameContext.SetShapeObjectPoint(position);
                }
            }
        }

        public void Cleanup()
        {
            if (gameContext.hasShapeObjectPoint)
            {
                UnityEngine.Debug.Log($"Removing ShapeObjectPoint ({gameContext.shapeObjectPoint.position.x},{gameContext.shapeObjectPoint.position.y})");
                gameContext.RemoveShapeObjectPoint();
            }
        }

        public void TearDown()
        {
            gameManager = null;
        }
    }
}
