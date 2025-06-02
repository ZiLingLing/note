using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�۲���
public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Image healthFillImage;

    private void OnEnable()
    {
        //�����¼�
        FindObjectOfType<PlayerHealth>().OnHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        //ȡ������
        var playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
            playerHealth.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float healthPercentage)
    {
        healthFillImage.fillAmount = healthPercentage;
    }
}
