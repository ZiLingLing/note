using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton : MonoBehaviour
{
    private static MonoSingleton instance;

    public static MonoSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MonoSingleton>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("MonoSingleton");
                    instance = obj.AddComponent<MonoSingleton>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
