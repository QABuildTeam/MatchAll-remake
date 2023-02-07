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
    }
}
