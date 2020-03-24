using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quat
{
    [System.Serializable]
    public abstract class Sequence : MonoBehaviour
    {
        #region protected field
        [SerializeField]
        protected float speed = 1f;
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

        #region public abstract method
        public abstract void BeginSequence();
        public abstract void EndSequence();
        #endregion

        #region SequenceControllerEditor method
        public string[] GetSequenceArray()
        {
            var sequences = GetComponents<Sequence>();
            return sequences.Select((s) => s.GetType().Name).ToArray();
        }
        #endregion
    }
}