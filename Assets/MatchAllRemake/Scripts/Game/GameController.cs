using Entitas;
using UnityEngine;
using ACFW;
using System.Threading.Tasks;

namespace MatchAll.Game
{
    public class GameController : MonoBehaviour
    {
        private Systems systems;
        private Contexts contexts;
        private bool isOpen = false;
        public void Open(UniversalEnvironment environment)
        {
            contexts = Contexts.sharedInstance;
            systems = CreateSystems(contexts, environment);
            systems.Initialize();
            isOpen = true;
            Debug.Log($"Created systems {systems}");
        }

        void Update()
        {
            if (!isOpen)
            {
                return;
            }
            systems.Execute();
            systems.Cleanup();
        }

        public void Close()
        {
            isOpen = false;
            systems.TearDown();
            contexts = null;
            systems = null;
        }

        private static Systems CreateSystems(Contexts contexts, UniversalEnvironment environment)
        {
            return new Feature("Systems")
                .Add(new ViewSystems(contexts, environment))
                .Add(new InputSystems(contexts, environment));
        }
    }
}
