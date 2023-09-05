using System;
using UnityEngine;

namespace GFA.TDS.MatchSystem
{
    public class MatchController : MonoBehaviour
    {
        [SerializeField] private MatchInstance _matchInstance;

        private void Update()
        {
            _matchInstance.AddTime(Time.deltaTime);
        }
    }
}
