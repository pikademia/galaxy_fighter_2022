using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShipShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [Range(1, 15)] public int attack = 5;
    [Range(2, 30)] public int bulletSpeed = 5;
    [Range(0.2f, 5.0f)] public float shootingSpeed = 2f;
    [Range(10f, 50.0f)] public float playerCheckDistance = 20f;
    [SerializeField] GameObject playerColliderPrefab;
    Vector3 shootingPos = new Vector3(1f, 0f, 0f);
    SpriteRenderer spriteRend;
    Color32 spriteColor;
    Transform player;
    Vector3 playerPos;
    bool playerDetected = false;
    GameObject playerCollider;
    void Start()
    {
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        spriteColor = spriteRend.color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(CheckPlayerPos());
        playerCollider = Instantiate(playerColliderPrefab, transform.position - new Vector3(5f, transform.position.y, 0f), Quaternion.identity);
    }


    IEnumerator CheckPlayerPos()
    {
        if (player != null && playerDetected == false)
        {
            playerPos = player.position;
            if (transform.position.x - playerPos.x < playerCheckDistance)
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
        GameObject bullet = Instantiate(bulletPrefab, transform.position - shootingPos, Quaternion.identity);
        bullet.GetComponentInChildren<SpriteRenderer>().color = spriteColor;
        bullet.GetComponent<EnemyBullet>().InitializeBullet(attack, bulletSpeed);
        yield return new WaitForSeconds(1f / shootingSpeed);
        StartCoroutine(Shoot());
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - playerCheckDistance, transform.position.y, transform.position.z));
    }

    private void OnDestroy()
    {
        Destroy(playerCollider);
    }
}
