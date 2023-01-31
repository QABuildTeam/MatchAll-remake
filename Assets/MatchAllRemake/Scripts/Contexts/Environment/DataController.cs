using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIEditorTools.Environment;
using MatchAll.Environment;

namespace MatchAll.Controllers
{
    public class DataController : IData, IServiceProvider
    {
        public string PlayerName { get; set; }
        public int CurrentScore { get; set; }
        public int MaxScore { get; set; }
    }
}
