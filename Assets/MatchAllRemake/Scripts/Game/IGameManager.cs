using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll
{
    public interface IGameManager
    {
        // Input controller
        IPlayerInput PlayerInput { get; set; }
        // Input methods
        Vector2 CameraMovementVelocity { get; }
        bool IsFieldPointed { get; }
        Vector2 FieldPointer { get; }

        // Camera controller
        ICameraController CameraController { get; set; }
        // Camera methods
        Vector2 CameraPosition { get; set; }

        // Timer
        ITimer Timer { get; set; }
        float RemainingTime { get; set; }
        bool IsTimerRunning { get; set; }

        // Shape sample
        IShapeSample ShapeSample { get; set; }
        void SetShapeSample(ShapeType shapeType, int colorIndex);

        // Finish game
        ISessionManager SessionManager { get; set; }
        void SessionWin();
        void SessionFail();

        // Score
        IScore ScoreManager { get; set; }
        int CurrentScore { get; set; }
    }
}
