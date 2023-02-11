using ACFW;
using ACFW.Controllers;
using ACFW.Views;
using System.Threading.Tasks;
using MatchAll.Views;
using MatchAll.Environment;
using MatchAll.Settings;
using UnityEngine;

namespace MatchAll.Controllers
{
    public partial class GameEndMessageUIController : ContextController, ISessionManager
    {
        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private UniversalSettingsManager SettingsManager => environment.Get<UniversalSettingsManager>();
        private IGameContainer GameManager => environment.Get<IGameContainer>();

        private GameEndMessageUIView GameEndMessageView => (GameEndMessageUIView)view;
        public GameEndMessageUIController(GameEndMessageUIView view, UniversalEnvironment environment) : base(view, environment)
        {
        }

        private void OnDialogAction()
        {
            EventManager.Get<GameEndMessageEvents>().CloseEndMessage?.Invoke();
        }


        private void Subscribe()
        {
            GameEndMessageView.DialogAction += OnDialogAction;
            EventManager.Get<GameEndMessageEvents>().OpenWinMessage += OnOpenWinMessage;
            EventManager.Get<GameEndMessageEvents>().OpenFailMessage += OnOpenFailMessage;
            EventManager.Get<GameEndMessageEvents>().CloseEndMessage += OnCloseEndMessage;
        }

        private async void OnOpenWinMessage()
        {
            ShowMessage(GameEndType.Win);
            await GameEndMessageView.Show(force: true);
        }

        private async void OnOpenFailMessage()
        {
            ShowMessage(GameEndType.Fail);
            await GameEndMessageView.Show(force: true);
        }

        private void ShowMessage(GameEndType type)
        {
            string message = SettingsManager.Get<GameEndMessageSettings>().MessageText(type);
            if (!string.IsNullOrEmpty(message))
            {
                GameEndMessageView.DialogMessage = message.Replace("\\n", "\n");
            }
            GameEndMessageView.DialogImage = SettingsManager.Get<GameEndMessageSettings>().ImageReference(type);
            GameEndMessageView.DialogButtonLabel = SettingsManager.Get<GameEndMessageSettings>().ButtonText(type);
        }

        private async void OnCloseEndMessage()
        {
            await GameEndMessageView.Hide();
        }

        private void Unsubscribe()
        {
            GameEndMessageView.DialogAction -= OnDialogAction;
            EventManager.Get<GameEndMessageEvents>().OpenWinMessage -= OnOpenWinMessage;
            EventManager.Get<GameEndMessageEvents>().OpenFailMessage -= OnOpenFailMessage;
            EventManager.Get<GameEndMessageEvents>().CloseEndMessage -= OnCloseEndMessage;
        }


        public override async Task Open()
        {
            Subscribe();
            GameManager.SessionManager = this;
            GameEndMessageView.Environment = environment;
            await base.Open();
        }

        public override async Task Close()
        {
            GameManager.SessionManager = null;
            Unsubscribe();
            await base.Close();
        }

        public void StartSession()
        {
        }

        public void SessionWin()
        {
            EventManager.Get<GameEndMessageEvents>().OpenWinMessage?.Invoke();
        }

        public void SessionFail()
        {
            EventManager.Get<GameEndMessageEvents>().OpenFailMessage?.Invoke();
        }
    }
}
