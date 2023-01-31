using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        public override void Initialize()
        {
            base.Initialize();
            Environment.Add<IData>(new DataController());
        }
    }
}
