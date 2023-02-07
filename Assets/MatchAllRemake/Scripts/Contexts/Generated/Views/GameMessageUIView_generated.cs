using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ACFW.Views;
using UnityEngine.AddressableAssets;

namespace MatchAll.Views
{
    public partial class GameMessageUIView : UIView
    {
        [SerializeField]
        private PreformattedTextString dialogMessage;
        public String DialogMessage
        {
            set => dialogMessage.Value = value;
        }
        [SerializeField]
        private AddressableSpriteDisplay dialogImage;
        public AssetReference DialogImage
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
            dialogImage.Dispose();
            dialogButton.onClick.RemoveAllListeners();

        }

    }
}
