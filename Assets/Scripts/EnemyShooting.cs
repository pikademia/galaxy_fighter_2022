using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform aim;
    [Range(1.0f, 10.0f)] public float attack = 1f;
    [Range(5.0f, 30.0f)] public float bulletSpeed = 5f;
    [Range(0.2f, 5.0f)]  public float shootingSpeed = 2f;
    [Range(10f, 50.0f)]  public float playerCheckDistance = 20f;

    SpriteRenderer spriteRend;
    Color32 spriteColor;
    Transform player;
    Vector3 playerPos;
    bool playerDetected = false;

    void Start()
    {
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        spriteColor = spriteRend.color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(CheckPlayerPos());
    }


    IEnumerator CheckPlayerPos()
    {
        if (player != null && playerDetected == false)
        {
            playerPos = player.position;
            if(transform.position.x - playerPos.x < playerCheckDistance)
            {
                StartCoroutine(Shoot());
                playerDetected = true;
            }
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(CheckPlayerPos());
        }
    }

    IEnumerator Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, aim.position, Quaternion.identity);
        bullet.GetComponentInChildren<SpriteRenderer>().color = spriteColor;
        bullet.GetComponent<EnemyBullet>().InitializeBullet(attack, bulletSpeed);

        yield return new WaitForSeconds(1f/shootingSpeed);
        StartCoroutine(Shoot());
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - playerCheckDistance, transform.position.y, transform.position.z));
    }

}
