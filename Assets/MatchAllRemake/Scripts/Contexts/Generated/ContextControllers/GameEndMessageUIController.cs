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
        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private UniversalSettingsManager SettingsManager => environment.Get<UniversalSettingsManager>();

        private GameEndMessageUIView GameEndMessageView => (GameEndMessageUIView)view;
        public GameEndMessageUIController(GameEndMessageUIView view, UniversalEnvironment environment) : base(view, environment)
        {
        }

        private void OnDialogAction()
        {
            EventManager.Get<GameEndMessageEvents>().Close?.Invoke();
        }


        private void Subscribe()
        {
            GameEndMessageView.DialogAction += OnDialogAction;
            EventManager.Get<GameEndMessageEvents>().Open += OnOpen;
            EventManager.Get<GameEndMessageEvents>().Close += OnClose;
        }

        private async void OnOpen(GameEndType type)
        {
            ShowMessage(type);
            await GameEndMessageView.Show(force: true);
        }

        private AssetLoader<Sprite> imageLoader = null;
        private async void ShowMessage(GameEndType type)
        {
            string message = SettingsManager.Get<GameEndMessageSettings>().MessageText(type);
            if (!string.IsNullOrEmpty(message))
            {
                GameEndMessageView.DialogMessage = message.Replace("\\n", "\n");
            }
            if (imageLoader != null)
            {
                imageLoader.Dispose();
            }
            imageLoader = new AssetLoader<Sprite>(SettingsManager.Get<GameEndMessageSettings>().ImageReference(type));
            await imageLoader.Load();
            GameEndMessageView.DialogImage = imageLoader.Asset;
            GameEndMessageView.DialogButtonLabel = SettingsManager.Get<GameEndMessageSettings>().ButtonText(type);
        }

        private async void OnClose()
        {
            await GameEndMessageView.Hide();
        }

        private void Unsubscribe()
        {
            GameEndMessageView.DialogAction -= OnDialogAction;
            EventManager.Get<GameEndMessageEvents>().Open -= OnOpen;
            EventManager.Get<GameEndMessageEvents>().Close -= OnClose;
        }


        public override async Task Open()
        {
            Subscribe();
            GameEndMessageView.Environment = environment;
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
