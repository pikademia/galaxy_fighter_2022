using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vel;
    float moveSpeed;
    int attack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 16f;
        rb.velocity = vel * moveSpeed;
        Destroy(gameObject, 2f);
    }

    public void Initialize(Vector2 vel_p, int a){
        vel = vel_p.normalized;
        attack = a;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHP hp = collision.gameObject.GetComponent<PlayerHP>();
            if (hp != null)
            {
                hp.TakeDamage(attack, GetComponent<SpriteRenderer>().color);
            }
            Destroy(gameObject);
        }
    }

}
