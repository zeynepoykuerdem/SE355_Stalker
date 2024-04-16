using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Wander : Node
    {
        private Transform transform;
        private EnemyBrain brain;
        private Rigidbody2D rigidbody;
        private Transform wanderPoint;

        public Wander(Transform transform)
        {
            this.transform = transform;
            this.brain = transform.GetComponent<EnemyBrain>();
            this.rigidbody = transform.GetComponent<Rigidbody2D>();
        }


        public override NodeState Evaluate()
        {

            this.wanderPoint = brain.currentWanderPoint();
          

            if(wanderPoint == null)
            {
                state = NodeState.FAILURE;
                Debug.Log(state);
                return state;
            }

            if(wanderPoint.position.x - this.transform.position.x > 0.25f)
            {
                this.rigidbody.velocity = new Vector2(this.brain.moveSpeed , 0);
                state = NodeState.RUNNING;
                Debug.Log(state);
                return state;
            } 
            if(wanderPoint.position.x - this.transform.position.x < -0.25f)
            {
                this.rigidbody.velocity = new Vector2(-this.brain.moveSpeed , 0);
                state = NodeState.RUNNING;
                Debug.Log(state);
                return state;
            }

            return NodeState.SUCCESS;

        }
    }
}

