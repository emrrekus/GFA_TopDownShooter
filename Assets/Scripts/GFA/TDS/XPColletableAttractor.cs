using System;
using System.Collections;
using GFA.TDS.Utils;
using UnityEngine;

namespace GFA.TDS
{
    public class XPColletableAttractor : MonoBehaviour
    {
        [SerializeField] private float _tickInterval = .7f;

        [SerializeField] private float _atrractionRadius = 10;
        private Collider[] _collectablesInRange = new Collider[20];

        [SerializeField] private LayerMask _layerMask;

        private void Start()
        {
            StartCoroutine(Execute());
        }

        private IEnumerator Execute()
        {
            while (true)
            {
                yield return new WaitForSeconds(_tickInterval);
                if (!enabled) yield return null;

                var hitCount = Physics.OverlapSphereNonAlloc(transform.position, _atrractionRadius, _collectablesInRange,
                    _layerMask);

                for (int i = 0; i < hitCount; i++)
                {
                    var collider = _collectablesInRange[i];
                    collider.enabled = false;
                    var follower = collider.gameObject.AddComponent<SmoothFollower>();
                    follower.Target = transform;
                    follower.ReachedDestination += () =>
                    {
                        Destroy(follower.gameObject);
                    };
                }
            }
        }
    }
}