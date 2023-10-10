using UnityEngine;

namespace GFA.TDS.WeaponSystem.FX
{
    public abstract class WeaponFX : MonoBehaviour
    {
        private WeaponsGraphics _weaponsGraphics;
        private void Awake()
        {
            _weaponsGraphics = GetComponent<WeaponsGraphics>();
        }

        private void OnEnable()
        {
            _weaponsGraphics.Shoot += OnShot;
        }

        private void OnDisable()
        {
            _weaponsGraphics.Shoot -= OnShot;
        }

        protected abstract void OnShot();

    }
}