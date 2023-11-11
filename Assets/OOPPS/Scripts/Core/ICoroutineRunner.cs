using System.Collections;
using UnityEngine;

namespace OOPPS.Core
{
    public interface ICoroutineRunner
    {
        public Coroutine RunCoroutine(IEnumerator routine);
        public void AbortCoroutine(IEnumerator routine);
    }
}