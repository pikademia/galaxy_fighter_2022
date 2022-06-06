using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneShooter : MonoBehaviour
{
    [SerializeField] GameObject StonePrefab;
    [SerializeField] [Range(1f,4f)] float stoneShootingDelay = 2f;
    [SerializeField] [Range(1,100)] int stoneAttack = 10;

    IEnumerator Shoot(){
        if(StonePrefab != null){
            GameObject g = Instantiate(StonePrefab, transform.position, Quaternion.identity);
            g.GetComponent<Stone>().InitializeObject(stoneAttack);
            yield return new WaitForSeconds(stoneShootingDelay);
            StartCoroutine(Shoot());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(Shoot());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

}
