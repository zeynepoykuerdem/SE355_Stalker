using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class WanderArrived : Node
    {
        private Transform transform;
        private EnemyBrain brain;
        public WanderArrived(Transform transform)
        {
            this.transform = transform;
            this.brain = transform.GetComponent<EnemyBrain>();
        }

        public override NodeState Evaluate()
        {
            if(Vector2.Distance(this.transform.position,brain.currentWanderPoint().position) > 1f)
            {
                state = NodeState.FAILURE;
                Debug.Log(state);
                return state;
            } 
            else
            {
                state = NodeState.SUCCESS;
                return state;
            }
            
        }
    }
}