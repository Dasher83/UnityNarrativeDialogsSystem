using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NarrativeDialogs.Scripts.Shared.Utils
{
    public class CoroutineQueue : MonoBehaviour
    {
        private Queue<IEnumerator> _queue;
        private bool _isExecuting;

        private void Awake()
        {
            _queue = new Queue<IEnumerator>();
            _isExecuting = false;
        }

        public void Enqueue(IEnumerator coroutine)
        {
            _queue.Enqueue(coroutine);

            if (!_isExecuting)
            {
                StartCoroutine(ExecuteQueue());
            }
        }

        private IEnumerator ExecuteQueue()
        {
            _isExecuting = true;

            while (_queue.Count > 0)
            {
                yield return StartCoroutine(_queue.Dequeue());
            }

            _isExecuting = false;
        }
    }
}
