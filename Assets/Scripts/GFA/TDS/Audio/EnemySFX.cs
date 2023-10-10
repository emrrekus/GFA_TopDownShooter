using UnityEngine;

namespace GFA.TDS.Audio
{
    public class EnemySFX : MonoBehaviour
    {
        [SerializeField] private SoundQue _damageQue;

        [SerializeField] private SoundQue _attackQue;

        [SerializeField] private AudioSource _audioSource;
        
        public void PlayDamageSFX()
        {
            _damageQue.PlayOneShot(_audioSource);    
        }

        public void PlayAtackSFX()
        {
            _attackQue.PlayOneShot(_audioSource);
        }
    }
}
