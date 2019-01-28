using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
    [SerializeField]
    public List<SequenceEvents> startSequences;

    [SerializeField]
    public List<SequenceEvents> endSequences;

    private bool isRunning = false;

    public void CastingSequence(List<SequenceEvents> list, int index, Component s)
    {
        list[index].sequence = s as Sequence;
    }

    public int GetSequenceEventsCount(List<SequenceEvents> list)
    {
        return list.Count;
    }

    public void StartSequence()
    {
        if (isRunning)
            return;

        StartCoroutine(StartSequenceCoroutine());
    }

    public void EndSequence()
    {
        if (isRunning)
            return;

        StartCoroutine(EndSequenceCoroutine());
    }

    public GameObject GetTargetObject(List<SequenceEvents> list, int index)
    {
        return list[index].sequence.gameObject;
    }

    private IEnumerator StartSequenceCoroutine()
    {
        isRunning = true;
        foreach(var i in startSequences)
        {
            i.sequence.BeginSequence();
            yield return StartCoroutine(i.sequence.Activate());
            i.sequence.EndSequence();
        }
        isRunning = false;
    }

    private IEnumerator EndSequenceCoroutine()
    {
        isRunning = true;
        foreach (var i in endSequences)
        {
            i.sequence.BeginSequence();
            yield return StartCoroutine(i.sequence.Activate());
            i.sequence.EndSequence();
        }
        isRunning = false;
    }
}