using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Vector2 shootingPos;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] AudioClip shootSound;
    [Range(1, 20f)] public int attack = 1;
    [Range(5, 50)] public int speed = 20;
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
        GameObject bullet = Instantiate(bulletPrefab, transform.position + (Vector3)shootingPos, Quaternion.identity);
        bullet.GetComponentInChildren<SpriteRenderer>().color = spriteColor;
        bullet.GetComponent<PlayerBullet>().InitializeBullet(attack, speed);
    }
}
