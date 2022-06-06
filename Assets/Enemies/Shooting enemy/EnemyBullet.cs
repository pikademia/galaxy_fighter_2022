using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] SpriteRenderer bulletSR;
    int attack, speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    public void InitializeBullet(int attack, int speed)
    {
        this.attack = attack;
        this.speed = speed;
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.left *  speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHP hp = collision.gameObject.GetComponent<PlayerHP>();
            if (hp != null)
            {
                hp.TakeDamage(attack, bulletSR.color);
            }
            Destroy(gameObject);
        }
    }
}
