using System;
using System.Linq;
using UIEditorTools;
using UIEditorTools.Controllers;
using UIEditorTools.Environment;
using UIEditorTools.Settings;
using UIEditorTools.Views;
using System.Threading.Tasks;
using MatchAll.Views;

namespace MatchAll.Controllers
{
    public partial class GameScreenUIController : ContextController
    {
        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private UniversalSettingsManager SettingsManager => environment.Get<UniversalSettingsManager>();

        private GameScreenUIView GameScreenView => (GameScreenUIView)view;
        public GameScreenUIController(GameScreenUIView view, UniversalEnvironment environment) : base(view, environment)
        {
        }

        private void OnBackAction()
        {
            // insert useful code here
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
        }

        public override async Task Close()
        {
            Unsubscribe();
            await base.Close();
        }
    }
}
