using ACFW;
using ACFW.Controllers;

namespace MatchAll.Startup
{
    public class MatchAllStartup : ACFW.Startup.Startup
    {
        protected override IApplicationContext CreateApplicationContext()
        {
            var contextManagerInstance = Instantiate(contextManager, transform).GetComponent<ContextManager>();
            return new MatchAllApplicationContext(contextManagerInstance, settings, gameContextList);
        }
    }
}
