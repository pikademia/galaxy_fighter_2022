using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float attack, speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 16f/speed);
    }

    public void InitializeBullet(float attack, float speed)
    {
        this.attack = attack;
        this.speed = speed;
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.right* speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthPoints hp = collision.transform.GetComponent<HealthPoints>();
        if(hp != null)
        {
            hp.TakeDamage(attack);   
        }
        Destroy(gameObject);
    }
}
