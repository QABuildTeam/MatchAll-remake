using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Settings
{
    [CreateAssetMenu(fileName = nameof(GameSessionSettings), menuName = "Game Settings/Game Session Settings")]
    public class GameSessionSettings : ScriptableObject
    {
        // timing
        [Header("Timings")]
        [Tooltip("An overall duration of the game session")]
        public float sessionDuration = 60;
        [Tooltip("A period of time between consecutive object generations")]
        public float objectGenerationPeriod = 1;
        [Tooltip("A period of time between consecutive sample changes")]
        public float sampleGenerationPeriod = 5;
        // score
        [Header("Scores")]
        [Tooltip("A player wins if they score at least this amount of points")]
        public int winScore = 2000;
        [Tooltip("A score bonus for every matching the shape sample")]
        public int matchScoreBonus = 200;
        [Tooltip("A score penalty for each mismatching the shape sample")]
        public int mismatchScorePenalty = 50;
        [Tooltip("A score penalty for each change of the shape sample")]
        public int sampleChangedPenalty = 50;
        // Shape generation
        [Header("Shape generation")]
        [Tooltip("Maximum total amount of objects of any shape and color on the game field")]
        public int totalMaxObjectCount = 1000;
        [Tooltip("Maximum total amount of objects of any specific shape on the game field")]
        public int typeMaxObjectCount = 350;
        [Tooltip("An amount of objects of any shape and color which are generated at one object generation")]
        public int objectGenRate = 20;
        [Tooltip("Area coordinates")]
        public float areaXMin = -20;
        public float areaYMin = -20;
        public float areaWidth = 40;
        public float areaHeight = 40;
        [Tooltip("Shape slots step (v- or h-wise)")]
        public float objectSlotStep = 1;
    }
}
