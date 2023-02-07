using ACFW;
using ACFW.Controllers;
using System.Threading.Tasks;
using MatchAll.Views;
using MatchAll.Environment;
using UnityEngine;

namespace MatchAll.Controllers
{
    public partial class MainMenuUIController : ContextController
    {
        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private UniversalSettingsManager SettingsManager => environment.Get<UniversalSettingsManager>();
        private IData Data => environment.Get<IData>();

        private MainMenuUIView MainMenuView => (MainMenuUIView)view;
        public MainMenuUIController(MainMenuUIView view, UniversalEnvironment environment) : base(view, environment)
        {
        }

        private void OnCurrentPlayerNameAction()
        {
            MainMenuView.ActiveCurrentPlayerName = false;
            MainMenuView.ActivePlayerName = true;
        }
        private void OnPlayerNameChanged(string value)
        {
            MainMenuView.InteractiveStart = !string.IsNullOrEmpty(value);
        }
        private void OnStartAction()
        {
            Data.PlayerName = MainMenuView.PlayerName;
            EventManager.Get<GameScreenEvents>().OpenGameScreen?.Invoke();
        }


        private void Subscribe()
        {
            MainMenuView.CurrentPlayerNameAction += OnCurrentPlayerNameAction;
            MainMenuView.PlayerNameChanged += OnPlayerNameChanged;
            MainMenuView.StartAction += OnStartAction;
        }

        private void Unsubscribe()
        {
            MainMenuView.CurrentPlayerNameAction -= OnCurrentPlayerNameAction;
            MainMenuView.PlayerNameChanged -= OnPlayerNameChanged;
            MainMenuView.StartAction -= OnStartAction;
        }

        public override async Task Open()
        {
            MainMenuView.Environment = environment;
            MainMenuView.CurrentPlayerName = Data.PlayerName;
            MainMenuView.ScoreValue = Data.CurrentScore;
            bool emptyPlayerName = string.IsNullOrEmpty(Data.PlayerName);
            MainMenuView.ActivePlayerName = emptyPlayerName;
            MainMenuView.ActiveCurrentPlayerName = !emptyPlayerName;
            MainMenuView.InteractiveStart = !emptyPlayerName;
            await base.Open();
            Subscribe();
        }

        public override async Task Close()
        {
            Unsubscribe();
            await base.Close();
        }
    }
}
