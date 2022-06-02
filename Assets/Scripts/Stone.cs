using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Vector3 shootingDirection;
    Rigidbody2D rb;
    float attack;


    public void InitializeObject(float a)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.CompareTag("Player"))
        {
            HealthPoints hp = collision.transform.parent.GetComponent<HealthPoints>();
            if (hp != null)
            {
                hp.TakeDamage(attack, Color.white);
            }

        }
    }
}
