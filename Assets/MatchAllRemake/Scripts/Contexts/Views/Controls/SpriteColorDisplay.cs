using UnityEngine;
using ACFW.Views;

namespace MatchAll.Views
{
    public abstract class SpriteColorDisplay : MonoBehaviour, IValueDisplay<Color>
    {
        protected abstract void SetColorDisplay(Color color);
        public Color Value { set => SetColorDisplay(value); }
    }
}
