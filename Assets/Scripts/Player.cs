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
    private int _currenWeaponNumber;
    private int _currentHealh;
    private Animator _animator;

    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        ChangeWeapon(_weapons[_currenWeaponNumber]);
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
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
        MoneyChanged?.Invoke(Money); // используй для отображения баланса на главном экране
    }

    public void NextWeapon()
    {
        if (_currenWeaponNumber == _weapons.Count - 1)
            _currenWeaponNumber = 0;
        else
            _currenWeaponNumber++;

        ChangeWeapon(_weapons[_currenWeaponNumber]); // можем передавать ориже, но секйчвс идекс
    }

    public void PreviousWeapon()
    {
        if (_currenWeaponNumber == 0)
            _currenWeaponNumber = _weapons.Count - 1;
        else
            _currenWeaponNumber--;

        ChangeWeapon(_weapons[_currenWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
