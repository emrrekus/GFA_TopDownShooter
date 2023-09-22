using GFA.TDS.Mediators;
using UnityEngine;

namespace GFA.TDS.BoosterSystem.Boosters
{
    [CreateAssetMenu (menuName = "Booster/Damage")]
    public class DamageBooster: Booster
    {
        [SerializeField]
        private float _value;
        public override void OnAdded(BoosterContainer container)
        {
            if (container.TryGetComponent<PlayerMediator>(out var mediator))
            {
                mediator.Attributes.Damage += _value;
            }
        }
    }
}