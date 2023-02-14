using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using ACFW;

namespace MatchAll.Controllers
{
    public class DataController : IData, IServiceProvider
    {
        private readonly string playerNameKey = "PlayerName";
        private readonly string playerScoresKey = "PlayerScores";

        private class Scores
        {
            public int currentScore = 0;
            public int maxScore = 0;
        }
        private Dictionary<string, Scores> playerScores = null;
        private Dictionary<string, Scores> PlayerScores
        {
            get
            {
                if (playerScores == null)
                {
                    try
                    {
                        playerScores = JsonConvert.DeserializeObject<Dictionary<string, Scores>>(PlayerPrefs.GetString(playerScoresKey, string.Empty));
                    }
                    catch
                    {
                        playerScores = null;
                    }
                    if (playerScores == null)
                    {
                        playerScores = new Dictionary<string, Scores>();
                    }
                }
                return playerScores;
            }
        }
        private void SaveScores()
        {
            if (playerScores != null)
            {
                PlayerPrefs.SetString(playerScoresKey, JsonConvert.SerializeObject(playerScores));
                PlayerPrefs.Save();
            }
        }
        private string currentPlayerName = null;
        public string PlayerName
        {
            get
            {
                if(string.IsNullOrEmpty(currentPlayerName))
                {
                    currentPlayerName= PlayerPrefs.GetString(playerNameKey, string.Empty);
                }
                return currentPlayerName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!PlayerScores.ContainsKey(value))
                    {
                        PlayerScores.Add(value, new Scores());
                        SaveScores();
                    }
                    PlayerPrefs.SetString(playerNameKey, value);
                    PlayerPrefs.Save();
                    currentPlayerName = value;
                }
            }
        }
        public int CurrentScore
        {
            get
            {
                if (PlayerScores.TryGetValue(PlayerName, out var score))
                {
                    return score.currentScore;
                }
                return 0;
            }
            set
            {
                var scores = PlayerScores[PlayerName];
                scores.currentScore = value;
                if (value > scores.maxScore)
                {
                    scores.maxScore = value;
                }
                SaveScores();
            }
        }
        public int MaxScore
        {
            get
            {
                if (PlayerScores.TryGetValue(PlayerName, out var score))
                {
                    return score.maxScore;
                }
                return 0;
            }
            set { }
        }
    }
}
