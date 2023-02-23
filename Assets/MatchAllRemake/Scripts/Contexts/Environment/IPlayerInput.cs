using System;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll
{
    public struct FieldPointer
    {
        public bool IsPointed { get; set; }
        public Vector2 Pointer { get; set; }
    }
    public interface IPlayerInput
    {
        Vector2 CameraMovementVelocity { get; }
        FieldPointer FieldPointer { get; }
    }
}
