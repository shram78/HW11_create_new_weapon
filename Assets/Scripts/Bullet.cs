﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
