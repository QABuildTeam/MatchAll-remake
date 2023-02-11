using UnityEngine;
using UnityEngine.UI;

namespace MatchAll.Views
{
    public class SpriteColorUIDisplay : SpriteColorDisplay
    {
        [SerializeField]
        private Image image;

        protected override void SetColorDisplay(Color color)
        {
            image.color = color;
        }
    }
}
