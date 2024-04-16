using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Wait : Node
    {
        public float waitCooldown;
        public float waitTimer = 0f;

        public Wait(float waitCooldown)
        {
            this.waitCooldown = waitCooldown;
        }

        public override NodeState Evaluate()
        {
            Debug.Log("WAit: " + waitTimer);
            if(waitTimer >= waitCooldown)
            {
                state = NodeState.SUCCESS;
                waitTimer = 0;
                return state;
            }
            else
            {
                waitTimer += Time.deltaTime;
                state = NodeState.RUNNING;
                return state;
            }

            
          
        }
    }
}