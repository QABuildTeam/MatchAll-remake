using UIEditorTools.Controllers;
using UIEditorTools.Startup;

namespace MatchAll.Startup
{
    public class MatchAllStartup : UIEditorTools.Startup.Startup
    {
        protected override IApplicationContext CreateApplicationContext()
        {
            var contextManagerInstance = Instantiate(contextManager, transform).GetComponent<ContextManager>();
            return new MatchAllApplicationContext(contextManagerInstance, settings, gameContextList);
        }
    }
}
