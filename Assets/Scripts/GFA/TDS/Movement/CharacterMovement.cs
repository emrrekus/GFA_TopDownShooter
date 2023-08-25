using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFA.TDS.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MonoBehaviour
    
    {
        private CharacterController _characterController;

        public Vector3 ExternalForce { get; set; }
        public Vector2 MovementInput { get; set; }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var movement = new Vector3(MovementInput.x, 0, MovementInput.y);

            _characterController.SimpleMove(movement + ExternalForce);

            ExternalForce = Vector3.Lerp(ExternalForce, Vector3.zero, 4 * Time.deltaTime);
        }
    }
}