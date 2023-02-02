using ACFW;

namespace MatchAll.Environment
{
    public class GameMessageEvents : IEventProvider
    {
        public UEvent Close;
        public UEvent OpenHint;
        public UEvent<int> ShowNextHint;
    }
}
