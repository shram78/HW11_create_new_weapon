using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons; // надо будет закрыть, что бы орудие можно было добавлять только из магназина
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentHealh;
    private Animator _animator;

    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentWeapon = _weapons[0]; // временное решение, этого не будет
        _currentHealh = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }
    
    public void ApplyDamage(int damage)
    {
        _currentHealh -= damage;
        HealthChanged?.Invoke(_currentHealh, _health);


        if (_currentHealh <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(int money)
    {
        Money += money;
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
    }
}
