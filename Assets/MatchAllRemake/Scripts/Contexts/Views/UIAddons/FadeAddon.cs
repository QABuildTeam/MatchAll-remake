using System.Threading.Tasks;
using UnityEngine;
using ACFW;
using ACFW.Views;

namespace MatchAll.Views
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasGroupFader))]
    public class FadeAddon : AbstractUIViewAddon
    {
        private Canvas canvas;
        protected Canvas ViewCanvas => canvas ?? (canvas = GetComponent<Canvas>());

        private CanvasGroupFader fader;
        protected CanvasGroupFader Fader => fader ?? (fader = GetComponent<CanvasGroupFader>());

        public override Task DoShowTask(IServiceLocator environment)
        {
            Fader.ViewCanvasGroup.alpha = initialTransparency;
            return SetCanvasTransparency(1);
        }

        public override Task DoHideTask(IServiceLocator environment)
        {
            return SetCanvasTransparency(0);
        }

        protected float initialTransparency = 0;
        [SerializeField]
        private float duration = 0.5f;

        private async Task SetCanvasTransparency(float transparency)
        {
            await Fader.StartFade(transparency, duration);
        }
    }
}
