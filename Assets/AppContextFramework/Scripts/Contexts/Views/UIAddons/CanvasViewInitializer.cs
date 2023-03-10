using ACFW.Environment;
using System.Threading.Tasks;
using UnityEngine;

namespace ACFW.Views
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasViewInitializer : AbstractUIViewAddon
    {
        [SerializeField]
        private Canvas canvas;
        [SerializeField]
        private int initialSortingOrder = 1;
        [SerializeField]
        private int workingSortingOrder = 0;
        [SerializeField]
        private CanvasGroup canvasGroup;
        public override Task DoPreShowTask(IServiceLocator environment)
        {
            canvas.sortingOrder = initialSortingOrder;
            canvasGroup.alpha = 0;
            return base.DoPreShowTask(environment);
        }

        public override Task DoPostShowTask(IServiceLocator environment)
        {
            canvas.sortingOrder = workingSortingOrder;
            canvasGroup.alpha = 1;
            return base.DoPostShowTask(environment);
        }

        public override Task DoPreHideTask(IServiceLocator environment)
        {
            canvas.sortingOrder = workingSortingOrder;
            return base.DoPreHideTask(environment);
        }
    }
}
