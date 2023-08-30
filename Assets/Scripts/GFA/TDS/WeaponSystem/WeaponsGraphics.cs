using UnityEngine;

namespace GFA.TDS.WeaponSystem
{
    public class WeaponsGraphics : MonoBehaviour
    {
        [SerializeField] private Transform _shootTransform;
        public Transform ShootTransform => _shootTransform;
    }
}