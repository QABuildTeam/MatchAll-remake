using System;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll
{
    public interface IPlayerInput
    {
        Vector2 FieldMovingVelocity { get; }
        event Action<Vector2> FieldPointed;
        event Action GameStopped;
    }
}
