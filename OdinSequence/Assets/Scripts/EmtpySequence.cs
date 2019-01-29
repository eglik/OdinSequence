using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmtpySequence : Sequence
{
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public override void EndSequence()
    {
        gameObject.SetActive(false);
    }

    protected override void SequenceProcess(float process)
    {
        image.fillAmount = 1 - process;
    }
}