using UnityEngine;

namespace GFA.TDS.AI
{
    public abstract class AIBehaviour : ScriptableObject
    {
        public abstract void Begin(AIController controller);

        public void Update(AIController controller)
        {
            Execute(controller);
        }
        public abstract void End(AIController controller);

        protected abstract void Execute(AIController controller);

    }
    
} 