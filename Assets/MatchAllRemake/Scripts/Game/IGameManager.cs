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
    }
}
