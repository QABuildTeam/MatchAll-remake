using Entitas;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll.Game
{
    [Game]
    public sealed class VelocityComponent : IComponent
    {
        public Vector2 velocity;
    }
}
