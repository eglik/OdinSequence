using UnityEngine;

namespace Quat
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeoutSequence : Sequence
    {
        CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        protected override void SequenceProcess(float process)
        {
            canvasGroup.alpha = process;
        }
    }
}