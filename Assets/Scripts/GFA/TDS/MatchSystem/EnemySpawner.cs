using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

namespace GFA.TDS.MatchSystem
{
    public class EnemySpawner : MonoBehaviour
    {
        private Camera _camera;

        private Plane _plane = new Plane(Vector3.up, Vector3.zero);

        [SerializeField] private float _offset;
        [SerializeField] private float _spawnRate;

        [SerializeField] private MatchInstance _matchInstance;

        [SerializeField] private EnemySpawnData _enemySpawnData;

        private GameObject[] _pooledObjects;
        
        private void Awake()
        {
            _camera = Camera.main;
            CreatePooledObjects();
        }

        private void CreatePooledObjects()
        {
           
        }

        private void Start()
        {
            StartCoroutine(CreateEnemy());
        }

        private Vector3 GetSpawnOffsetByViewportPosition(Vector3 vector, float sign)
        {
            return vector * sign * _offset;
        }


        private IEnumerator CreateEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                if (!_enemySpawnData.TryGetEntryByTime(_matchInstance.Time, out SpawnEntry entry)) continue;
                var spawnPerCall = ((float)entry.SpawnCount / entry.Duration) * _spawnRate;
              

                    for (int i = 0; i < spawnPerCall; i++)
                    {
                        var viewportPoint = GetViewportPoint(out var offset);

                        var ray = _camera.ViewportPointToRay(viewportPoint);

                        ;
                        if (_plane.Raycast(ray, out float enter))
                        {
                            var objSpawn = entry.Prefabs[UnityEngine.Random.Range(0, entry.Prefabs.Length)];
                            var worldPosition = ray.GetPoint(enter) + offset;
                            var inst = Instantiate(objSpawn, worldPosition, quaternion.identity);
                            inst.transform.position = worldPosition;
                        }
                    }
                
            }
        }

        private Vector3 GetViewportPoint(out Vector3 offset)
        {
            var viewportPoint = Vector3.zero;

            offset = Vector3.zero;

            if (UnityEngine.Random.value > 0.5f)
            {
                var dir = Mathf.Round(UnityEngine.Random.value);
                viewportPoint = new Vector3(dir, UnityEngine.Random.value);

                offset = GetSpawnOffsetByViewportPosition(Vector3.right, dir < 0.001f ? -1f : 1f);
            }
            else
            {
                var dir = Mathf.Round(UnityEngine.Random.value);
                viewportPoint = new Vector3(UnityEngine.Random.value, dir);

                offset = GetSpawnOffsetByViewportPosition(Vector3.forward, dir < 0.001f ? -1f : 1f);
            }

            return viewportPoint;
        }
    }
}