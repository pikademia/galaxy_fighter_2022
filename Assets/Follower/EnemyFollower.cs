using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    [SerializeField][Range(1f, 20.0f)] float enemySpeed = 2f;
    [SerializeField][Range(1f, 20.0f)] float attack = 2f;
    [Range(10f, 50.0f)] public float playerCheckDistance = 20f;
    GameObject target;
    Vector2 targetPos;
    float speed;

    private void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
        speed = 0f;
    }

    void Update()
    {
        if(target != null){ 
            targetPos = target.transform.position;
            if(transform.position.x - targetPos.x < playerCheckDistance)
            {
                speed = enemySpeed;
                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                float angle = Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);         
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            HealthPoints hp = collision.transform.GetComponent<HealthPoints>();
            if (hp != null)
            {
                hp.TakeDamage(attack, GetComponentInChildren<SpriteRenderer>().color);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - playerCheckDistance, transform.position.y, transform.position.z));
    }
}
