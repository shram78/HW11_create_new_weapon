using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BareHands : Weapon
{
    public override void Shoot(Transform shootPoint, float _rateOfFire)
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
    }
}