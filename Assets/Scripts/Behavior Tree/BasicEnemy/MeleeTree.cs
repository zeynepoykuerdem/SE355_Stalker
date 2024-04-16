using System.Collections;
using System.Collections.Generic;

using BehaviorTree;

public class MeleeTree : Tree
{
    Node root;
    protected override Node SetupTree()
    {
        Node root = new Fallback(new List<Node>
        {
            new ChaseEnemy(this.transform),
            new Fallback(new List<Node>
            {       
                new Sequence(new List<Node>
                {
                    new WanderArrived(this.transform),
                    new Wait(1f),
                    new WanderElseWhere(this.transform),
                }),

                new Wander(this.transform),  
            })
        });

        return root;
    }

}
