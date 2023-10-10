using GFA.TDS.Audio;
using UnityEngine;

namespace GFA.TDS.WeaponSystem.FX
{
    public class WeaponSFX : WeaponFX
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SoundQue _que;

        protected override void OnShot()
        {
            _que.PlayOneShot(_audioSource);
        }
    }
}