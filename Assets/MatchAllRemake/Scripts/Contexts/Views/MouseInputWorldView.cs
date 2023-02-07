using UnityEngine;
using ACFW;
using ACFW.Views;
using System.Threading.Tasks;
using System;
using MatchAll.Settings;

namespace MatchAll.Views
{
    public class MouseInputWorldView : WorldView, IPlayerInput
    {
        private Camera worldCamera;
        private Vector2 screenCenter;
        public override Task PreShow()
        {
            worldCamera = Camera.main;
            var canvasManager= Environment.Get<IMasterCanvasManager>();
            screenCenter = new Vector2(canvasManager.ActualScreenWidth, canvasManager.ActualScreenHeight) / 2;
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
                IsFieldPointed = true;
                FieldPointer = pointersInfo[0].currentPosition;
                FieldPointed?.Invoke(worldCamera.ScreenToWorldPoint(pointersInfo[0].currentPosition));
            }
            else
            {
                IsFieldPointed = false;
            }
        }

        private InputSettings InputSettings => Environment?.Get<UniversalSettingsManager>()?.Get<InputSettings>();
        private Vector2 CalculateVelocity(Vector2 position)
        {

            return Vector2.ClampMagnitude((position - screenCenter) * InputSettings.velocityFactor, InputSettings.maxVelocity) * Time.deltaTime;
        }

        public Vector2 CameraMovementVelocity =>
            worldCamera != null && pointersInfo[1].state == MouseButtonState.Down ?
            CalculateVelocity(pointersInfo[0].currentPosition) :
            Vector2.zero;

        public bool IsFieldPointed { get; private set; }
        public Vector2 FieldPointer { get; private set; }

        public event Action<Vector2> FieldPointed;
        public event Action GameStopped;
    }
}
