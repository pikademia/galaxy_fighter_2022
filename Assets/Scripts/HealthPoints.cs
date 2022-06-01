using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [Range(0.0f, 50.0f)] public float hP = 10f;
    PlayerUIHealthBar playerHealthBar;
    float currentHp;

    private void Start()
    {
        currentHp = hP;
        if (transform.CompareTag("Player"))
        {
            playerHealthBar = FindObjectOfType<PlayerUIHealthBar>();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if(currentHp < 0)
        {
            Destroy(gameObject);
        }

        if (transform.CompareTag("Player"))
        {
            if(playerHealthBar != null)
            {
                playerHealthBar.UpdateUI(currentHp / hP);
            }
        }
    }
}
