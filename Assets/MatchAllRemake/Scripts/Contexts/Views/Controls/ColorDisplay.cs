using UnityEngine;
using UnityEngine.UI;
using Views.Common;

namespace MatchAll.Views
{
    public class ColorDisplay : MonoBehaviour, IValueDisplay<Color>
    {
        [SerializeField]
        private Image image;

        public Color Value { set => image.color = value; }
    }
}
