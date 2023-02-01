using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIEditorTools;

namespace MatchAll.Environment
{
    public class GameMessageEvents : IEventProvider
    {
        public UEvent Close;
        public UEvent OpenHint;
        public UEvent<int> ShowNextHint;
    }
}
