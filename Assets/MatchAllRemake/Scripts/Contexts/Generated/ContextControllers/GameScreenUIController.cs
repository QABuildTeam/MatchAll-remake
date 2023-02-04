using ACFW;
using ACFW.Controllers;
using System.Threading.Tasks;
using MatchAll.Views;
using MatchAll.Environment;

namespace MatchAll.Controllers
{
    public partial class GameScreenUIController : ContextController
    {
        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private UniversalSettingsManager SettingsManager => environment.Get<UniversalSettingsManager>();
        private IData Data => environment.Get<IData>();

        private GameScreenUIView GameScreenView => (GameScreenUIView)view;
        public GameScreenUIController(GameScreenUIView view, UniversalEnvironment environment) : base(view, environment)
        {
        }

        private void OnBackAction()
        {
            EventManager.Get<MainMenuEvents>().OpenMainMenu?.Invoke();
        }


        private void Subscribe()
        {
            GameScreenView.BackAction += OnBackAction;

        }

        private void Unsubscribe()
        {
            GameScreenView.BackAction -= OnBackAction;

        }


        public override async Task Open()
        {
            GameScreenView.Environment = environment;
            await base.Open();
            Subscribe();
            if (Data.CurrentScore <= 0)
            {
                EventManager.Get<GameMessageEvents>().OpenHint?.Invoke();
            }
        }

        public override async Task Close()
        {
            Unsubscribe();
            await base.Close();
        }
    }
}
