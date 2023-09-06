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

        [SerializeField]
        private MatchInstance _matchInstance;

        [SerializeField] private EnemySpawnData _enemySpawnData;
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            StartCoroutine(CreateEnemy());
        }

        private Vector3 GetSpawnOffsetByViewportPosition(Vector3 vector, float sign)
        {
            return vector * sign * _offset;
        }

        private GameObject GetSpawnObject()
        {
            var time = _matchInstance.Time;
            if (_enemySpawnData.TryGetEntryByTime(time, out SpawnEntry entry))
            {
                return entry.Prefabs[UnityEngine.Random.Range(0, entry.Prefabs.Length)];
            }

            return null;
        }
        
        private IEnumerator CreateEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                var viewportPoint = Vector3.zero;

                var offset = Vector3.zero;

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


                var ray = _camera.ViewportPointToRay(viewportPoint);

                if (_plane.Raycast(ray, out float enter))
                {
                    var worldPosition = ray.GetPoint(enter) + offset;
                    var inst = Instantiate(GetSpawnObject(), worldPosition,quaternion.identity);
                    inst.transform.position = worldPosition;
                }
            }
        }
    }
}