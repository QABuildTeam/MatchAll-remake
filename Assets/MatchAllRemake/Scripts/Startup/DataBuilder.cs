using UnityEngine;
using ACFW.Startup;
using ACFW;
using MatchAll.Controllers;

namespace MatchAll.Startup
{
    public class DataBuilder : MonoBehaviour, IStartupBuilder
    {
        public void PopulateEnvironment(IServiceLocator environment)
        {
            environment.Add<IData>(new DataController());
        }
    }
}
