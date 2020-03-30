using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quat
{
    public class SequenceUtil : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> objs;

        public void SetEnableObjects()
        {
            objs.ForEach(o => o.SetActive(true));
        }

        public void SetDisableObjects()
        {
            objs.ForEach(o => o.SetActive(false));
        }
    }
}