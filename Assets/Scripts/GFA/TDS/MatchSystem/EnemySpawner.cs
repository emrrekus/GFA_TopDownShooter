using System;
using System.Collections;
using UnityEngine;

namespace GFA.TDS.MatchSystem
{
    public class EnemySpawner : MonoBehaviour
    {
        private Camera _camera;


        private void Awake()
        {
            _camera = Camera.main;
            GameObject.FindGameObjectWithTag("MainCamera");
        }

        private void Start()
        {
            StartCoroutine(CreateEnemy());
        }

        private IEnumerator CreateEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                var vie
                _camera.ViewportToWorldPoint()
            }
        }
    }
}