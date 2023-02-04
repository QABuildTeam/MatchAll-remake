using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACFW;
using ACFW.Controllers;
using MatchAll.Views;

namespace MatchAll.Controllers
{
    public class MouseInputWorldController : ContextController
    {
        private MouseInputWorldView GameView => (MouseInputWorldView)view;
        public MouseInputWorldController(MouseInputWorldView view, UniversalEnvironment environment) : base(view, environment)
        {
        }
    }
}
