using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Vector3 shootingDirection;
    Rigidbody2D rb;
    int attack;


    public void InitializeObject(int a)
    {
        attack = a;
    }
    void Start()
    {
        float randX = Random.Range(-7,-12);
        float randY = Random.Range(1.5f,3.5f);
        rb = GetComponent<Rigidbody2D>();
        shootingDirection = new Vector3(randX, randY, 0f);
        rb.AddForce(shootingDirection, ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHP hp = collision.gameObject.GetComponent<PlayerHP>();
            if (hp != null)
            {
                hp.TakeDamage(attack, Color.yellow);
            }
            Destroy(gameObject);
        }
    }
}
