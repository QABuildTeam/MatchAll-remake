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
    public partial class MainMenuUIController : ContextController
    {
        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private UniversalSettingsManager SettingsManager => environment.Get<UniversalSettingsManager>();

        private MainMenuUIView MainMenuView => (MainMenuUIView)view;
        public MainMenuUIController(MainMenuUIView view, UniversalEnvironment environment) : base(view, environment)
        {
        }

        private void OnNameAction()
        {
            // insert useful code here
        }
        private void OnNameChanged(string value)
        {
            // insert useful code here
        }
        private void OnStartAction()
        {
            // insert useful code here
        }


        private void Subscribe()
        {
            MainMenuView.NameAction += OnNameAction;
            MainMenuView.NameChanged += OnNameChanged;
            MainMenuView.StartAction += OnStartAction;

        }

        private void Unsubscribe()
        {
            MainMenuView.NameAction -= OnNameAction;
            MainMenuView.NameChanged -= OnNameChanged;
            MainMenuView.StartAction -= OnStartAction;

        }


        public override async Task Open()
        {
            MainMenuView.Environment = environment;
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
