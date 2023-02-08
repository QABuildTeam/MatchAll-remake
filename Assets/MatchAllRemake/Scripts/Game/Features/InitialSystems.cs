using Entitas;
using ACFW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Game
{
    public class InitialSystems : Feature
    {
        public InitialSystems(Contexts contexts, UniversalEnvironment environment) : base("Initial systems")
        {
            Add(new TimerSystem(contexts, environment));
            Add(new ScoreSystem(contexts, environment));
            Add(new FinishGameSystem(contexts, environment));
        }
    }
}
