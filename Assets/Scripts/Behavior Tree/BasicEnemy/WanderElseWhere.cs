using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class WanderElseWhere : Node
    {
        private Transform transform;
        private EnemyBrain brain;
        public WanderElseWhere(Transform transform)
        {
            this.transform = transform;
            this.brain = transform.GetComponent<EnemyBrain>();
        }

        public override NodeState Evaluate()
        {

            brain.nextWanderPoint();
            state = NodeState.SUCCESS;
            return state;

        }
    }
}