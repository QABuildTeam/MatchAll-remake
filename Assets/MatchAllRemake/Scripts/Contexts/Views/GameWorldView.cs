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
        private Dictionary<Vector2Int, ObjectLoader<ResolvedShapeObjectDisplay>> objectIndex = new Dictionary<Vector2Int, ObjectLoader<ResolvedShapeObjectDisplay>>();
        public override Task PreShow()
        {
            worldCamera = Camera.main;
            worldCamera.transform.position = new Vector3(0, 0, worldCamera.transform.position.z);
            lock (_sync)
            {
                objectIndex.Clear();
            }
            return Task.CompletedTask;
        }

        public override Task PostHide()
        {
            foreach (var loader in objectIndex.Values)
            {
                loader.Component.Dispose();
                loader.Dispose();
            }
            lock (_sync)
            {
                objectIndex.Clear();
            }
            worldCamera.transform.position = new Vector3(0, 0, worldCamera.transform.position.z);
            worldCamera = null;
            return Task.CompletedTask;
        }

        public override Task Show()
        {
            return base.Show();
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

        public async void CreateShapeObject(ShapeDefinition shapeDefinition, Vector2Int position)
        {
            bool exists;
            lock (_sync)
            {
                exists = objectIndex.ContainsKey(position);
            }
            if (!exists)
            {
                ShapeSettings shapeSettings = Environment.Get<ISettingsManager>().Get<ShapeSettings>();
                GameSessionSettings sessionSettings = Environment.Get<ISettingsManager>().Get<GameSessionSettings>();
                var resolvedShapeObject = ShapeObjectHelper.Resolve(shapeDefinition, shapeSettings);
                var loader = new ObjectLoader<ResolvedShapeObjectDisplay>(shapeSettings.ShapeObjectPrefab, rootTransform);
                if (await loader.Load() != null)
                {
                    var worldPosition = ShapeObjectCellHelper.GetShapeObjectPosition(position, sessionSettings.areaXMin, sessionSettings.areaYMin, sessionSettings.objectSlotStep);
                    loader.LoadedObject.transform.localPosition = new Vector3(worldPosition.x, worldPosition.y, 0);
                    loader.Component.Value = resolvedShapeObject;
                    lock (_sync)
                    {
                        objectIndex.Add(position, loader);
                    }
                }
                else
                {
                    loader.Dispose();
                }
            }
        }

        public void SetShapeColor(Vector2Int position, int colorIndex)
        {
            ObjectLoader<ResolvedShapeObjectDisplay> loader;
            bool exists;
            lock (_sync)
            {
                exists = objectIndex.TryGetValue(position, out loader);
            }
            if (exists)
            {
                loader.Component.Color = Environment.Get<ISettingsManager>().Get<ShapeSettings>().GetShapeColor(colorIndex);
            }
        }

        public void DestroyShapeObject(Vector2Int position)
        {
            ObjectLoader<ResolvedShapeObjectDisplay> loader;
            bool exists;
            lock (_sync)
            {
                exists = objectIndex.TryGetValue(position, out loader);
            }
            if (exists)
            {
                loader.Component.Dispose();
                loader.Dispose();
                lock (_sync)
                {
                    objectIndex.Remove(position);
                }
            }
        }
    }
}
