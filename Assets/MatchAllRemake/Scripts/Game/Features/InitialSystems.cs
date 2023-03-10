using Entitas;
using ACFW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Game
{
    public class InitialSystems : Feature
    {
        public InitialSystems(Contexts contexts, IServiceLocator environment) : base("Initial systems")
        {
            Add(new TimerSystem(contexts, environment));
            Add(new CameraSystem(contexts, environment));
            Add(new ScoreSystem(contexts, environment));
            Add(new ShapeStatsSystem(contexts, environment));
            Add(new ShapeSampleSystem(contexts, environment));
            Add(new ShapeObjectSystem(contexts, environment));
        }
    }
}
