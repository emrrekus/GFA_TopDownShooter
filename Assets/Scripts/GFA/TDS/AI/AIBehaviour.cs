using UnityEngine;

namespace GFA.TDS.AI
{
    public abstract class AIBehaviour : ScriptableObject
    {
        public abstract void Begin(AIController controller);

        public void OnUpdate(AIController controller)
        {
            Execute(controller);
        }
        public abstract void End(AIController controller);

        protected abstract void Execute(AIController controller);


        public virtual AIState CreateState()
        {
            return new NullAIState();
        }

    }
    
} 