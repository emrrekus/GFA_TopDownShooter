using GFA.TDS.WeaponSystem;
using UnityEngine;

namespace GFA.TDS
{
    public class ItemDropper : MonoBehaviour
    {
        [SerializeField] private float _xp;


        [SerializeField, Range(0, 1)] private float _xpDropChange;


        [SerializeField] private XPCollectable _xpCollectablePrefab;
        [SerializeField] private WeaponDropChnce[] _weaponDropChnces;

        public void OnDied()
        {
            if (_xpCollectablePrefab && Random.value < _xpDropChange)
            {
                var inst = Instantiate(_xpCollectablePrefab, transform.position, Quaternion.identity);
                inst.XP = _xp;
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