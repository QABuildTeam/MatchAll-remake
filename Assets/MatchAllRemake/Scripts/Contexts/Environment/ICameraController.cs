using System.Collections;
using System.Collections.Generic;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll
{
    public interface ICameraController
    {
        Vector2 CameraPosition { get; set; }
    }
}
