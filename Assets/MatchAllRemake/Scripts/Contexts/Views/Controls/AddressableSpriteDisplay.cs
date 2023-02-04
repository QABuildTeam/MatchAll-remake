using System;
using UnityEngine;
using UnityEngine.UI;
using ACFW.Views;
using UnityEngine.AddressableAssets;

namespace MatchAll.Views
{
    public class AddressableSpriteDisplay : MonoBehaviour, IValueDisplay<AssetReference>, IDisposable
    {
        [SerializeField]
        private Image image;

        private AssetLoader<Sprite> loader = null;
        public AssetReference Value { set => LoadSprite(value); }

        private async void LoadSprite(AssetReference reference)
        {
            if (loader != null)
            {
                loader.Dispose();
            }
            loader = new AssetLoader<Sprite>(reference);
            await loader.Load();
            image.sprite = loader.Asset;
        }

        public void Dispose()
        {
            image.sprite = null;
            if (loader != null)
            {
                loader.Dispose();
                loader = null;
            }
        }
    }
}
