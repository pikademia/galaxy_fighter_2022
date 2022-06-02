using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vel;
    float moveSpeed;
    float attack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 16f;
        rb.velocity = vel * moveSpeed;
        Destroy(gameObject, 2f);
    }

    public void Initialize(Vector2 vel_p, float a){
        vel = vel_p.normalized;
        attack = a;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.CompareTag("Player"))
        {
            HealthPoints hp = collision.transform.parent.GetComponent<HealthPoints>();
            if (hp != null)
            {
                hp.TakeDamage(attack, GetComponent<SpriteRenderer>().color);
            }

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        Destroy(gameObject);
    }
}
