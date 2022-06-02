using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField][Range(1f, 100f)] float attack = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            HealthPoints hp = collision.transform.GetComponent<HealthPoints>();
            if (hp != null)
            {
                hp.TakeDamage(attack, Color.white);
            }

        }
    }


}
