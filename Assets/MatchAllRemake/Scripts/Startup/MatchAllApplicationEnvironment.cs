using ACFW;
using ACFW.Startup;
using ACFW.Controllers;
using ACFW.Settings;
using MatchAll.Controllers;
using MatchAll.Environment;

namespace MatchAll.Startup
{
    public class MatchAllApplicationEnvironment : ApplicationEnvironment
    {
        public MatchAllApplicationEnvironment(ContextManager contextManager, SettingsList settings, AppContextList appContextList) : base(contextManager, settings, appContextList)
        {
        }

        protected override void InitializeGlobals()
        {
            base.InitializeGlobals();
            Environment.Add<IData>(new DataController());
            var gameManager = new MatchAllGameManager();
            Environment.Add<IGameContainer>(gameManager);
            Environment.Add<IGameManager>(gameManager);
        }

        public override void Run()
        {
            Environment.Get<UniversalEventManager>().Get<MainMenuEvents>().OpenMainMenu?.Invoke();
        }
    }
}
