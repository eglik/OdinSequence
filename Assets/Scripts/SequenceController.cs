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

    public void SequenceStart()
    {
        if (SequenceSafety.GetInstace().isRunning)
            return;

        StartCoroutine(StartSequenceCoroutine());
    }

    private IEnumerator StartSequenceCoroutine()
    {
        SequenceSafety.GetInstace().isRunning = true;
        foreach(var s in sequences)
        {
            s.sequence.BeginSequence();
            yield return StartCoroutine(s.sequence.Activate());
            s.sequence.EndSequence();
        }
        SequenceSafety.GetInstace().isRunning = false;
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