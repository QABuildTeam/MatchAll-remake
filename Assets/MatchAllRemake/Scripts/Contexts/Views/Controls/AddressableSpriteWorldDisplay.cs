using UnityEngine;

namespace MatchAll.Views
{
    public class AddressableSpriteWorldDisplay : AddressableSpriteDisplay
    {
        [SerializeField]
        private SpriteRenderer image;

        protected override void SetSpriteDisplay(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}
