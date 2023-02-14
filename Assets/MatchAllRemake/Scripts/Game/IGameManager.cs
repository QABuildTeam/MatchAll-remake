using System.Collections;
using System.Collections.Generic;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

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
        void SetShapeSample(ShapeDefinition shapeDefinition);
        // Finish game
        void SessionWin();
        void SessionFail();
        // Score
        int CurrentScore { get; set; }
        // Shapes display
        void CreateShapeObject(ShapeDefinition shapeDefinition, Vector2Int position);
        void SetShapeColor(Vector2Int position, int colorIndex);
        void DestroyShapeObject(Vector2Int position);
    }
}
