using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeoutSequence : Sequence
{
    [SerializeField]
    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    protected override void SequenceProcess(float process)
    {
        canvasGroup.alpha = process;
    }

    public override void BeginSequence()
    {
        gameObject.SetActive(true);
    }
}