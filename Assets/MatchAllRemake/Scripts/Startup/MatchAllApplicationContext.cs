using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIEditorTools;
using UIEditorTools.Controllers;
using UIEditorTools.Settings;
using MatchAll.Environment;
using MatchAll.Controllers;

namespace MatchAll.Startup
{
    public class MatchAllApplicationContext : UIEditorTools.Startup.ApplicationContext
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
