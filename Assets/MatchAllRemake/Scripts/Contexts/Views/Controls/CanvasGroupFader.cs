using System;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace MatchAll.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupFader : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        public CanvasGroup ViewCanvasGroup => canvasGroup ?? (canvasGroup = GetComponent<CanvasGroup>());
        protected float initialTransparency = 0;
        private Tweener tweener;

        public async Task StartFade(float transparency, float fadeDuration)
        {
            StopFade();
            if (ViewCanvasGroup != null)
            {
                TaskCompletionSource<object> completionSource = new TaskCompletionSource<object>();
                float alpha = ViewCanvasGroup.alpha;
                try
                {
                    tweener = DOTween.To(() => ViewCanvasGroup.alpha, (value) => { alpha = value; ViewCanvasGroup.alpha = value; }, transparency, fadeDuration)
                        .OnComplete(() => completionSource?.SetResult(null));
                    await completionSource.Task;
                }
                catch (Exception ex)
                {
                    Debug.Log($"Error animating CanvasGroup.alpha: {ex}");
                }
                finally
                {
                    StopFade();
                    await Task.Yield();
                    tweener = null;
                    ViewCanvasGroup.alpha = transparency;
                    initialTransparency = transparency;
                }
            }
        }

        public void StopFade()
        {
            if (tweener != null && !tweener.IsComplete())
            {
                tweener.Complete();
            }
        }
    }
}
