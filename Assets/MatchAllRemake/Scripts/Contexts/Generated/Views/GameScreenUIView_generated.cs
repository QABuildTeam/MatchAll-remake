using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ACFW.Views;
using MatchAll.Views;
using UnityEngine.AddressableAssets;
using TMPro;

namespace MatchAll.Views
{
    public partial class GameScreenUIView : UIView
    {
        [SerializeField]
        private AddressableSpriteDisplay sampleDisplayBackground;
        public AssetReference SampleDisplayBackground
        {
            set => sampleDisplayBackground.Value = value;
        }
        [SerializeField]
        private ColorDisplay sampleValue;
        public Color SampleValue
        {
            set => sampleValue.Value = value;
        }
        [SerializeField]
        private PreformattedTextInt scoreValue;
        public Int32 ScoreValue
        {
            set => scoreValue.Value = value;
        }
        [SerializeField]
        private PreformattedTextFloat timerValue;
        public Single TimerValue
        {
            set => timerValue.Value = value;
        }

        [SerializeField]
        private Button backButton;
        public event Action BackAction;
        private void OnBackButton()
        {
            BackAction?.Invoke();
        }
        public bool ActiveBack
        {
            get => backButton.gameObject.activeInHierarchy;
            set => backButton.gameObject.SetActive(value);
        }
        public bool InteractiveBack
        {
            get => backButton.interactable;
            set => backButton.interactable = value;
        }
        [SerializeField]
        private PreformattedTextString playerNameValue;
        public String PlayerNameValue
        {
            set => playerNameValue.Value = value;
        }

        protected override async Task Init()
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(OnBackButton);

        }

        protected override async Task Done()
        {
            sampleDisplayBackground.Dispose();
            backButton.onClick.RemoveAllListeners();

        }

    }
}
