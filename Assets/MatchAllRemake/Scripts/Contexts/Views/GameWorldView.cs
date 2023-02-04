using UnityEngine;
using ACFW.Views;
using System.Threading.Tasks;

namespace MatchAll.Views
{
    public class GameWorldView : WorldView
    {
        [SerializeField]
        private Transform worldTransform;
        [SerializeField]
        private FieldBackground background;
        
        private Camera worldCamera;

        public override Task PreShow()
        {
            worldCamera = Camera.main;
            worldCamera.transform.position = Vector3.zero;
            return Task.CompletedTask;
        }

        public override Task PostHide()
        {
            worldCamera.transform.position = Vector3.zero;
            worldCamera = null;
            return Task.CompletedTask;
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
                    worldCamera.transform.position = (Vector3)value;
                    background.Position = (Vector3)value;
                }
            }
        }
    }
}
