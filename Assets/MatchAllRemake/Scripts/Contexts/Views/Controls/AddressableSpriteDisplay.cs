using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ACFW.Views;
using UnityEngine.AddressableAssets;

namespace MatchAll.Views
{
    public abstract class AddressableSpriteDisplay : MonoBehaviour, IValueDisplay<AssetReference>, IDisposable
    {
        private AssetLoader<Sprite> loader = null;
        public AssetReference Value { set => LoadAndSetSprite(value); }

        protected abstract void SetSpriteDisplay(Sprite sprite);

        public async Task LoadSprite(AssetReference reference)
        {
            if (loader != null)
            {
                loader.Dispose();
            }
            loader = new AssetLoader<Sprite>(reference);
            await loader.Load();
            SetSpriteDisplay(loader.Asset);
        }

        private async void LoadAndSetSprite(AssetReference reference)
        {
            await LoadSprite(reference);
        }

        public void Dispose()
        {
            //image.sprite = null;
            SetSpriteDisplay(null);
            if (loader != null)
            {
                loader.Dispose();
                loader = null;
            }
        }
    }
}
