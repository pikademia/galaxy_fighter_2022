using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGranade : MonoBehaviour
{
    [SerializeField] SpriteRenderer bulletSR;
    [SerializeField] SpriteRenderer boomEffectSprite;
    [SerializeField] Collider2D col;
    [SerializeField] AudioClip explosionSound;
    float attack, speed;
    Rigidbody2D rb;
    AudioSource audios;
    void Start()
    {
        audios = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void InitializeBullet(float attack, float speed)
    {
        this.attack = attack;
        this.speed = speed;
    }

    void FixedUpdate()
    {
       rb.velocity = Vector2.right * speed;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (audios != null && explosionSound != null)
            {
                audios.PlayOneShot(explosionSound);
            }
            Explode();
        }
    }

    void Explode()
    {
        speed = 0f;
        bulletSR.enabled = false;
        boomEffectSprite.gameObject.SetActive(true);
        col.enabled = true;
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthPoints hp = collision.transform.GetComponentInParent<HealthPoints>();
        if (hp != null)
        {
            hp.TakeDamage(attack, bulletSR.color);
        }
    }
}
