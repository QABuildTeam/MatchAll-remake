using UnityEngine;
using UnityEngine.UI;
using ACFW.Views;

namespace MatchAll.Views
{
    public class SpriteDisplay : MonoBehaviour, IValueDisplay<Sprite>
    {
        [SerializeField]
        private Image image;
        public Sprite Value { set => image.sprite = value; }
    }
}
