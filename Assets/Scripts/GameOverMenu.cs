using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] Button btnRestart;
    [SerializeField] Button btnMenu;
    int sceneNumber;

    void Start()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        btnRestart.onClick.AddListener(ReloadLevel);
        btnMenu.onClick.AddListener(GoToMenu);
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
