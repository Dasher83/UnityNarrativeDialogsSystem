using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoroutineQueue
{
    private Queue<IEnumerator> _queue;

    public CoroutineQueue()
    {
        _queue = new Queue<IEnumerator>();
    }

    public void Enqueue(IEnumerator coroutine)
    {
        _queue.Enqueue(coroutine);
    }

    public void Start()
    {
        CoroutineRunner runner = CoroutineRunner.Instance;
        runner.Run(_queue);
    }

    private class CoroutineRunner : MonoBehaviour
    {
        private static CoroutineRunner instance;

        public static CoroutineRunner Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject singletonGameObject = new GameObject("CoroutineRunner");
                    instance = singletonGameObject.AddComponent<CoroutineRunner>();
                }
                return instance;
            }
        }


        public void Run(Queue<IEnumerator> queue)
        {
            StartCoroutine(RunCoroutine(queue));
        }

        private IEnumerator RunCoroutine(Queue<IEnumerator> queue)
        {
            while(queue.Count > 0)
            {
                yield return StartCoroutine(queue.Dequeue());
            }
        }
    }
}
