using GFA.TDS.Mediators;
using UnityEngine;

namespace GFA.TDS.BoosterSystem.Boosters
{
    [CreateAssetMenu (menuName = "Booster/AttackSpeed")]
    public class AttackSpeedBooster : Booster
    {
       

        [SerializeField] private float _value;
        public override void OnAdded(BoosterContainer container)
        {
            if (container.TryGetComponent<PlayerMediator>(out var mediator))
            {
                mediator.Attributes.AttackSpeed += _value;
            }
        }
    }
}