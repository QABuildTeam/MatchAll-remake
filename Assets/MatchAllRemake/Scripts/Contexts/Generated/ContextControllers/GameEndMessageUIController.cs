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
    public partial class GameEndMessageUIController : ContextController
    {
        private IEventManager EventManager => environment.Get<IEventManager>();
        private ISettingsManager SettingsManager => environment.Get<ISettingsManager>();
        private IData Data => environment.Get<IData>();

        private GameEndMessageUIView GameEndMessageView => (GameEndMessageUIView)view;
        public GameEndMessageUIController(GameEndMessageUIView view, IServiceLocator environment) : base(view, environment)
        {
        }

        private void OnDialogAction()
        {
            EventManager.Get<GameEndMessageEvents>().CloseEndMessage?.Invoke();
        }


        private void Subscribe()
        {
            GameEndMessageView.DialogAction += OnDialogAction;
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

        private void Unsubscribe()
        {
            GameEndMessageView.DialogAction -= OnDialogAction;
        }


        public override async Task Open()
        {
            Debug.Log($"Game ended with {Data.GameResult}");
            Subscribe();
            GameEndMessageView.Environment = environment;
            ShowMessage(Data.GameResult);
            await base.Open();
        }

        public override async Task Close()
        {
            Unsubscribe();
            await base.Close();
        }
    }
}
