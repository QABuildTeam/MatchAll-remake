using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll
{
    public interface IGameManager
    {
        // Input controller
        Vector2 CameraMovementVelocity { get; }
        bool IsFieldPointed { get; }
        Vector2 FieldPointer { get; }
        // Camera controller
        Vector2 CameraPosition { get; set; }
        // Timer
        float RemainingTime { get; set; }
        bool IsTimerRunning { get; set; }
        // Shape sample
        void SetShapeSample(ShapeType shapeType, int colorIndex);
        // Finish game
        void SessionWin();
        void SessionFail();
        // Score
        int CurrentScore { get; set; }
        // Shapes display
        void CreateShapeObject(ShapeType shapeType, int colorIndex, int x, int y);
        void SetShapeColor(int x, int y, int colorIndex);
    }
}
