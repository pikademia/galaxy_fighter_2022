using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameOverMenu gameOverMenu;
    public void ShowGameOverMenu()
    {
        gameOverMenu.gameObject.SetActive(true);
    }
}
