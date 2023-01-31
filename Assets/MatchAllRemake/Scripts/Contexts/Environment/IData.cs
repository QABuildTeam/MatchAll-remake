using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Environment
{
    public interface IData
    {
        string PlayerName { get; set; }
        int CurrentScore { get; set; }
        int MaxScore { get; set; }

    }
}
