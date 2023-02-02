using ACFW;
using ACFW.Startup;
using ACFW.Controllers;
using ACFW.Settings;
using MatchAll.Controllers;
using MatchAll.Environment;

namespace MatchAll.Startup
{
    public class MatchAllApplicationContext : ApplicationContext
    {
        public MatchAllApplicationContext(ContextManager contextManager, SettingsList settings, GameContextList gameContextList) : base(contextManager, settings, gameContextList)
        {
        }

        protected override void InitializeGlobals()
        {
            base.InitializeGlobals();
            Environment.Add<IData>(new DataController());
        }

        public override void Run()
        {
            Environment.Get<UniversalEventManager>().Get<MainMenuEvents>().OpenMainMenu?.Invoke();
        }
    }
}
