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
    public partial class GameScreenUIController : ContextController, ITimer, IShapeSample, ISessionManager, IScore
    {
        private UniversalEventManager EventManager => environment.Get<UniversalEventManager>();
        private UniversalSettingsManager SettingsManager => environment.Get<UniversalSettingsManager>();
        private IData Data => environment.Get<IData>();
        private ShapeSettings ShapeSettings => SettingsManager.Get<ShapeSettings>();
        private GameSessionSettings SessionSettings => SettingsManager.Get<GameSessionSettings>();
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
            EventManager.Get<GameEndMessageEvents>().CloseEndMessage += OnCloseEndMessage;
        }

        private void OnCloseEndMessage()
        {
            EventManager.Get<MainMenuEvents>().OpenMainMenu?.Invoke();
        }

        private void OnCloseHint()
        {
            Debug.Log("Hint closed, running timer");
            IsTimerRunning = true;
        }

        private void Unsubscribe()
        {
            GameScreenView.BackAction -= OnBackAction;
            EventManager.Get<GameMessageEvents>().CloseHint -= OnCloseHint;
        }


        public override async Task Open()
        {
            IsTimerRunning = false;
            CurrentScore = 0;
            GameManager.Timer = this;
            GameManager.ShapeSample = this;
            GameManager.SessionManager = this;
            GameManager.ScoreManager = this;
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
            GameManager.Timer = null;
            GameManager.ShapeSample = null;
            GameManager.SessionManager = null;
            GameManager.ScoreManager = null;
            Unsubscribe();
            await base.Close();
        }

        public void SetShapeSample(ShapeType type, int colorIndex)
        {
            GameScreenView.SampleDisplayBackground = ShapeSettings.GetShapeSpriteReference(type);
            GameScreenView.SampleValue = ShapeSettings.GetShapeColor(colorIndex);
        }

        public void StartSession()
        {
        }

        public void SessionWin()
        {
            EventManager.Get<GameEndMessageEvents>().Open?.Invoke(GameEndType.Win);
        }

        public void SessionFail()
        {
            EventManager.Get<GameEndMessageEvents>().Open?.Invoke(GameEndType.Fail);
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
