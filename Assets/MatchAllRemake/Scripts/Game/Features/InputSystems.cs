using Entitas;
using ACFW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Game
{
    public class InputSystems : Feature
    {
        public InputSystems(Contexts contexts, IServiceLocator environment) : base("Input systems")
        {
            Add(new TimerInputSystem(contexts, environment));
            Add(new CommandInputSystem(contexts, environment));
        }
    }
}
