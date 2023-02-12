using Entitas;
using ACFW;
using UnityEngine;

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
            gameContext.cameraEntity.AddVelocity(0, 0);
            gameContext.cameraEntity.AddCameraPosition(0, 0);
        }
        public void TearDown()
        {
            gameContext.isCamera = false;
        }
    }
}
