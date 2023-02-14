using Entitas;
using Entitas.CodeGeneration.Attributes;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll.Game
{
    [Game, Unique, Cleanup(CleanupMode.DestroyEntity)]
    public class RepaintNeightboursComponent : IComponent
    {
        public Vector2Int centerPosition;
        public int colorIndex;
    }
}
