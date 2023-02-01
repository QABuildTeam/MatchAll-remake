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
    public partial class GameEndMessageUIView : UIView
    {
        [SerializeField]
        private PreformattedTextString dialogMessage;
        public String DialogMessage
        {
            set => dialogMessage.Value = value;
        }
        [SerializeField]
        private SpriteDisplay dialogImage;
        public Sprite DialogImage
        {
            set => dialogImage.Value = value;
        }

        [SerializeField]
        private Button dialogButton;
        public event Action DialogAction;
        private void OnDialogButton()
        {
            DialogAction?.Invoke();
        }
        public bool ActiveDialog
        {
            get => dialogButton.gameObject.activeInHierarchy;
            set => dialogButton.gameObject.SetActive(value);
        }
        public bool InteractiveDialog
        {
            get => dialogButton.interactable;
            set => dialogButton.interactable = value;
        }
        [SerializeField]
        private PreformattedTextString dialogButtonLabel;
        public String DialogButtonLabel
        {
            set => dialogButtonLabel.Value = value;
        }

        protected override async Task Init()
        {
            dialogButton.onClick.RemoveAllListeners();
            dialogButton.onClick.AddListener(OnDialogButton);

        }

        protected override async Task Done()
        {
            dialogButton.onClick.RemoveAllListeners();

        }

    }
}
