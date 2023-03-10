using ACFW;
using ACFW.Controllers;
using System.Threading.Tasks;
using MatchAll.Views;
using MatchAll.Environment;
using MatchAll.Settings;
using UnityEngine;

namespace MatchAll.Controllers
{
    public partial class MainMenuUIController : ContextController
    {
        private IEventManager EventManager => environment.Get<IEventManager>();
        private ISettingsManager SettingsManager => environment.Get<ISettingsManager>();
        private IData Data => environment.Get<IData>();

        private MainMenuUIView MainMenuView => (MainMenuUIView)view;
        public MainMenuUIController(MainMenuUIView view, IServiceLocator environment) : base(view, environment)
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
            MainMenuView.ScoreValue = Data.MaxScore;
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
