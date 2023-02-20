using System;
using ACFW;

namespace MatchAll.Environment
{
    public class GameEndMessageEvents : IEventProvider
    {
        public UEvent OpenWinMessage;
        public UEvent OpenFailMessage;
        public UEvent CloseEndMessage;
    }
}
