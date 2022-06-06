using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorAsSprite : MonoBehaviour
{
    SpriteRenderer spriteRend;
    ParticleSystem engineParticle;

    private void Start()
    {
        spriteRend = transform.parent.GetComponentInChildren<SpriteRenderer>();
        engineParticle = GetComponentInChildren<ParticleSystem>();
        var main = engineParticle.main;
        main.startColor = spriteRend.color;

    }
}
