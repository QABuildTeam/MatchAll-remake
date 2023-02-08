using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Settings
{
    [CreateAssetMenu(fileName = nameof(GameSessionSettings), menuName = "Game Settings/Game Session Settings")]
    public class GameSessionSettings : ScriptableObject
    {
        // timing
        public float sessionDuration = 60;
        public float objectGenerationPeriod = 1;
        public float sampleGenerationPeriod = 5;
        // score
        public int winScore = 2000;
        public int matchScoreBonus = 200;
        public int mismatchScorePenalty = 50;
        public int sampleChangedPenalty = 50;
    }
}
