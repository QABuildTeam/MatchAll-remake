using UnityEngine;
using ACFW;
using ACFW.Views;
using System.Threading.Tasks;
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
                fieldPointer.IsPointed = true;
                fieldPointer.Pointer = worldCamera.ScreenToWorldPoint(pointersInfo[0].currentPosition);
            }
            else
            {
                fieldPointer.IsPointed = false;
            }
        }

        private InputSettings InputSettings => Environment?.Get<ISettingsManager>()?.Get<InputSettings>();
        private Vector2 CalculateVelocity(Vector2 position)
        {
            return Vector2.ClampMagnitude((position - screenCenter) * InputSettings.velocityFactor, InputSettings.maxVelocity) * Time.deltaTime;
        }

        public Vector2 CameraMovementVelocity =>
            worldCamera != null && pointersInfo[1].state == MouseButtonState.Down ?
            CalculateVelocity(pointersInfo[0].currentPosition) :
            Vector2.zero;

        public FieldPointer fieldPointer = new FieldPointer { IsPointed = false, Pointer = Vector2.zero };
        public FieldPointer FieldPointer => fieldPointer;
    }
}
