using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFA.TDS.Movement.Tests
{
    public class ShooterTest : MonoBehaviour
    {
        [SerializeField]
        private GameObject _projectilePrefab;
        void Start()
        {
            StartCoroutine(Shooter());
        }

        private IEnumerator Shooter()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);
                Instantiate(_projectilePrefab, transform.position, transform.rotation);
            }
          
        }
        
    }
}
