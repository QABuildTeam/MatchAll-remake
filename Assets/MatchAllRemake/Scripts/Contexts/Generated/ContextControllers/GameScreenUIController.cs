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
    public partial class GameScreenUIController : ContextController, ITimer, IShapeSample, IScore
    {

        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private UniversalSettingsManager SettingsManager => environment.Get<UniversalSettingsManager>();
        private IData Data => environment.Get<IData>();
        private ShapeSettings ShapeSettings => SettingsManager.Get<ShapeSettings>();

        private IGameContainer GameContainer => environment.Get<IGameContainer>();

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
            EventManager.Get<GameEndMessageEvents>().CloseEndMessage += OnCloseEndMessage;
            EventManager.Get<GameEndMessageEvents>().OpenWinMessage += OnOpenWinMessage;
            EventManager.Get<GameEndMessageEvents>().OpenFailMessage += OnOpenFailMessage;
        }

        private void OnOpenWinMessage()
        {
            IsTimerRunning = false;
        }

        private void OnOpenFailMessage()
        {
            IsTimerRunning = false;
        }

        private void OnCloseEndMessage()
        {
            EventManager.Get<MainMenuEvents>().OpenMainMenu?.Invoke();
        }

        private void OnCloseHint()
        {
            IsTimerRunning = true;
        }

        private void Unsubscribe()
        {
            GameScreenView.BackAction -= OnBackAction;
            EventManager.Get<GameMessageEvents>().CloseHint -= OnCloseHint;
            EventManager.Get<GameEndMessageEvents>().CloseEndMessage -= OnCloseEndMessage;
            EventManager.Get<GameEndMessageEvents>().OpenWinMessage -= OnOpenWinMessage;
            EventManager.Get<GameEndMessageEvents>().OpenFailMessage -= OnOpenFailMessage;
        }


        public override async Task Open()
        {
            IsTimerRunning = false;
            CurrentScore = 0;
            GameContainer.Timer = this;
            GameContainer.ShapeSample = this;
            GameContainer.ScoreManager = this;
            GameScreenView.Environment = environment;
            SetShapeSample(ShapeType.None, 0);
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
                IsTimerRunning = true;
            }
        }

        public override async Task Close()
        {
            IsTimerRunning = false;
            GameContainer.Timer = null;
            GameContainer.ShapeSample = null;
            GameContainer.ScoreManager = null;
            Unsubscribe();
            await base.Close();
        }

        public void SetShapeSample(ShapeType type, int colorIndex)
        {
            GameScreenView.SampleDisplayBackground = ShapeObjectHelper.Resolve(new ShapeObject { shapeType = type, colorIndex = colorIndex }, ShapeSettings);
        }

        private float remainingTime = 0;
        public float RemainingTime { get => remainingTime; set => GameScreenView.TimerValue = remainingTime = value; }
        public bool IsTimerRunning { get; set; } = false;
        public int CurrentScore
        {
            get => Data.CurrentScore;
            set
            {
                Data.CurrentScore = value;
                GameScreenView.ScoreValue = value;
            }
        }

    }
}
