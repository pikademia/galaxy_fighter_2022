using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rb;

    [Range(1f, 50f)] public float distance = 20f;
    [Range(0f, 10f)] public float speed = 1f;
    float counter = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }


    void FixedUpdate()
    {
        if(speed > 0f)
        {
            counter += (1f / distance);
            rb.velocity = new Vector2(0f, Mathf.Sin(counter)) * speed;

        }

    }
}
