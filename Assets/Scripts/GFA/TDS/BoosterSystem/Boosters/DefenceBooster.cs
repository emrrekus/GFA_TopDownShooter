using GFA.TDS.Mediators;
using UnityEngine;

namespace GFA.TDS.BoosterSystem.Boosters
{ 
    [CreateAssetMenu (menuName = "Booster/Defence")]
    public class DefenceBooster : Booster
    {
        [SerializeField]
        private float _value;
        public override void OnAdded(BoosterContainer container)
        {
            if (container.TryGetComponent<PlayerMediator>(out var mediator))
            {
                mediator.Attributes.Defence += _value;
                
            }
        }
    }
}