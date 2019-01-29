using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
    #region public field
    [SerializeField]
    public List<SequenceEvents> sequences;

    [SerializeField]
    public List<SequenceEvents> endSequences;
    #endregion

    #region private field
    private bool isRunning = false;
    #endregion

    public void SequenceStart()
    {
        if (isRunning)
            return;

        StartCoroutine(StartSequenceCoroutine());
    }

    private IEnumerator StartSequenceCoroutine()
    {
        isRunning = true;
        foreach(var s in sequences)
        {
            s.sequence.BeginSequence();
            yield return StartCoroutine(s.sequence.Activate());
            s.sequence.EndSequence();
        }
        isRunning = false;
    }

    #region SequenceControllerEditor method
    public void CastingSequence(List<SequenceEvents> list, int index, Component s)
    {
        list[index].sequence = s as Sequence;
    }

    public int GetSequenceEventsCount(List<SequenceEvents> list)
    {
        return list.Count;
    }

    public GameObject GetTargetObject(List<SequenceEvents> list, int index)
    {
        return list[index].sequence.gameObject;
    }
    #endregion
}