using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBareHands : Bullet
{
    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);

        transform.Rotate(0, 0, 0.3f);

        Destroy(gameObject, 0.3f);
    }
}