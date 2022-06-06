using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rb;

    [Range(1f, 50f)] public float distanceVertical = 20f;
    [Range(0f, 10f)] public float speedVertical = 1f;
    [Range(10f, 50.0f)] public float playerCheckDistance = 20f;
    [Range(0f, 20f)] public float speedHorizontal = 1f;
    Transform player;
    Vector3 playerPos;
    bool playerDetected = false;
    float counter = 0f;
    float activeSpeedHorizontal;
    void Start()
    {
        activeSpeedHorizontal = 0f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(CheckPlayerPos());
    }

    IEnumerator CheckPlayerPos()
    {
        if (player != null && playerDetected == false)
        {
            playerPos = player.position;
            if (transform.position.x - playerPos.x < playerCheckDistance)
            {
                activeSpeedHorizontal = speedHorizontal;
                playerDetected = true;
            }
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(CheckPlayerPos());
        }

    }


    void FixedUpdate()
    {
        if(speedVertical > 0f)
        {
            counter += (1f / distanceVertical);
            rb.velocity = new Vector2(activeSpeedHorizontal * -1f, Mathf.Sin(counter)) * speedVertical;

        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position - new Vector3(0f, 0.2f, 0f), new Vector3(transform.position.x - playerCheckDistance, transform.position.y - 0.2f, transform.position.z));
    }
}
