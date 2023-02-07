using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Settings
{
    [CreateAssetMenu(fileName = nameof( InputSettings), menuName = "Game Settings/Input Settings")]
    public class InputSettings : ScriptableObject
    {
        public float velocityFactor;
        public float maxVelocity;
    }
}
