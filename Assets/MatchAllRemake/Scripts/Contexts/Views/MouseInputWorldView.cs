using UnityEngine;
using ACFW.Views;
using System.Threading.Tasks;
using System;

namespace MatchAll.Views
{
    public class MouseInputWorldView : WorldView, IPlayerInput
    {
        private Camera worldCamera;
        public override Task PreShow()
        {
            worldCamera = Camera.main;
            return Task.CompletedTask;
        }

        public override Task PostHide()
        {
            GameStopped = null;
            FieldPointed = null;
            worldCamera = null;
            return base.PostHide();
        }

        private enum MouseButtonState
        {
            Up = 0,
            Pressed = 1,
            Down = 2,
            Released = 3
        };
        private struct MousePointerInfo
        {
            public MouseButtonState state;
            public Vector2 startPosition;
            public Vector2 currentPosition;
        }
        private MousePointerInfo[] pointersInfo = new MousePointerInfo[2];

        private void Update()
        {
            if (worldCamera == null)
            {
                return;
            }
            Vector2 position = Input.mousePosition;
            for (int i = 0; i < 2; ++i)
            {
                pointersInfo[i].currentPosition = position;
                if (Input.GetMouseButtonDown(i))
                {
                    pointersInfo[i].startPosition = position;
                    pointersInfo[i].state = MouseButtonState.Pressed;
                    continue;
                }
                if (Input.GetMouseButton(i))
                {
                    pointersInfo[i].state = MouseButtonState.Down;
                    continue;
                }
                if (Input.GetMouseButtonUp(i))
                {
                    pointersInfo[i].state = MouseButtonState.Released;
                    continue;
                }
                pointersInfo[i].state = MouseButtonState.Up;
            }
            if (pointersInfo[0].state == MouseButtonState.Pressed)
            {
                FieldPointed?.Invoke(worldCamera.ScreenToWorldPoint(pointersInfo[0].currentPosition));
            }
        }

        public Vector2 FieldMovingVelocity =>
            worldCamera != null && pointersInfo[1].state == MouseButtonState.Down ?
            worldCamera.ScreenToWorldPoint(pointersInfo[1].currentPosition) :
            Vector2.zero;
        public event Action<Vector2> FieldPointed;
        public event Action GameStopped;
    }
}
