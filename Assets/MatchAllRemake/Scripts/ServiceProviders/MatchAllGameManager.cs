#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif
using ACFW;

namespace MatchAll.Controllers
{
    public class MatchAllGameManager : IGameContainer, IGameManager, IServiceProvider
    {
        public IPlayerInput PlayerInput { private get; set; }
        public Vector2 CameraMovementVelocity => PlayerInput != null ? PlayerInput.CameraMovementVelocity : Vector2.zero;
        public FieldPointer FieldPointer => PlayerInput != null ? PlayerInput.FieldPointer : new FieldPointer();

        public ITimerInput TimerInput { private get;  set; }
        public float DeltaTime => TimerInput != null ? TimerInput.DeltaTime : 0;
        public bool Running => TimerInput != null ? TimerInput.Running : false;

        public ICameraController CameraController { get; set; }
        public Vector2 CameraPosition
        {
            set
            {
                if (CameraController != null)
                {
                    CameraController.CameraPosition = value;
                }
            }
        }

        public ITimer Timer { private get; set; }
        public float RemainingTime
        {
            set
            {
                if (Timer != null)
                {
                    Timer.RemainingTime = value;
                }
            }
        }

        public bool TimerRunning
        {
            set
            {
                if (Timer != null)
                {
                    Timer.TimerRunning = value;
                }
            }
        }

        public IShapeSample ShapeSample { private get; set; }
        public void SetShapeSample(ShapeDefinition shapeDefinition) => ShapeSample?.SetShapeSample(shapeDefinition);

        public ISessionManager SessionManager { private get; set; }
        public void SessionFail() => SessionManager?.SessionFail();
        public void SessionWin() => SessionManager?.SessionWin();

        public IScore ScoreManager { private get; set; }
        public int CurrentScore
        {
            set
            {
                if (ScoreManager != null)
                {
                    ScoreManager.CurrentScore = value;
                }
            }
        }

        public IShapeObjectsDisplay ShapesDisplay { private get; set; }
        public void CreateShapeObject(ShapeDefinition shapeDefinition, Vector2Int position) => ShapesDisplay?.CreateShapeObject(shapeDefinition, position);
        public void SetShapeColor(Vector2Int position, int colorIndex) => ShapesDisplay?.SetShapeColor(position, colorIndex);
        public void DestroyShapeObject(Vector2Int position) => ShapesDisplay?.DestroyShapeObject(position);
    }
}
