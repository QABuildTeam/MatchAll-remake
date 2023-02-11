using System;
using ACFW;

namespace MatchAll.Environment
{
    [Serializable]
    public enum GameEndType
    {
        Win = 0,
        Fail = 1
    }
    public class GameEndMessageEvents : IEventProvider
    {
        public UEvent OpenWinMessage;
        public UEvent OpenFailMessage;
        public UEvent CloseEndMessage;
    }
}
