namespace MatchAll
{
    public interface ITimer
    {
        public bool TimerRunning { set; }
        public float RemainingTime { set; }
    }
}
