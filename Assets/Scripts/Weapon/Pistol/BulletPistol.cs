using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPistol : Bullet
{
    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }
}
