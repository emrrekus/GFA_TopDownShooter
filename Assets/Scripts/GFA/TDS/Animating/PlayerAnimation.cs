using System;
using UnityEngine;

namespace GFA.TDS.Animating
{
    public class PlayerAnimation : MonoBehaviour
    {
        public Vector3 Velocity { get; set; }
        [SerializeField]private Animator _animator;
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");


        private void Update()
        {
          var transformVelocity= Quaternion.Euler(0, -transform.eulerAngles.y, 0)* Velocity;
            _animator.SetFloat(Horizontal,transformVelocity.x);
            _animator.SetFloat(Vertical,transformVelocity.z);
        }
    }
}
