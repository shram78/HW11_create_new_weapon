using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] protected Bullet Bullet;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private bool _isBued = false;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBued => _isBued;
    public float RateOfFire => _rateOfFire;

    public abstract void Shoot(Transform shootPoint, float _rateOfFire);

    public void Buy()
    {
        _isBued = true;
    }
}
