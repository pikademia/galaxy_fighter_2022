using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneralUI : MonoBehaviour
{
    [SerializeField] Button btnExit;
    void Start()
    {
        btnExit.onClick.AddListener(ExitGame);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }


}
