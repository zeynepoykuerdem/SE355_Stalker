using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class Sequence : Node
    {

        public Sequence() : base() { }
        
        public Sequence(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            bool RunningChildExist = false;

            foreach(Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        RunningChildExist = true;
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }

            state = RunningChildExist ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
    }
}