using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//被观察者
public class PlayerHealth : MonoBehaviour
{
    // 定义事件
    public event Action<float> OnHealthChanged;//血量变化事件
    public event Action OnPlayerDeath;//玩家死亡事件

    [SerializeField]
    private float maxHealth = 100f;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);

        //通知观察者血量变化
        OnHealthChanged?.Invoke(currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            //通知观察者玩家死亡
            OnPlayerDeath?.Invoke();
        }
    }
}
