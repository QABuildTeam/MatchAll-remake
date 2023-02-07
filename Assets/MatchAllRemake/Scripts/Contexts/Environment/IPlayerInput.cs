using System;
using System.Collections.Generic;
using UnityEngine;

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
