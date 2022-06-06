using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonAttack : MonoBehaviour
{
    [Range(1, 50)] public int attack = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHP hp = collision.gameObject.GetComponent<PlayerHP>();
            if (hp != null)
            {
                hp.TakeDamage(attack, Color.white);
            }
            Destroy(gameObject);
        }
    }
}
