using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class CoroutineQueue
{
    private Queue<IEnumerator> _queue;
    private readonly CoroutineRunner _runner;

    public CoroutineQueue(CoroutineRunner runner)
    {
        _queue = new Queue<IEnumerator>();
        _runner = runner;
    }

    public void Enqueue(IEnumerator coroutine)
    {
        _queue.Enqueue(coroutine);
    }

    public void Start()
    {
        new CoroutineQueueRunner(_runner).Run(_queue);
    }

    private class CoroutineQueueRunner
    {
        private CoroutineRunner _runner;

        private CoroutineQueueRunner() { }
        public CoroutineQueueRunner(CoroutineRunner runner)
        {
            _runner = runner;
        }

        public void Run(Queue<IEnumerator> queue)
        {
            _runner.StartCoroutine(RunCoroutine(queue));
        }

        private IEnumerator RunCoroutine(Queue<IEnumerator> queue)
        {
            while(queue.Count > 0)
            {
                yield return _runner.StartCoroutine(queue.Dequeue());
            }
        }
    }
}
