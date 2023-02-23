using ACFW;
using ACFW.Controllers;
using System.Threading.Tasks;
using MatchAll.Views;
using MatchAll.Environment;
using MatchAll.Settings;
using UnityEngine;

namespace MatchAll.Controllers
{
    public partial class GameScreenUIController : ContextController, ITimerInput, ITimer, IShapeSample, IScore, ISessionManager
    {

        private IEventManager EventManager => environment.Get<IEventManager>();
        private ISettingsManager SettingsManager => environment.Get<ISettingsManager>();
        private IData Data => environment.Get<IData>();
        private ShapeSettings ShapeSettings => SettingsManager.Get<ShapeSettings>();

        private IGameContainer GameContainer => environment.Get<IGameContainer>();

        private GameScreenUIView GameScreenView => (GameScreenUIView)view;

        public GameScreenUIController(GameScreenUIView view, IServiceLocator environment) : base(view, environment)
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
            TimerRunning = false;
        }

        private void OnOpenFailMessage()
        {
            TimerRunning = false;
        }

        private void OnCloseEndMessage()
        {
            EventManager.Get<MainMenuEvents>().OpenMainMenu?.Invoke();
        }

        private void OnCloseHint()
        {
            TimerRunning = true;
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
            TimerRunning = false;
            CurrentScore = 0;
            GameContainer.Timer = this;
            GameContainer.TimerInput = this;
            GameContainer.ShapeSample = this;
            GameContainer.ScoreManager = this;
            GameContainer.SessionManager = this;
            GameScreenView.Environment = environment;
            SetShapeSample(new ShapeDefinition { shapeType = ShapeType.None, colorIndex = 0 });
            GameScreenView.PlayerNameValue = Data.PlayerName;
            await base.Open();
            Subscribe();
        }

        public override async Task PostOpen()
        {
            await base.PostOpen();
            if (Data.MaxScore <= 0)
            {
                EventManager.Get<GameMessageEvents>().OpenHint?.Invoke();
            }
            else
            {
                TimerRunning = true;
            }
        }

        public override async Task Close()
        {
            TimerRunning = false;
            GameContainer.Timer = null;
            GameContainer.TimerInput = null;
            GameContainer.ShapeSample = null;
            GameContainer.ScoreManager = null;
            GameContainer.SessionManager = null;
            Unsubscribe();
            await base.Close();
        }

        #region ITimerInput implementation
        public float DeltaTime => Time.deltaTime;

        public bool Running => TimerRunning;
        #endregion

        #region IShapeSample implementation
        public void SetShapeSample(ShapeDefinition shapeDefinition)
        {
            GameScreenView.SampleDisplayBackground = ShapeObjectHelper.Resolve(shapeDefinition, ShapeSettings);
        }
        #endregion

        #region ITimer implementation
        private float remainingTime = 0;
        public float RemainingTime { get => remainingTime; set => GameScreenView.TimerValue = remainingTime = value; }
        public bool TimerRunning { get; set; } = false;
        #endregion

        #region IScore implementation
        public int CurrentScore
        {
            get => Data.CurrentScore;
            set
            {
                if (value > Data.CurrentScore)
                {
                    EventManager.Get<GameEvents>().ScoreUp?.Invoke();
                }
                else if (value < Data.CurrentScore)
                {
                    EventManager.Get<GameEvents>().ScoreDown?.Invoke();
                }
                Data.CurrentScore = value;
                GameScreenView.ScoreValue = value;
            }
        }
        #endregion

        #region ISessionManager implementation
        public void StartSession()
        {
        }

        public void SessionWin()
        {
            Data.GameResult = GameEndType.Win;
            EventManager.Get<GameEndMessageEvents>().OpenWinMessage?.Invoke();
        }

        public void SessionFail()
        {
            Data.GameResult = GameEndType.Fail;
            EventManager.Get<GameEndMessageEvents>().OpenFailMessage?.Invoke();
        }
        #endregion
    }
}
