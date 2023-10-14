using UnityEngine;

namespace GFA.TDS.Audio
{
    [CreateAssetMenu (menuName = "Audio/Sound Que")]
    public class SoundQue : ScriptableObject
    {
        [SerializeField] private AudioClip [] _audioClips;

        [SerializeField] private float _volume;
        

        public AudioClip Get()
        {
            return _audioClips[Random.Range(0, _audioClips.Length)];
        }

        public void PlayOneShot(AudioSource source)
        {
            source.PlayOneShot(Get(), _volume);
        }
    }
}
