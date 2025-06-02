using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject deathPanel;

    private void OnEnable()
    {
        FindObjectOfType<PlayerHealth>().OnPlayerDeath += ShowDeathPanel;
    }

    private void OnDisable()
    {
        var playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
            playerHealth.OnPlayerDeath -= ShowDeathPanel;
    }

    private void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
    }
}
