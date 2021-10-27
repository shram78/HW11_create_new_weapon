using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons; 
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currenWeaponNumber;
    private int _currentHealh;
    private Animator _animator;
    private string _isShooting = "isShooting";
    private float _lastShootTime;

    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<Weapon> WeaponChanged;

    private void Start()
    {
        ChangeWeapon(_weapons[_currenWeaponNumber]);
        _currentHealh = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(_isShooting, false);

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0) && _lastShootTime <= 0)
            {
                _animator.SetBool(_isShooting, true);

                _currentWeapon.Shoot(_shootPoint, _currentWeapon.RateOfFire);

                _lastShootTime = _currentWeapon.RateOfFire;
            }
        }

        _lastShootTime -= Time.deltaTime;
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
        MoneyChanged?.Invoke(Money); 
    }

    public void NextWeapon()
    {
        if (_currenWeaponNumber == _weapons.Count - 1)
            _currenWeaponNumber = 0;

        else
            _currenWeaponNumber++;

        ChangeWeapon(_weapons[_currenWeaponNumber]); 
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
        WeaponChanged?.Invoke(_currentWeapon);
    }
}