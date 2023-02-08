namespace MatchAll
{
    public interface ITimer
    {
        public bool IsTimerRunning { get; set; }
        public float RemainingTime { get; set; }
    }
}
