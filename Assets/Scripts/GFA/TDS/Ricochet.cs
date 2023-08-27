using System;
using System.Collections;
using System.Collections.Generic;
using GFA.TDS.Movement;
using UnityEngine;


namespace GFA.TDS
{
    public class Ricochet : MonoBehaviour
    {
        [SerializeField] private float _radius;

        [SerializeField] private int _ricochetCount = 5;

        [SerializeField] private bool _removeOnComplete;

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

        private void OnImpacted(RaycastHit raycastHit)
        {
            if (_ricochetCount <= 0)
            {
                if(_removeOnComplete){Destroy(this);}
                
                return;;
            }
            var hits = Physics.OverlapSphere(raycastHit.point, _radius);

            foreach (var hit in hits)
            {
                if(hit.transform == raycastHit.transform) continue;
                if (hit.transform.TryGetComponent<IDamageable>(out var _))
                {
                    var dir = (hit.transform.position - transform.position).normalized;
                    transform.forward = dir;
                    _ricochetCount--;
                    return;
                    
                }
            }
        }
    }
}