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

        private void Update()
        {
            var direction = transform.forward;
            var distance = _speed * Time.deltaTime;
            var targetPosition = transform.position + direction * distance;

            if (Physics.Raycast(transform.position, direction, out var hit, distance))
            {
                if (ShouldDisableOnCollision)
                {
                    enabled = false;
                }

                if (ShouldDestroyOnCollision)
                {
                    Destroy(gameObject);
                }

                targetPosition = hit.point;

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