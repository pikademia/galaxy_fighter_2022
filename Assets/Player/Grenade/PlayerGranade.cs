using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGranade : MonoBehaviour
{
    [SerializeField] GameObject[] childrenObjects;
    float attack, speed;

    public void InitializeBullet(float attack, float speed)
    {
        this.attack = attack;
        this.speed = speed;
    }


    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right);
        if (Input.GetMouseButtonDown(1))
        {
            Explode();
        }
    }

    void Explode()
    {
        speed = 0f;
        childrenObjects[0].SetActive(false);
        childrenObjects[1].SetActive(true);
        GetComponent<Collider2D>().enabled = true;
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthPoints hp = collision.gameObject.transform.parent.GetComponentInChildren<HealthPoints>();
        if (hp != null)
        {
            hp.TakeDamage(attack, childrenObjects[0].GetComponent<SpriteRenderer>().color);
        }
    }
}
