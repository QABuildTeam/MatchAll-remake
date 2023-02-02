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
        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private UniversalSettingsManager SettingsManager => environment.Get<UniversalSettingsManager>();

        private GameMessageUIView GameMessageView => (GameMessageUIView)view;
        public GameMessageUIController(GameMessageUIView view, UniversalEnvironment environment) : base(view, environment)
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
            EventManager.Get<GameMessageEvents>().OpenHint += OnOpenHint;
            EventManager.Get<GameMessageEvents>().ShowNextHint += OnShowNextHint;
            EventManager.Get<GameMessageEvents>().Close += OnClose;
        }

        private int currentHint = 0;

        private async void OnOpenHint()
        {
            currentHint = 0;
            EventManager.Get<GameMessageEvents>().ShowNextHint?.Invoke(currentHint);
            await GameMessageView.Show(force: true);
        }

        private AssetLoader<Sprite> imageLoader = null;
        private async void SetHint(int hintOrder)
        {
            string message = SettingsManager.Get<GameHintSettings>().MessageText(hintOrder);
            if (!string.IsNullOrEmpty(message))
            {
                GameMessageView.DialogMessage = message.Replace("\\n", "\n");
            }
            if (imageLoader != null)
            {
                imageLoader.Dispose();
            }
            imageLoader = new AssetLoader<Sprite>(SettingsManager.Get<GameHintSettings>().ImageReference(hintOrder));
            await imageLoader.Load();
            GameMessageView.DialogImage = imageLoader.Asset;
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
                EventManager.Get<GameMessageEvents>().Close?.Invoke();
            }
        }

        private async void OnClose()
        {
            currentHint = 0;
            await GameMessageView.Hide();
        }

        private void Unsubscribe()
        {
            GameMessageView.DialogAction -= OnDialogAction;
            EventManager.Get<GameMessageEvents>().OpenHint -= OnOpenHint;
            EventManager.Get<GameMessageEvents>().ShowNextHint -= OnShowNextHint;
            EventManager.Get<GameMessageEvents>().Close -= OnClose;
        }


        public override async Task Open()
        {
            Subscribe();
            GameMessageView.Environment = environment;
            await base.Open();
        }

        public override async Task Close()
        {
            if (imageLoader != null)
            {
                imageLoader.Dispose();
                imageLoader = null;
            }
            Unsubscribe();
            await base.Close();
        }
    }
}
