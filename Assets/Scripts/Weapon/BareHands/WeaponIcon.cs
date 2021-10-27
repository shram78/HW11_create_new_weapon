using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class WeaponIcon : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Image _icon;

    private void Start()
    {
        _icon = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _player.WeaponChanged += ShowCurrent;
    }

    private void OnDisable()
    {
        _player.WeaponChanged -= ShowCurrent;
    }

    private void ShowCurrent(Weapon weapon)
    {
        _icon.sprite = weapon.Icon;
    }
}
