using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskABC
{
    public class GraphNode<T>
    {
        private T id; // date stored inside the node like a (unique label) of the node
        private LinkedList<T> adjList; // adjacent list of the node
        private LinkedList<int> weights;

        public GraphNode(T id)
        {
            this.id = id;
            adjList = new LinkedList<T>();
            weights = new LinkedList<int>();

        }

        public T ID
        {
            set { id = value; }
            get { return id; }
        }

        //add edge from this node to the node "to"; it is an unweighted and *directed* graph. 

        public void AddEdge(GraphNode<T> to, int weight)
        {
            if (weight < 1 || weight > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be between 1 and 10.");
            }
            adjList.AddLast(to.ID);
            weights.AddLast(weight);
        }

        // return the adjacent list of the node (needed for the visit of the graph)

        public LinkedList<T> GetAdjList()
        {
            return adjList;
        }

        public LinkedList<int> getWeights()
        {
            return weights;
        }


    }
}
