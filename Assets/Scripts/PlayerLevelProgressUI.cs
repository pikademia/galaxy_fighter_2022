using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelProgressUI : MonoBehaviour
{
    Transform player;
    Transform finishPoint;

    [SerializeField] Image progressBarImg;
    float distance, currentDistance;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        finishPoint = GameObject.FindGameObjectWithTag("FinishPoint").transform;
        if(player!=null && finishPoint != null)
        {
            distance = finishPoint.position.x - player.position.x;
            currentDistance = distance;
        }
        StartCoroutine(CheckDistance());
    }

    public void UpdateUI()
    {
        if (player != null && finishPoint != null)
        {
            currentDistance = finishPoint.position.x - player.position.x;
        }
        progressBarImg.fillAmount = 1f - (currentDistance / distance);
    }

    IEnumerator CheckDistance()
    {
        UpdateUI();
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(CheckDistance());
    }
}
