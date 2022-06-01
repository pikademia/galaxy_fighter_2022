using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralUI : MonoBehaviour
{
    [SerializeField] Button btnExit;
    void Start()
    {
        btnExit.onClick.AddListener(ExitGame);
    }

    public void ExitGame()
    {
        Debug.Log("exit");
    }


}
