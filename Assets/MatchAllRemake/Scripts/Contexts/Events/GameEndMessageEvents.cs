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
        public UEvent<GameEndType> Open;
        public UEvent CloseEndMessage;
    }
}
