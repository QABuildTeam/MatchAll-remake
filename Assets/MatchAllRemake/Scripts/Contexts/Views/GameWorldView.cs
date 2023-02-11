using UnityEngine;
using ACFW;
using ACFW.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchAll.Game;
using MatchAll.Settings;

namespace MatchAll.Views
{
    public class GameWorldView : WorldView
    {
        [SerializeField]
        private Transform worldTransform;
        [SerializeField]
        private FieldBackground background;
        [SerializeField]
        private GameController gameController;
        [SerializeField]
        private Transform rootTransform;

        private Camera worldCamera;

        private object _sync = new object();
        private List<ObjectLoader<ResolvedShapeObjectDisplay>> shapeObjects = new List<ObjectLoader<ResolvedShapeObjectDisplay>>();
        private Dictionary<Vector2Int, ResolvedShapeObjectDisplay> objectIndex = new Dictionary<Vector2Int, ResolvedShapeObjectDisplay>();
        public override Task PreShow()
        {
            worldCamera = Camera.main;
            worldCamera.transform.position = new Vector3(0, 0, worldCamera.transform.position.z);
            lock (_sync)
            {
                shapeObjects.Clear();
                objectIndex.Clear();
            }
            return Task.CompletedTask;
        }

        public override Task PostHide()
        {
            foreach (var shapeObject in shapeObjects)
            {
                shapeObject.Component.Dispose();
                shapeObject.Dispose();
            }
            lock (_sync)
            {
                objectIndex.Clear();
                shapeObjects.Clear();
            }
            worldCamera.transform.position = new Vector3(0, 0, worldCamera.transform.position.z);
            worldCamera = null;
            return Task.CompletedTask;
        }

        public override Task Show(bool force = false)
        {
            return base.Show(force);
        }

        public override async Task Hide()
        {
            await base.Hide();
        }

        public Transform WorldTransform => worldTransform;
        public Vector2 CameraPosition
        {
            get
            {
                return worldCamera != null ? worldCamera.transform.position : Vector3.zero;
            }
            set
            {
                if (worldCamera != null)
                {
                    var cameraPosition = (Vector3)value;
                    cameraPosition.z = worldCamera.transform.position.z;
                    worldCamera.transform.position = cameraPosition;
                    background.Position = (Vector3)value;
                }
            }
        }

        public GameController GameController => gameController;

        public async void CreateShapeObject(ShapeType type, int colorIndex, int x, int y)
        {
            var position = new Vector2Int(x, y);
            bool exists;
            lock (_sync)
            {
                exists = objectIndex.ContainsKey(position);
            }
            if (!exists)
            {
                ShapeSettings shapeSettings = Environment.Get<UniversalSettingsManager>().Get<ShapeSettings>();
                var resolvedShapeObject = ShapeObjectHelper.Resolve(new ShapeObject { shapeType = type, colorIndex = colorIndex }, shapeSettings);
                var loader = new ObjectLoader<ResolvedShapeObjectDisplay>(shapeSettings.ShapeObjectPrefab, rootTransform);
                if (await loader.Load() != null)
                {
                    loader.LoadedObject.transform.localPosition = new Vector3(x, y, 0);
                    loader.Component.Value = resolvedShapeObject;
                    lock (_sync)
                    {
                        shapeObjects.Add(loader);
                        objectIndex.Add(position, loader.Component);
                    }
                }
                else
                {
                    loader.Dispose();
                }
            }
        }

        public void SetShapeColor(int x, int y, int colorIndex)
        {
            ResolvedShapeObjectDisplay shapeObjectDisplay;
            bool exists;
            lock (_sync)
            {
                exists = objectIndex.TryGetValue(new Vector2Int(x, y), out shapeObjectDisplay);
            }
            if (exists)
            {
                shapeObjectDisplay.Color = Environment.Get<UniversalSettingsManager>().Get<ShapeSettings>().GetShapeColor(colorIndex);
            }
        }
    }
}
