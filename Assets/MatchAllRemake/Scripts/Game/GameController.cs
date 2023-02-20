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
        public void Open(IServiceLocator environment)
        {
            contexts = Contexts.sharedInstance;
            systems = CreateSystems(contexts, environment);
            systems.Initialize();
            isOpen = true;
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
            systems.DeactivateReactiveSystems();
            foreach (var context in contexts.allContexts)
            {
                context.DestroyAllEntities();
            }
            contexts = null;
            systems = null;
        }

        private static Systems CreateSystems(Contexts contexts, IServiceLocator environment)
        {
            return new Feature("Systems")
                .Add(new InitialSystems(contexts, environment))
                .Add(new InputSystems(contexts, environment))
                .Add(new LogicSystems(contexts, environment))
                .Add(new RenderSystems(contexts, environment));
        }
    }
}
