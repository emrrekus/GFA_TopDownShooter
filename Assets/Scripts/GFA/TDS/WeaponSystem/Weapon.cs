using UnityEngine;

namespace GFA.TDS.WeaponSystem
{
    [CreateAssetMenu(menuName = "Weapon")]
    public class Weapon : ScriptableObject
    {
        [SerializeField] private float _baseDamage;
        public float BaseDamage => _baseDamage;


        [SerializeField, Min(0)] private float _fireRate = 0.5f;
        public float Firerate => _fireRate;

        [SerializeField, Range(0, 1)] private float _accuracy = 0.01f;
        public float Accuracy => _accuracy;

        [SerializeField] private float _recoil;
        public float Recoil => _recoil;

        [SerializeField] private float _recoilFade;
        public float RecoilFade => _recoilFade;

        [SerializeField] private GameObject _projectilePrefab;
        public GameObject ProjectilePrefab => _projectilePrefab;


        [SerializeField] private WeaponsGraphics _weaponsGraphics;
   
        public WeaponsGraphics WeaponsGraphics => _weaponsGraphics;
        
        [SerializeField]
        private string _boneSocketName;
        public string BoneSocketName => _boneSocketName;
    }
}