using UnityEngine;
using ACFW.Startup;
using ACFW;
using MatchAll.Environment;

namespace MatchAll.Startup
{
    public class GameRunner : MonoBehaviour, IStartupRunner
    {
        public void Run(IServiceLocator environment)
        {
            environment.Get<IEventManager>().Get<MainMenuEvents>().OpenMainMenu?.Invoke();
        }
    }
}
