using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour
    {
        private Node root = null;

        protected void Start()
        {
            root = SetupTree();
        }

        private void Update()
        {
            if (root != null) root.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}