using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���۲���
public class PlayerHealth : MonoBehaviour
{
    // �����¼�
    public event Action<float> OnHealthChanged;//Ѫ���仯�¼�
    public event Action OnPlayerDeath;//��������¼�

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

        //֪ͨ�۲���Ѫ���仯
        OnHealthChanged?.Invoke(currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            //֪ͨ�۲����������
            OnPlayerDeath?.Invoke();
        }
    }
}
