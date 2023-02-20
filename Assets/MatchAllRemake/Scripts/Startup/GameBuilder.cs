using UnityEngine;
using ACFW.Startup;
using ACFW;
using MatchAll.Controllers;

namespace MatchAll.Startup
{
    public class GameBuilder : MonoBehaviour, IStartupBuilder
    {
        public void PopulateEnvironment(IServiceLocator environment)
        {
            var gameManager = new MatchAllGameManager();
            environment.Add<IGameContainer>(gameManager);
            environment.Add<IGameManager>(gameManager);
        }
    }
}
