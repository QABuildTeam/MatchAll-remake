using System;
using UnityEngine;
using UnityEngine.UI;

namespace MatchAll.Views
{
    public class AddressableSpriteUIDisplay : AddressableSpriteDisplay
    {
        [SerializeField]
        private Image image;

        protected override void SetSpriteDisplay(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}
