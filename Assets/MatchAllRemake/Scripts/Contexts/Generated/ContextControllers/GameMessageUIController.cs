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
            // insert useful code here
        }


        private void Subscribe()
        {
            GameMessageView.DialogAction += OnDialogAction;

        }

        private void Unsubscribe()
        {
            GameMessageView.DialogAction -= OnDialogAction;

        }


        public override async Task Open()
        {
            GameMessageView.Environment = environment;
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
