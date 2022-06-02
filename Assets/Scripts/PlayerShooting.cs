using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform aim;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] AudioClip shootSound;
    [Range(1.0f, 10.0f)] public float attack = 1f;
    [Range(5.0f, 40.0f)] public float speed = 20f;
    SpriteRenderer spriteRend;
    Color32 spriteColor;
    AudioSource audios;

    void Start()
    {
        audios = GetComponent<AudioSource>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        spriteColor = spriteRend.color;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            if(audios != null && shootSound != null)
            {
                audios.PlayOneShot(shootSound);
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, aim.position, Quaternion.identity);
        bullet.GetComponentInChildren<SpriteRenderer>().color = spriteColor;
        bullet.GetComponent<PlayerBullet>().InitializeBullet(attack, speed);
    }
}
