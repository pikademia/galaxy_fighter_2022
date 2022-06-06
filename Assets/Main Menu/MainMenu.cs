using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button btnPlay;
    [SerializeField] Button btnExit;
    void Start()
    {
        btnPlay.onClick.AddListener(PlayGame);
        btnExit.onClick.AddListener(QuitTheGame);
    }

    private void QuitTheGame()
    {
        Application.Quit(); 
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

}
