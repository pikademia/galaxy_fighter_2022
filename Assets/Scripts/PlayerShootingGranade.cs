using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingGranade : MonoBehaviour
{
    [SerializeField] Transform aim;
    [SerializeField] GameObject granadePrefab;
    [SerializeField] AudioClip granadeShootSound;
    [Range(3.0f, 20.0f)] public float attack = 3f;
    [Range(1.0f, 20.0f)] public float speed = 5f;
    [Range(0, 20)]  public int quantity = 1;
    AudioSource audios;
    int granadesLeft;
    bool isGranadeActive = false;
    GranadeUI granadeUI;

    private void Start()
    {
        audios = GetComponent<AudioSource>();
        granadesLeft = quantity;
        granadeUI = FindObjectOfType<GranadeUI>();
        if(granadeUI != null)
        {
            granadeUI.UpdateGranadeQuantity(granadesLeft);
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
                    granadeUI.UpdateGranadeQuantity(granadesLeft);
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
        GameObject bullet = Instantiate(granadePrefab, aim.position, Quaternion.identity);
        bullet.GetComponent<PlayerGranade>().InitializeBullet(attack, speed);
    }
}
