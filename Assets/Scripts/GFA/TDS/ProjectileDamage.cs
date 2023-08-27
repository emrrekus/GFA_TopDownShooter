using System;
using System.Collections;
using System.Collections.Generic;
using GFA.TDS.Movement;
using UnityEngine;


namespace GFA.TDS
{
    public class ProjectileDamage : MonoBehaviour
    {

        [SerializeField]
        private float _damage = 1;
        
        private ProjectTileMovement _projectTileMovement;

        private void Awake()
        {
            _projectTileMovement = GetComponent<ProjectTileMovement>();
        }

        private void OnEnable()
        {
            _projectTileMovement.Impacted += OnImpacted;
        }
 
        private void OnDisable()
        {
            _projectTileMovement.Impacted -= OnImpacted;
        }
        
        
        private void OnImpacted(RaycastHit obj)
        {
            if (obj.transform.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.ApplyDamage(_damage,gameObject);
            }
        }
    }
}

