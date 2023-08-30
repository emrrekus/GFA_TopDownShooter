using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParticleFX : WeaponFX
{
    [SerializeField]
    private ParticleSystem[] _particleSystems;
    protected override void OnShot()
    {
        foreach (var p in _particleSystems)
        {
            p.Play();
        }
    }
}
