using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSequence : Sequence
{
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public override void BeginSequence()
    {
        gameObject.SetActive(true);
    }

    protected override void SequenceProcess(float process)
    {
        image.fillAmount = process;
    }
}