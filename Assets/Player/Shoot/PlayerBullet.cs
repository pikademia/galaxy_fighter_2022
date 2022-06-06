using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    int attack, speed;
    void Start()
    {
        Destroy(gameObject, 14f/speed);
    }

    public void InitializeBullet(int attack, int speed)
    {
        this.attack = attack;
        this.speed = speed;
    }

    void Update()
    {
        gameObject.transform.Translate(speed * Time.deltaTime * Vector2.right);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthPoints hp = collision.gameObject.GetComponent<HealthPoints>();
        if(hp != null)
        {
            hp.TakeDamage(attack, GetComponentInChildren<SpriteRenderer>().color);   
        }
        Destroy(gameObject);
    }
}
