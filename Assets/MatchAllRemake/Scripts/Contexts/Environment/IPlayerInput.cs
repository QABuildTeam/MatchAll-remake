using System;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll
{
    public interface IPlayerInput
    {
        Vector2 CameraMovementVelocity { get; }
        bool IsFieldPointed { get; }
        Vector2 FieldPointer { get; }
        event Action<Vector2> FieldPointed;
        event Action GameStopped;
    }
}
