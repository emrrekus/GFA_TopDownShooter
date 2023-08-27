using System.Collections;
using System.Collections.Generic;
using GFA.TDS;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour,IDamageable
{
    [SerializeField]
    private float _health = 30;
    public void ApplyDamage(float damage, GameObject causer = null)
    {
        _health -= damage;
        if (_health <= 0)
            Explode();
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}
