using ACFW;
using ACFW.Controllers;
using System.Threading.Tasks;
using MatchAll.Views;
using MatchAll.Environment;
using MatchAll.Settings;

namespace MatchAll.Controllers
{
    public partial class GameScreenUIController : ContextController, ITimer, IShapeSample, IScore, ISessionManager
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
                IsTimerRunning = true;
            }
        }

        public override async Task Close()
        {
            IsTimerRunning = false;
            GameContainer.Timer = null;
            GameContainer.ShapeSample = null;
            GameContainer.ScoreManager = null;
            GameContainer.SessionManager = null;
            Unsubscribe();
            await base.Close();
        }

        public void SetShapeSample(ShapeDefinition shapeDefinition)
        {
            GameScreenView.SampleDisplayBackground = ShapeObjectHelper.Resolve(shapeDefinition, ShapeSettings);
        }

        private float remainingTime = 0;
        public float RemainingTime { get => remainingTime; set => GameScreenView.TimerValue = remainingTime = value; }
        public bool IsTimerRunning { get; set; } = false;
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
    }
}
