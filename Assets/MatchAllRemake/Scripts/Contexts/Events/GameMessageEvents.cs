using ACFW;

namespace MatchAll.Environment
{
    public class GameMessageEvents : IEventProvider
    {
        public UEvent CloseHint;
        public UEvent OpenHint;
        public UEvent<int> ShowNextHint;
    }
}
