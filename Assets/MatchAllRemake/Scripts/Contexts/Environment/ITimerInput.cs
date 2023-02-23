using System;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll
{
    public interface ITimerInput
    {
        float DeltaTime { get; }
        bool Running { get; }
    }
}
