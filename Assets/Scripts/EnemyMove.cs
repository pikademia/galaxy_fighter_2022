using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rb;

    [Range(0.1f, 2.0f)] public float height = 0.1f;
    [Range(0f, 15.0f)] public float speed = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rb.velocity = Vector2.up * speed * (Mathf.Sin(Time.time* (1/height)));
    }
}
