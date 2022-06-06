using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class WinMenu : MonoBehaviour
{
    [SerializeField] Button btnGoToMenu;
    void Start()
    {
        btnGoToMenu.onClick.AddListener(GoToMenu);
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
