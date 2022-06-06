using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GranadeUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtGranadesQuantity;


    public void UpdateGranadeQuantity(int q)
    {
        txtGranadesQuantity.text = q.ToString();
    }
}
