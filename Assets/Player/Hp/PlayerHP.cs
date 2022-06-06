using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [Range(1, 50)] public int maxHP = 10;
    [SerializeField] GameObject healthBarUIPrefab;
    [SerializeField] GameObject hitEffectPrefab;
    [SerializeField] GameObject gameOverMenuPrefab;
    GameObject healthBar;
    ParticleSystem hitEffect;
    SpriteRenderer spriteRend;
    Color spriteColor;
    int hp;
    Canvas canvas;
    Camera mainCam;
    Color mainCamBG;
    void Start()
    {
        mainCam = Camera.main;
        mainCamBG = mainCam.backgroundColor;
        if(hitEffectPrefab != null)
        {
            hitEffect = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity, transform).GetComponent<ParticleSystem>();
        }
        canvas = FindObjectOfType<Canvas>();
        if(healthBarUIPrefab != null)
        {
            healthBar = Instantiate(healthBarUIPrefab, canvas.transform);
        }
        spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
        spriteColor = spriteRend.color;
        hp = maxHP;
    }

    public void TakeDamage(int damage, Color mainColor)
    {
        hp -= damage;
        if (healthBar)
        {
            UpdateHealthBar();
        }
        StartCoroutine(ChangeBgColor());
        StartCoroutine(ChangeColor(mainColor));
        if (hitEffect != null)
        {
            var main = hitEffect.main;
            main.startColor = mainColor;
            hitEffect.Play();
        }
        if (hp <= 0)
        {
            Instantiate(gameOverMenuPrefab, canvas.transform);
            Destroy(gameObject);
        }
    }

    void UpdateHealthBar()
    {
        healthBar.GetComponent<PlayerUIHealthBar>().UpdateUI((float)hp / (float)maxHP);
    }

    IEnumerator ChangeColor(Color c)
    {
        spriteRend.color = c;
        yield return new WaitForSeconds(0.2f);
        spriteRend.color = spriteColor;
    }

    IEnumerator ChangeBgColor()
    {
        mainCam.backgroundColor = new Color(0.45f, 0.13f, 0.13f);
        yield return new WaitForSeconds(0.05f);
        mainCam.backgroundColor = mainCamBG;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            TakeDamage(hp, Color.white);
        }
    }
}
