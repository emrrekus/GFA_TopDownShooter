using System;
using System.Collections;
using System.Collections.Generic;
using GFA.TDS.WeaponSystem;
using UnityEngine;

public abstract class WeaponFX : MonoBehaviour
{
    private WeaponsGraphics _weaponsGraphics;
    private void Awake()
    {
        _weaponsGraphics = GetComponent<WeaponsGraphics>();
    }

    private void OnEnable()
    {
        _weaponsGraphics.Shoot += OnShot;
    }

    private void OnDisable()
    {
        _weaponsGraphics.Shoot -= OnShot;
    }

    protected abstract void OnShot();

}