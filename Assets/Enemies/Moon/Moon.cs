﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] [Range(1f, 5f)] float speed = 1.5f;
    [SerializeField][Range(1f, 45f)]  float maxRotation = 32f;
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }
}
