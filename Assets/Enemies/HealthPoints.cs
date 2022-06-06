using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthPoints : MonoBehaviour
{
    [SerializeField] GameObject hitEffectPrefab;
    [SerializeField] GameObject destroyEffect;
    [Range(1, 50)] public int hP = 10;
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
    }

    public void TakeDamage(float damage, Color mainColor)
    {
        currentHp -= damage;
        StartCoroutine(ChangeColor(mainColor));
        if(hitEffect != null)
        {
                var main = hitEffect.main;
                main.startColor = mainColor;
                hitEffect.Play();

        }

        if(currentHp < 0)
        {
            if(destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    IEnumerator ChangeColor(Color c)
    {
        spriteRend.color = c;
        yield return new WaitForSeconds(0.2f);
        spriteRend.color = spriteColor;
    }
}
