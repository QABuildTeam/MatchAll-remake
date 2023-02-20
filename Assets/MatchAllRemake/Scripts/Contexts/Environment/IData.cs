namespace MatchAll
{
    public interface IData
    {
        string PlayerName { get; set; }
        int CurrentScore { get; set; }
        int MaxScore { get; }
        GameEndType GameResult { get; set; }

    }
}
