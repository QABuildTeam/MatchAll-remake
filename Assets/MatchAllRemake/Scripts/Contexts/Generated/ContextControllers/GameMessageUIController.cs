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
    public partial class GameMessageUIController : ContextController
    {
        private IEventManager EventManager => environment.Get<IEventManager>();
        private ISettingsManager SettingsManager => environment.Get<ISettingsManager>();

        private GameMessageUIView GameMessageView => (GameMessageUIView)view;
        public GameMessageUIController(GameMessageUIView view, IServiceLocator environment) : base(view, environment)
        {
        }

        private void OnDialogAction()
        {
            ++currentHint;
            EventManager.Get<GameMessageEvents>().ShowNextHint?.Invoke(currentHint);
        }


        private void Subscribe()
        {
            GameMessageView.DialogAction += OnDialogAction;
            EventManager.Get<GameMessageEvents>().ShowNextHint += OnShowNextHint;
        }

        private int currentHint = 0;

        private void SetHint(int hintOrder)
        {
            string message = SettingsManager.Get<GameHintSettings>().MessageText(hintOrder);
            if (!string.IsNullOrEmpty(message))
            {
                GameMessageView.DialogMessage = message.Replace("\\n", "\n");
            }
            GameMessageView.DialogImage = SettingsManager.Get<GameHintSettings>().ImageReference(hintOrder);
            GameMessageView.DialogButtonLabel = SettingsManager.Get<GameHintSettings>().ButtonText(hintOrder);
        }

        private void OnShowNextHint(int hintOrder)
        {
            if (currentHint < SettingsManager.Get<GameHintSettings>().HintCount)
            {
                SetHint(hintOrder);
            }
            else
            {
                EventManager.Get<GameMessageEvents>().CloseHint?.Invoke();
            }
        }

        private void Unsubscribe()
        {
            GameMessageView.DialogAction -= OnDialogAction;
            EventManager.Get<GameMessageEvents>().ShowNextHint -= OnShowNextHint;
        }


        public override async Task Open()
        {
            Subscribe();
            GameMessageView.Environment = environment;
            currentHint = 0;
            EventManager.Get<GameMessageEvents>().ShowNextHint?.Invoke(currentHint);
            await base.Open();
        }

        public override async Task Close()
        {
            Unsubscribe();
            await base.Close();
        }
    }
}
