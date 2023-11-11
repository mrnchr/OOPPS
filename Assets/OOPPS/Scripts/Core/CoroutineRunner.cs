using System.Collections;
using UnityEngine;

namespace OOPPS.Core
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public Coroutine RunCoroutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void AbortCoroutine(IEnumerator routine)
        {
            StopCoroutine(routine);
        }
    }
}