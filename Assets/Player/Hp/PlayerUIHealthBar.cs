using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHealthBar : MonoBehaviour
{
    [SerializeField] Image healthBarImg;

    private void Start()
    {
        UpdateUI(1f);
    }

    public void UpdateUI(float hp)
    {
        healthBarImg.fillAmount = hp;
    }
}
