using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] GameObject hitEffectPrefab;
    [Range(0.0f, 50.0f)] public float hP = 10f;
    PlayerUIHealthBar playerHealthBar;
    ParticleSystem hitEffect;
    float currentHp;
    SpriteRenderer spriteRend;
    Color spriteColor;

    private void Start()
    {
        hitEffect = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity, transform).GetComponent<ParticleSystem>();
        spriteRend = transform.Find("mainSprite").GetComponent<SpriteRenderer>();
        spriteColor = spriteRend.color;
        currentHp = hP;
        if (transform.CompareTag("Player"))
        {
            playerHealthBar = FindObjectOfType<PlayerUIHealthBar>();
        }
    }

    public void TakeDamage(float damage, Color mainColor)
    {
        currentHp -= damage;
        StartCoroutine(ChangeColor(mainColor));
        if(hitEffect != null)
        {
            if (hitEffect != null)
            {
                var main = hitEffect.main;
                main.startColor = mainColor;
                hitEffect.Play();
            }

        }
        if(currentHp < 0)
        {
            Destroy(gameObject);
        }

        if (transform.CompareTag("Player"))
        {
            if(playerHealthBar != null)
            {
                playerHealthBar.UpdateUI(currentHp / hP);
            }
        }
    }


    IEnumerator ChangeColor(Color c)
    {
        spriteRend.color = c;
        yield return new WaitForSeconds(0.2f);
        spriteRend.color = spriteColor;
    }
}
