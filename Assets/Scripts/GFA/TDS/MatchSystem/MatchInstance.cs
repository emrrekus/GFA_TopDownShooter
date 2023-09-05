using UnityEngine;

namespace GFA.TDS.MatchSystem
{
    [CreateAssetMenu (menuName = "MatchInstance")]
    public class MatchInstance : ScriptableObject
    {
      public float Time { get; private set; }

      public void AddTime(float time)
      {
          Time += time;
      }
      
    }
}
