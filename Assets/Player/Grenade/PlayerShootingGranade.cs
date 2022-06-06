using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingGranade : MonoBehaviour
{

    [Header("Grenade prefab should be in PlayerGrenade layer")]
    [Space]
    [SerializeField] GameObject granadePrefab;
    [SerializeField] Vector2 shootingPosition;
    [SerializeField] GameObject granadeUIPrefab;
    [SerializeField] AudioClip granadeShootSound;
    [Range(1, 20)] public float attack = 5;
    [Range(1.0f, 20.0f)] public float speed = 5f;
    [Range(0, 20)]  public int quantity = 3;
    Canvas canvas;
    AudioSource audios;
    int granadesLeft;
    bool isGranadeActive = false;
    GameObject granadeUI;
    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        audios = GetComponent<AudioSource>();
        granadesLeft = quantity;
        granadeUI = Instantiate(granadeUIPrefab, canvas.transform);
        if(granadeUI != null)
        {
            granadeUI.GetComponent<GranadeUI>().UpdateGranadeQuantity(granadesLeft);
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(granadesLeft > 0 && isGranadeActive == false)
            {
                if (audios != null && granadeShootSound != null)
                {
                    audios.PlayOneShot(granadeShootSound);
                }
                Shoot();
                isGranadeActive=true;
                granadesLeft--;
                if (granadeUI != null)
                {
                    granadeUI.GetComponent<GranadeUI>().UpdateGranadeQuantity(granadesLeft);
                }
            }
            else
            {
                isGranadeActive=false;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(granadePrefab, transform.position + (Vector3)shootingPosition, Quaternion.identity);
        bullet.GetComponent<PlayerGranade>().InitializeBullet(attack, speed);
    }
}
