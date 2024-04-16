using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class ChaseEnemy : Node
    {
        private Transform transform;
        private EnemyBrain brain;
        private Rigidbody2D rigidbody;

        public ChaseEnemy(Transform transform)
        {
            this.transform = transform;
            this.brain = transform.GetComponent<EnemyBrain>();
            this.rigidbody = transform.GetComponent<Rigidbody2D>();
        }

        public override NodeState Evaluate()
        {
            if(this.brain.player == null)
            {
                state = NodeState.FAILURE;
                return state;
            }

            if(this.brain.player.transform.position.x - this.transform.position.x > 1f)
            {
                this.rigidbody.velocity = new Vector2(this.brain.moveSpeed , this.rigidbody.velocity.y * Time.deltaTime);
            }

            if(this.brain.player.transform.position.x - this.transform.position.x < -1f)
            {
                this.rigidbody.velocity = new Vector2(-(this.brain.moveSpeed) , this.rigidbody.velocity.y * Time.deltaTime);
            }

            state = NodeState.RUNNING;
            return state;
        }
    }
}
