using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quat
{
    public class SequenceSafety
    {
        private static SequenceSafety instance = null;

        public bool isRunning;

        private SequenceSafety()
        {
            isRunning = false;
        }

        public static SequenceSafety GetInstace()
        {
            if (instance == null)
            {
                instance = new SequenceSafety();
            }

            return instance;
        }
    }
}