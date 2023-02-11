using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll
{
    public interface IGameContainer
    {
        IPlayerInput PlayerInput { get; set; }
        ICameraController CameraController { get; set; }
        ITimer Timer { get; set; }
        IShapeSample ShapeSample { get; set; }
        ISessionManager SessionManager { get; set; }
        IScore ScoreManager { get; set; }
        IShapeObjectsDisplay ShapesDisplay { get; set; }
    }
}
