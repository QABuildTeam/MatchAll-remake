using System.Collections;
using System.Collections.Generic;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll
{
    public interface IGameManager
    {
        #region Input
        // Input controller
        Vector2 CameraMovementVelocity { get; }
        FieldPointer FieldPointer { get; }
        // Timer input
        float DeltaTime { get; }
        bool Running { get; }
        #endregion

        #region Output
        // Camera controller
        Vector2 CameraPosition { set; }
        // Timer
        float RemainingTime { set; }
        bool TimerRunning { set; }
        // Shape sample
        void SetShapeSample(ShapeDefinition shapeDefinition);
        // Finish game
        void SessionWin();
        void SessionFail();
        // Score
        int CurrentScore { set; }
        // Shapes display
        void CreateShapeObject(ShapeDefinition shapeDefinition, Vector2Int position);
        void SetShapeColor(Vector2Int position, int colorIndex);
        void DestroyShapeObject(Vector2Int position);
        #endregion
    }
}
