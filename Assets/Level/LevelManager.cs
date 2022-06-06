using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject GeneralUIPrefab;
    [SerializeField] AudioClip levelBGSound;
    AudioSource audios;
    Canvas canvas;

    private void Start()
    {
        audios = GetComponent<AudioSource>();
        canvas = FindObjectOfType<Canvas>();
        if (GeneralUIPrefab != null)
        {
            Instantiate(GeneralUIPrefab, canvas.transform);
        }
        audios.clip = levelBGSound;
        audios.loop = true;
        audios.Play();
    }


}
