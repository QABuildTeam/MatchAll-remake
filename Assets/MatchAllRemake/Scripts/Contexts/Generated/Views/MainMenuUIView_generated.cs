using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UIEditorTools;
using UIEditorTools.Views;
using UIEditorTools.Environment;
using UIEditorTools.Controllers;
using Views.Common;
using TMPro;

namespace MatchAll.Views
{
    public partial class MainMenuUIView : UIView
    {
        [SerializeField]
        private PreformattedTextString nameLabelText;
        public string NameLabelText
        {
            set => nameLabelText.Value = value;
        }

        [SerializeField]
        private Button nameButton;
        public event Action NameAction;
        private void OnNameButton()
        {
            NameAction?.Invoke();
        }
        public bool ActiveName
        {
            get => nameButton.gameObject.activeInHierarchy;
            set => nameButton.gameObject.SetActive(value);
        }
        public bool InteractiveName
        {
            get => nameButton.interactable;
            set => nameButton.interactable = value;
        }
        [SerializeField]
        private TMP_InputField nameInputField;
        public string Name
        {
            get => nameInputField.text;
            set => nameInputField.text = value;
        }
        public event Action<string> NameChanged;
        private void OnNameInputFieldChanged(string value)
        {
            NameChanged?.Invoke(value);
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
        public int ScoreValue
        {
            set => scoreValue.Value = value;
        }

        protected override async Task Init()
        {
            nameButton.onClick.RemoveAllListeners();
            nameButton.onClick.AddListener(OnNameButton);
            nameInputField.onValueChanged.RemoveAllListeners();
            nameInputField.onValueChanged.AddListener(OnNameInputFieldChanged);
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(OnStartButton);

        }

        protected override async Task Done()
        {
            nameButton.onClick.RemoveAllListeners();
            nameInputField.onValueChanged.RemoveAllListeners();
            startButton.onClick.RemoveAllListeners();

        }

    }
}
