using Entitas;
using ACFW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Game
{
    public class ViewSystems : Feature
    {
        public ViewSystems(Contexts contexts, UniversalEnvironment environment) : base("View systems")
        {
            Add(new CameraMovementSystem(contexts, environment));
            Add(new SampleGenerationCooldownSystem(contexts, environment));
            Add(new ShapeSampleSetupSystem(contexts, environment));
        }
    }
}
