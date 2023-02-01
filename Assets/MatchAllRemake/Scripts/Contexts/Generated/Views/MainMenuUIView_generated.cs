using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UIEditorTools;
using UIEditorTools.Views;
using UIEditorTools.Environment;
using UIEditorTools.Controllers;
using MatchAll.Views;
using Views.Common;
using TMPro;

namespace MatchAll.Views
{
    public partial class MainMenuUIView : UIView
    {

        [SerializeField]
        private Button currentPlayerNameButton;
        public event Action CurrentPlayerNameAction;
        private void OnCurrentPlayerNameButton()
        {
            CurrentPlayerNameAction?.Invoke();
        }
        public bool ActiveCurrentPlayerName
        {
            get => currentPlayerNameButton.gameObject.activeInHierarchy;
            set => currentPlayerNameButton.gameObject.SetActive(value);
        }
        public bool InteractiveCurrentPlayerName
        {
            get => currentPlayerNameButton.interactable;
            set => currentPlayerNameButton.interactable = value;
        }
        [SerializeField]
        private PreformattedTextString currentPlayerName;
        public String CurrentPlayerName
        {
            set => currentPlayerName.Value = value;
        }
        [SerializeField]
        private TMP_InputField playerNameInputField;
        public string PlayerName
        {
            get => playerNameInputField.text;
            set => playerNameInputField.text = value;
        }
        public event Action<string> PlayerNameChanged;
        private void OnPlayerNameInputFieldChanged(string value)
        {
            PlayerNameChanged?.Invoke(value);
        }
        public bool ActivePlayerName
        {
            get => playerNameInputField.gameObject.activeInHierarchy;
            set => playerNameInputField.gameObject.SetActive(value);
        }
        public bool InteractivePlayerName
        {
            get => playerNameInputField.interactable;
            set => playerNameInputField.interactable = value;
        }

        [SerializeField]
        private Button startButton;
        public event Action StartAction;
        private void OnStartButton()
        {
            StartAction?.Invoke();
        }
        public bool ActiveStart
        {
            get => startButton.gameObject.activeInHierarchy;
            set => startButton.gameObject.SetActive(value);
        }
        public bool InteractiveStart
        {
            get => startButton.interactable;
            set => startButton.interactable = value;
        }
        [SerializeField]
        private PreformattedTextInt scoreValue;
        public Int32 ScoreValue
        {
            set => scoreValue.Value = value;
        }

        protected override async Task Init()
        {
            currentPlayerNameButton.onClick.RemoveAllListeners();
            currentPlayerNameButton.onClick.AddListener(OnCurrentPlayerNameButton);
            playerNameInputField.onValueChanged.RemoveAllListeners();
            playerNameInputField.onValueChanged.AddListener(OnPlayerNameInputFieldChanged);
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(OnStartButton);

        }

        protected override async Task Done()
        {
            currentPlayerNameButton.onClick.RemoveAllListeners();
            playerNameInputField.onValueChanged.RemoveAllListeners();
            startButton.onClick.RemoveAllListeners();

        }

    }
}
