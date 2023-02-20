using UnityEngine;
using ACFW.Settings;

namespace MatchAll.Settings
{
    [CreateAssetMenu(fileName = nameof( InputSettings), menuName = "Game Settings/Input Settings")]
    public class InputSettings : ScriptableSettings
    {
        public float velocityFactor;
        public float maxVelocity;
    }
}
