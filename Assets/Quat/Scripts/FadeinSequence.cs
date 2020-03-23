using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeinSequence : Sequence
{
    [SerializeField]
    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    protected override void SequenceProcess(float process)
    {
        canvasGroup.alpha = 1 - process;
    }
    
    public override void EndSequence()
    {
        gameObject.SetActive(false);
    }
}