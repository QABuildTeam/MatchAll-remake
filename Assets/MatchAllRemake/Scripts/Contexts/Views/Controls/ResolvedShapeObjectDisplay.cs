using System;
using ACFW.Views;
using UnityEngine;

namespace MatchAll.Views
{
    public class ResolvedShapeObjectDisplay : MonoBehaviour, IValueDisplay<ResolvedShapeObject>, IDisposable
    {
        private AddressableSpriteDisplay spriteDisplay;
        private AddressableSpriteDisplay SpriteDisplay => spriteDisplay ?? (spriteDisplay = GetComponentInChildren<AddressableSpriteDisplay>());
        private SpriteColorDisplay colorDisplay;
        private SpriteColorDisplay ColorDisplay => colorDisplay ?? (colorDisplay = GetComponentInChildren<SpriteColorDisplay>());

        public ResolvedShapeObject Value
        {
            set => SetValue(value);
        }

        private async void SetValue(ResolvedShapeObject value)
        {
            ColorDisplay.Value = Color.clear;
            await SpriteDisplay.LoadSprite(value.spriteReference);
            ColorDisplay.Value = value.spriteColor;
        }

        public Color Color
        {
            set => ColorDisplay.Value = value;
        }

        public void Dispose()
        {
            SpriteDisplay.Dispose();
        }
    }
}
