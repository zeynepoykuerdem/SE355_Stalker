using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }
    public class Node
    {
        protected NodeState state;

        public Node parent;
        protected List<Node> children = new List<Node>();

        private Dictionary<string, object> data = new Dictionary<string, object>();

        public Node()
        {
            parent = null;
        }

        public Node(List<Node> children)
        {
            foreach(Node node in children)
            {
                Attach(node);
            }
        }

        private void Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;

        public void SetData(string key, object value)
        {
            Node parentNode = this;
            while(parentNode.parent != null)
            {
                parentNode = parentNode.parent;
            }
            parentNode.data[key] = value;
        }

        public object GetData(string key)
        {
            object tempValue = null;

            if (data.TryGetValue(key, out tempValue)) return tempValue;

            Node parentNode = parent;
            while(parentNode != null)
            {
                tempValue = parentNode.GetData(key);
                if (tempValue != null) return tempValue;
                parentNode = parentNode.parent;
            }
            return null;
        }

        public bool ClearData(string key)
        {
            if (data.ContainsKey(key))
            {
                data.Remove(key);
                return true;
            }

            Node parentNode = parent;
            
            while(parentNode != null)
            {
                bool cleared = parentNode.ClearData(key);
                if (cleared) return true;
                parentNode = parentNode.parent;
            }
            return false;
        }
    }
}
