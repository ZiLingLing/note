using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StaticSingleton
{
    private static StaticSingleton instance;
    public static StaticSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new StaticSingleton();
            }

            return instance;
        }
    }
}
