using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFA.TDS.Movement.Tests
{
    public class MovementInputTest : MonoBehaviour
    {
        [SerializeField] private Vector2 _movementInput;

        [SerializeField] private CharacterMovement _characterMovement;

        [SerializeField] private Vector3 _externalForceValue;

        private void Update()
        {

            if (UnityEngine.InputSystem.Keyboard.current.spaceKey.wasPressedThisFrame)
                _characterMovement.ExternalForce += _externalForceValue;
                
            _characterMovement.MovementInput = _movementInput;

        }
    }

}
