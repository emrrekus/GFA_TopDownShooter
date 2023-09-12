using GFA.TDS.MatchSystem;
using UnityEngine;

namespace GFA.TDS.Animating
{
    public class AnimationEventBinder : MonoBehaviour
    {
        public void ExecuteDamage()
        {
            var executor = GetComponentInParent<IDamageExecutor>();
            if (executor != null)
            {
                executor.ExecuteDamage();
            }
        }
    }
}
