using UnityEngine;

namespace Quat
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeinSequence : Sequence
    {
        CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        protected override void SequenceProcess(float process)
        {
            canvasGroup.alpha = 1 - process;
        }
    }
}