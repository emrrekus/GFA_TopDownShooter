using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFA.TDS.Movement
{
    public class ProjectTileMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        [SerializeField] private Vector3 _movementPlane = Vector3.one;

        [SerializeField] private bool _shouldDisableOnCollison;

        public bool ShouldDisableOnCollision
        {
            get => _shouldDisableOnCollison;
            set => _shouldDisableOnCollison = value;
        }


        [SerializeField] private bool _shouldDestroyOnCollison;

        public bool ShouldDestroyOnCollision
        {
            get => _shouldDestroyOnCollison;
            set => _shouldDestroyOnCollison = value;
        }

        [SerializeField] private bool _shouldBounce;

        public bool ShouldBounce
        {
            get => _shouldBounce;
            set => _shouldBounce = value;
        }

        [SerializeField] private float _pushPower;

        public event Action<RaycastHit> Impacted;

        private void Update()
        {
            var direction = transform.forward;
            direction.x *= _movementPlane.x;
            direction.y *= _movementPlane.y;
            direction.z *= _movementPlane.z;
            direction.Normalize();
            var distance = _speed * Time.deltaTime;
            
            var targetPosition = transform.position + direction * distance;

            if (Physics.Raycast(transform.position, direction, out var hit, distance))
            {
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(-hit.normal * _speed * _pushPower, hit.point, ForceMode.Impulse);
                }

                if (ShouldDisableOnCollision)
                {
                    enabled = false;
                }

                if (ShouldDestroyOnCollision)
                {
                    Destroy(gameObject);
                }

                targetPosition = hit.point;

                Impacted?.Invoke(hit);

                if (ShouldBounce)
                {
                    var reflectedDirection = Vector3.Reflect(direction, hit.normal);
                    transform.forward = reflectedDirection;
                }
            }


            transform.position = targetPosition;
        }
    }
}