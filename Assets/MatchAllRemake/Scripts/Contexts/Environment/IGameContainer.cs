using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll
{
    public interface IGameContainer
    {
        // Input
        IPlayerInput PlayerInput { set; }
        ICameraController CameraController { set; }
        ITimerInput TimerInput { set; }
        // Output
        ITimer Timer { set; }
        IShapeSample ShapeSample { set; }
        ISessionManager SessionManager { set; }
        IScore ScoreManager { set; }
        IShapeObjectsDisplay ShapesDisplay { set; }
    }
}
