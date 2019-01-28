using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sequence : MonoBehaviour
{
    [SerializeField]
    protected float speed;

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

    protected virtual void SequenceProcess(float process)
    {

    }

    public virtual void BeginSequence()
    {

    }

    public virtual void EndSequence()
    {

    }

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
}