using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACFW;
using ACFW.Controllers;
using MatchAll.Views;

namespace MatchAll.Controllers
{
    public class GameWorldController : ContextController
    {
        private GameWorldView GameView => (GameWorldView)view;
        public GameWorldController(GameWorldView view, UniversalEnvironment environment) : base(view, environment)
        {

        }

        public void SetCameraPosition(Vector2 position)
        {
            GameView.CameraPosition = position;
        }

        public void AttachObject(GameObject go, Vector3 position)
        {
            go.transform.SetParent(GameView.WorldTransform);
            go.transform.position = position;
            go.SetActive(true);
        }

        public void DetachObject(GameObject go)
        {
            go.SetActive(false);
            go.transform.SetParent(null);
        }
    }
}
