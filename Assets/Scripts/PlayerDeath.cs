using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    UIManager uimanager;
    private void Start()
    {
        uimanager = FindObjectOfType<UIManager>();
    }

    private void OnDestroy()
    {
        if (uimanager != null)
        {
            uimanager.ShowGameOverMenu();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);       
        }
    }
}
