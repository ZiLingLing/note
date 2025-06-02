using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameScore : MonoBehaviour
{
    private int totalScore;

    private void Start()
    {
        totalScore = 0;
    }

    private void OnEnable()
    {
        EventManager.Subscribe(EventType.enemyDied, OnEnemyDied);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(EventType.enemyDied, OnEnemyDied);
    }

    private void OnEnemyDied(object points)
    {
        totalScore += (int)points;
        Debug.Log($"当前分数: {totalScore}");
    }
}
