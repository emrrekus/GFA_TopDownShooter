using GFA.TDS.MatchSystem;
using GFA.TDS.Movement;

namespace GFA.TDS.AI.States
{
    public class BasicAIState : AIState
    {
        public CharacterMovement CharacterMovement { get; set; }
        public EnemyAttacker Attacker { get; set; }
        public IDamageable PlayerDamageable { get; set; }
    }

    
}