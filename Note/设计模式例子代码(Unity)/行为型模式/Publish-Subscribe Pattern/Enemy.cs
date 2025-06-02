using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int points = 100;
    private void OnDestroy()
    {
        EventManager.TriggerEvent(EventType.enemyDied, points);
    }
}
