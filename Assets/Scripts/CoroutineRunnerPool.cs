using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CoroutineRunnerPool: MonoBehaviour
{
    public static CoroutineRunnerPool Instance { get; private set; }

    private readonly Queue<CoroutineRunner> _availableRunners = new Queue<CoroutineRunner>();
    private readonly List<CoroutineRunner> _inUseRunners = new List<CoroutineRunner>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            enabled = false;
            return;
        }
    }

    public CoroutineRunner GetRunner()
    {
        CoroutineRunner runner;

        if(_availableRunners.Count > 0)
        {
            runner = _availableRunners.Dequeue();
        }
        else
        {
            runner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
        }

        _inUseRunners.Add(runner);

        return runner;
    }

    public void ReleaseRunner(CoroutineRunner runner)
    {
        if (!_inUseRunners.Contains(runner)) return;

        _inUseRunners.Remove(runner);
        _availableRunners.Enqueue(runner);
    }
}
