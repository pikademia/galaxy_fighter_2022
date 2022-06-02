using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HealthPoints : MonoBehaviour
{
    [SerializeField] GameObject hitEffectPrefab;
    [SerializeField] GameObject destroyEffect;
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
            if (SoundManager.Instance)
            {
                SoundManager.Instance.PlayDestroySound();
            }
            if(destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        if (transform.CompareTag("Player"))
        {
            StartCoroutine(ChangeBgColor());
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

    IEnumerator ChangeBgColor()
    {
        Camera cam = Camera.main;
        Color color = cam.backgroundColor;
        cam.backgroundColor = new Color(0.45f,0.13f,0.13f);
        yield return new WaitForSeconds(0.05f);
        cam.backgroundColor = color;
    }
}
