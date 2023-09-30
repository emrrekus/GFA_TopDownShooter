using DG.Tweening;
using GFA.TDS.WeaponSystem;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GFA.TDS
{
    public class ItemDropper : MonoBehaviour
    {
        [SerializeField] private float _xp;


        [SerializeField, Range(0, 1)] private float _xpDropChange;


        [SerializeField] private XPCollectable _xpCollectablePrefab;
        [SerializeField] private WeaponDropChnce[] _weaponDropChnces;

        [SerializeField] private WeaponCollectable _weaponCollectablePrefab;

        public void OnDied()
        {
            if (_xpCollectablePrefab && Random.value < _xpDropChange)
            {
                var inst = Instantiate(_xpCollectablePrefab, transform.position, Quaternion.identity);
                inst.XP = _xp;
            }

            foreach (var weaponDrop in _weaponDropChnces)
            {
                if (Random.value < weaponDrop.Chance)
                {
                    var inst = Instantiate(_weaponCollectablePrefab, transform.position, quaternion.identity);
                    inst.Weapon = weaponDrop.Weapon;
                    Vector3 randomPointOnCircle = Random.insideUnitCircle;
                    randomPointOnCircle.z = randomPointOnCircle.y;
                    randomPointOnCircle.y = 0;
                    randomPointOnCircle.Normalize();
                    inst.transform.DOJump(transform.position + randomPointOnCircle * 5,1,1,.4f);
                    break;
                }
            }
        }
    }

    [System.Serializable]
    public class WeaponDropChnce
    {
        public float Chance;
        public Weapon Weapon;
    }
}