using UnityEngine;
using UnityEngine.UI;
using Views.Common;

namespace MatchAll.Views
{
    public class SpriteDisplay : MonoBehaviour, IValueDisplay<Sprite>
    {
        [SerializeField]
        private Image image;
        public Sprite Value { set => image.sprite = value; }
    }
}
