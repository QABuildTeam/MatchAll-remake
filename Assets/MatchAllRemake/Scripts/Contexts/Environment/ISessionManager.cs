using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll
{
    public interface ISessionManager
    {
        void StartSession();
        void SessionWin();
        void SessionFail();
    }
}
