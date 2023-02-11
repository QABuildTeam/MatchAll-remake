using UnityEngine;

namespace MatchAll.Views
{
    public class SpriteColorWorldDisplay : SpriteColorDisplay
    {
        [SerializeField]
        private SpriteRenderer image;

        protected override void SetColorDisplay(Color color)
        {
            image.color = color;
        }
    }
}
