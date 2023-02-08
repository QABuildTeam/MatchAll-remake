using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACFW;

namespace MatchAll.Controllers
{
    public class MatchAllGameManager : IGameManager, IServiceProvider
    {
        public IPlayerInput PlayerInput { get; set; }
        public Vector2 CameraMovementVelocity => PlayerInput != null ? PlayerInput.CameraMovementVelocity : Vector2.zero;
        public bool IsFieldPointed => PlayerInput != null ? PlayerInput.IsFieldPointed : false;
        public Vector2 FieldPointer => PlayerInput != null ? PlayerInput.FieldPointer : Vector2.zero;

        public ICameraController CameraController { get; set; }
        public Vector2 CameraPosition
        {
            get => CameraController != null ? CameraController.CameraPosition : Vector2.zero;
            set
            {
                if (CameraController != null)
                {
                    CameraController.CameraPosition = value;
                }
            }
        }

        public ITimer Timer { get; set; } = null;
        public float RemainingTime
        {
            get => (float)Timer?.RemainingTime;
            set
            {
                if (Timer != null)
                {
                    Timer.RemainingTime = value;
                }
            }
        }

        public bool IsTimerRunning
        {
            get => (bool)Timer?.IsTimerRunning;
            set
            {
                if (Timer != null)
                {
                    Timer.IsTimerRunning = value;
                }
            }
        }

        public IShapeSample ShapeSample { get; set; }
        public void SetShapeSample(ShapeType shapeType, int colorIndex) => ShapeSample?.SetShapeSample(shapeType, colorIndex);

        public ISessionManager SessionManager { get; set; }
        public void SessionFail() => SessionManager?.SessionFail();
        public void SessionWin() => SessionManager?.SessionWin();

        public IScore ScoreManager { get; set; }
        public int CurrentScore
        {
            get => (int)ScoreManager?.CurrentScore;
            set
            {
                if (ScoreManager != null)
                {
                    ScoreManager.CurrentScore = value;
                }
            }
        }
    }
}
