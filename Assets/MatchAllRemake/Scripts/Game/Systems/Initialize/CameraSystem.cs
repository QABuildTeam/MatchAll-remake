using Entitas;
using ACFW;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace MatchAll.Game
{
    public class CameraSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly GameContext gameContext;
        public CameraSystem(Contexts contexts, UniversalEnvironment environment)
        {
            gameContext = contexts.game;
        }

        public void Initialize()
        {
            gameContext.isCamera = true;
            gameContext.cameraEntity.AddVelocity(Vector2.zero);
            gameContext.cameraEntity.AddCameraPosition(Vector2.zero);
        }
        public void TearDown()
        {
            gameContext.isCamera = false;
        }
    }
}
