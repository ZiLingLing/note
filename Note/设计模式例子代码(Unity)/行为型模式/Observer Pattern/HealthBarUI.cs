using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//观察者
public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Image healthFillImage;

    private void OnEnable()
    {
        //订阅事件
        FindObjectOfType<PlayerHealth>().OnHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        //取消订阅
        var playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
            playerHealth.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float healthPercentage)
    {
        healthFillImage.fillAmount = healthPercentage;
    }
}
