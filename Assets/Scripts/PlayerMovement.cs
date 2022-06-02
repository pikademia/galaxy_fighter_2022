using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float playerSpeed = 12f;
    float dirX, dirY;
    Vector3 dir;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
       // dir = new Vector3(dirX, dirY, 0f).normalized;
        dir = new Vector3(dirX, dirY, 0f);

    }

    private void FixedUpdate()
    {
        rb.velocity = dir * playerSpeed;
    }
}
