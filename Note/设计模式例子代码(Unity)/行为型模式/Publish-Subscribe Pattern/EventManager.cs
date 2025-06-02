using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;
    public static EventManager Instance => _instance;

    private Dictionary<string, Action<object>> eventDictionary;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        eventDictionary = new Dictionary<string, Action<object>>();
    }

    // 订阅事件
    public static void Subscribe(string eventName, Action<object> listener)
    {
        if (Instance.eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent += listener;
            Instance.eventDictionary[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    // 取消订阅
    public static void Unsubscribe(string eventName, Action<object> listener)
    {
        if (_instance == null) return;

        if (Instance.eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent -= listener;
            Instance.eventDictionary[eventName] = thisEvent;
        }
    }

    // 触发事件
    public static void TriggerEvent(string eventName, object eventData = null)
    {
        if (Instance.eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent?.Invoke(eventData);
        }
    }
}