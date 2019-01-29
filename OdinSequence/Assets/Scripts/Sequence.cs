using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sequence : MonoBehaviour
{
    #region protected field
    [SerializeField]
    protected float speed;
    #endregion

    #region public IEnumerator
    public IEnumerator Activate()
    {
        float process = 0f;

        while (process <= 1f)
        {
            process += Time.deltaTime * speed;
            SequenceProcess(process);
            yield return null;
        }

        yield break;
    }
    #endregion

    #region protected virtual method
    protected virtual void SequenceProcess(float process)
    {

    }
    #endregion

    #region public virtual method
    public virtual void BeginSequence()
    {

    }

    public virtual void EndSequence()
    {

    }
    #endregion

    #region SequenceControllerEditor method
    public string[] GetSequenceArray()
    {
        List<string> data = new List<string>();

        var sequences = GetComponents<Sequence>();

        foreach (var s in sequences)
        {
            if (s is Sequence)
            {
                data.Add(s.GetType().ToString());
            }
        }

        return data.ToArray();
    }
    #endregion
}