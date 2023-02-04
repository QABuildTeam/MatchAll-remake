using ACFW;
using ACFW.Controllers;
using ACFW.Startup;

namespace MatchAll.Startup
{
    public class MatchAllStartup : ApplicationStartup
    {
        protected override IApplicationEnvironment CreateApplicationEnvironment()
        {
            var contextManagerInstance = Instantiate(contextManager, transform).GetComponent<ContextManager>();
            return new MatchAllApplicationEnvironment(contextManagerInstance, settings, appContextList);
        }
    }
}
