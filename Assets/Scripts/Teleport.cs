using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    int sceneNumber;

    private void Start()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("Player"))
        {
            sceneNumber++;
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
