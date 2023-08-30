using System;
using System.Collections;
using System.Collections.Generic;
using GFA.TDS.WeaponSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GFA.TDS
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        private float _recoilValue = 0f;

        private float _lastShootTime;
        public bool CanShoot => Time.time > _lastShootTime + _weapon.Firerate;

        [SerializeField] private GameObject _defualtprojectilePrefab;

   

        private WeaponsGraphics _activeWeaponGraphics;

        [SerializeField] private Transform _weaponContainer;

        private void Start()
        {
            if (_weapon) CreateGraphics();
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (_activeWeaponGraphics){ ClearGraphics();}
            _weapon = weapon;
            if (_weapon) {CreateGraphics();}
        }

        private void CreateGraphics()
        {
            if (!_weapon) return;
            var instance = Instantiate(_weapon.WeaponsGraphics, _weaponContainer);
            instance.transform.localPosition = Vector3.zero;
            _activeWeaponGraphics = instance;
        }

        private void ClearGraphics()
        {
            if (!_activeWeaponGraphics) return;
            Destroy(_activeWeaponGraphics.gameObject);
            _activeWeaponGraphics = null;
        }


        public void Shoot()
        {
            if (!_weapon) return;
            ;
            if (!CanShoot) return;

            var projectileToInstantiate = _defualtprojectilePrefab;
            if (_weapon.ProjectilePrefab)
            {
                projectileToInstantiate = _weapon.ProjectilePrefab;
            }

            var inst = Instantiate(projectileToInstantiate, _activeWeaponGraphics.ShootTransform.position,_activeWeaponGraphics.ShootTransform.rotation);

            if (inst.TryGetComponent<ProjectileDamage>(out var projectileDamage))
            {
                projectileDamage.Damage = _weapon.BaseDamage;
            }
            
            var rand = Random.value;
            var maxAngel = 15 - 15 * Mathf.Max(_weapon.Accuracy - _recoilValue, 0);

            var randomAngle = Mathf.Lerp(-maxAngel, maxAngel, rand);

            var forward = inst.transform.forward;

            forward = Quaternion.Euler(0, randomAngle, 0) * forward;

            inst.transform.forward = forward;

            _lastShootTime = Time.time;
            _recoilValue += _weapon.Recoil;
            
            _activeWeaponGraphics.OnShoot();
        }


        private void Update()
        {
            if (!_weapon) return;
            ;
            _recoilValue = Mathf.MoveTowards(_recoilValue, 0, _weapon.RecoilFade * Time.deltaTime);
        }
    }
}