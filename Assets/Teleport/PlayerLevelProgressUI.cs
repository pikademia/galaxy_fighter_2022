using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelProgressUI : MonoBehaviour
{
    [SerializeField] Image progressBarImg;

    public void UpdateUI(float progress)
    {
        progressBarImg.fillAmount = 1f - progress;
    }
}
