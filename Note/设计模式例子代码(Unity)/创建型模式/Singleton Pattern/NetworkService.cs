using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class NetworkService
{
    private static NetworkService instance;
    private static readonly object _lock = new object();

    public static NetworkService Instance
    {
        get
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new NetworkService();
                    }
                }
            }
            return instance;
        }
    }

    private ConcurrentQueue<Action> _mainThreadActions = new ConcurrentQueue<Action>();

    // �������̵߳��ã��������׵����߳�ִ��
    public void UpdateData(Action action)
    {
        _mainThreadActions.Enqueue(action);
    }

    // �����̵߳�Update��ִ��
    public void ProcessMainThreadActions()
    {
        while (_mainThreadActions.TryDequeue(out var action))
        {
            action?.Invoke();
        }
    }
}
