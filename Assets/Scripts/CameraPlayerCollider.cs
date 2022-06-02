using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerCollider : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player") || collision.transform.CompareTag("Obstacle") || collision.transform.CompareTag("EnemyFollower"))
        {
            return;
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
