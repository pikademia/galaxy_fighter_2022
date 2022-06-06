using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject levelProgressUIPrefab;
    GameObject levelProgressUI;
    Canvas canvas;
    int sceneNumber;
    GameObject player;
    Transform playerT;
    float distance, currentDistance;

    private void Start()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;

        if(levelProgressUIPrefab != null)
        {
            canvas = FindObjectOfType<Canvas>();
            levelProgressUI = Instantiate(levelProgressUIPrefab, canvas.transform);
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerT = player.GetComponent<Transform>();
                distance = transform.position.x - playerT.position.x;
                StartCoroutine(CheckDistance());
            }
        }
    }

    IEnumerator CheckDistance()
    {
        currentDistance = transform.position.x - playerT.position.x;
        UpdateUI();
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(CheckDistance());
    }

    void UpdateUI()
    {
        levelProgressUI.GetComponent<PlayerLevelProgressUI>().UpdateUI(currentDistance / distance);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            sceneNumber++;
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
