using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource audios;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    public void PlayDestroySound()
    {
        audios.PlayOneShot(audioClips[0]);
    }

}
