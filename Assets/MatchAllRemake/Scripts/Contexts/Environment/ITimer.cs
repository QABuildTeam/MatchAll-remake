namespace MatchAll
{
    public interface ITimer
    {
        public bool IsTimerRun { get; set; }
        public float RemainingTime { get; set; }
    }
}
