using ACFW;
using ACFW.Controllers;
using System.Threading.Tasks;
using MatchAll.Views;
using MatchAll.Environment;
using MatchAll.Settings;
using UnityEngine;
using System;

namespace MatchAll.Controllers
{
    public partial class GameScreenUIController : ContextController, ITimer
    {
        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private UniversalSettingsManager SettingsManager => environment.Get<UniversalSettingsManager>();
        private IData Data => environment.Get<IData>();
        private ShapeSettings ShapeSettings => SettingsManager.Get<ShapeSettings>();
        private IGameManager GameManager => environment.Get<IGameManager>();

        private GameScreenUIView GameScreenView => (GameScreenUIView)view;

        public GameScreenUIController(GameScreenUIView view, UniversalEnvironment environment) : base(view, environment)
        {
        }

        private void OnBackAction()
        {
            EventManager.Get<MainMenuEvents>().OpenMainMenu?.Invoke();
        }


        private void Subscribe()
        {
            GameScreenView.BackAction += OnBackAction;
            EventManager.Get<GameMessageEvents>().CloseHint += OnCloseHint;

        }

        private void OnCloseHint()
        {
            Debug.Log("Hint closed, running timer");
            IsTimerRun = true;
        }

        private void Unsubscribe()
        {
            GameScreenView.BackAction -= OnBackAction;
            EventManager.Get<GameMessageEvents>().CloseHint -= OnCloseHint;
        }


        public override async Task Open()
        {
            IsTimerRun = false;
            GameManager.Timer = this;
            GameScreenView.Environment = environment;
            SetSampleShape(ShapeType.None, 0);
            GameScreenView.PlayerNameValue = Data.PlayerName;
            await base.Open();
            Subscribe();
        }

        public override async Task PostOpen()
        {
            await base.PostOpen();
            if (Data.CurrentScore <= 0)
            {
                EventManager.Get<GameMessageEvents>().OpenHint?.Invoke();
            }
            else
            {
                IsTimerRun = true;
            }
        }

        public override async Task Close()
        {
            IsTimerRun = false;
            GameManager.Timer = null;
            Unsubscribe();
            await base.Close();
        }

        public void SetSampleShape(ShapeType type, int colorIndex)
        {
            GameScreenView.SampleDisplayBackground = ShapeSettings.GetShapeSpriteReference(type);
            GameScreenView.SampleValue = ShapeSettings.GetShapeColor(colorIndex);
        }

        private float remainingTime = 0;
        public float RemainingTime { get => remainingTime; set => GameScreenView.TimerValue = remainingTime = value; }
        public bool IsTimerRun { get; set; } = false;
    }
}
