using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskABC
{
    public class Graph<T> where T : IComparable
    {

        // list of graphnodes in the graph (nodes in the graph)
        private LinkedList<GraphNode<T>> nodes;
        private int counterEdges = 0; // variable to count and keep track of the number of edges

        // constructor. set the list of nodes in the graph to be the empty list 
        public Graph()
        {
            nodes = new LinkedList<GraphNode<T>>();
        }

        // check if the graph is empty (no node is present)
        public bool IsEmptyGraph()
        {
            //if the number of the elements within nodes is equal to 0, return true;
            //otherwise, return false; 
            return nodes.Count == 0;
        }

        // add a new node in the graph. use constructor of graphnode
        public void AddNode(T id)
        {

            nodes.AddLast(new GraphNode<T>(id));
        }

        // only returns true if node is present in the graph
        public bool ContainsGraph(GraphNode<T> node)
        {

            // validation to be completed: add a check that node is not null

            foreach (GraphNode<T> n in nodes)
            {
                if (n.ID.CompareTo(node.ID) == 0)
                {
                    return true;
                }
            }

            return false;
        }
     
        //returns the node with this id
        public GraphNode<T> GetNodeByID(T id)
        {
            foreach (GraphNode<T> n in nodes)
            {
                if (id.CompareTo(n.ID) == 0) return n;
            }
            return null;
        }

        //Add a directed edge between the node with id "from" and the node with id “to”
        public void AddEdge(T from, T to, int weight)
        {
            GraphNode<T> n1 = GetNodeByID(from);
            GraphNode<T> n2 = GetNodeByID(to);

            // to validate the weight is withi the allowed range
            if (weight < 1 || weight > 10)
            {
                Console.WriteLine($"\nInvalid weight. The weight must be between 1 and 10.");
                return;
            }

            if (n1 != null && n2 != null) // && logical AND in C#
            {
                n1.AddEdge(n2, weight);
                counterEdges++; // to Increment edge count when an edge is added
                Console.WriteLine($"\nEdge added successfully from {from} to {to} with a weight of {weight}. Total edges: {counterEdges}");
            }
            else
            {
                if (n1 == null)
                {
                    Console.WriteLine($"\nNode with ID {from} not found in the graph.");
                }
                if (n2 == null)
                {
                    Console.WriteLine("\nNode with ID {to} not found in the graph.");
                }
            }
        }

        public bool IsAdjacent(GraphNode<T> from, GraphNode<T> to)
        {
            // goes through all nodes in the graph
            foreach (GraphNode<T> n in nodes)
            {
                // Checks if current node's ID matches the 'from' node's ID
                if (n.ID.CompareTo(from.ID) == 0)
                {
                    // goes through the adjacency list of 'from' node
                    foreach (T adjacentNodeID in from.GetAdjList())
                    {
                        // Check if any node in 'from' adjacency list matches 'to' node's ID
                        if (adjacentNodeID.CompareTo(to.ID) == 0)
                        {
                            return true; // 'to' node is adjacent to 'from' node
                        }
                    }
                }
            }

            return false; // 'to' node is not adjacent to 'from' node
        }


        // returns the total number of nodes present in the graph
        public int NumNodesGraph()
        {
            // once you have that list, you can count (and return) how many elements are in the list            
            return nodes.Count;
        }

        // returns the total number of edges present in the graph
        public int NumEdgesGraph()
        {
            return counterEdges;
           
        }

        public float AvgConnectivity()
        {
            if (IsEmptyGraph()) return 0;
            return (float)counterEdges / nodes.Count;
        }

        public float AvgWeightOfEdges()  //To find this, sum up all the weights and divide by the total number of edges.
        {
            int totalWeight = 0;
            foreach (var node in nodes)
            {
                totalWeight += node.getWeights().Sum();
            }
            return counterEdges == 0 ? 0 : (float)totalWeight / counterEdges;           
        }

        public T IndividualWithMostOutboundConnections() // Loop through all nodes and count the size of each node's adjacency list.
        {
            int maxConnections = 0;
            T individual = default(T);
            foreach (var node in nodes)
            {
                if (node.GetAdjList().Count > maxConnections)
                {
                    maxConnections = node.GetAdjList().Count;
                    individual = node.ID;
                }
            }
            return individual;
        }

        public T IndividualCommunicatesMostFrequently() // For each node, find the average weight of their outbound edges.
        {
            float maxAverageWeight = 0;
            T individual = default(T);
            foreach (var node in nodes)
            {
                var weights = node.getWeights();
                if (weights.Count > 0)
                {
                    float averageWeight = (float)weights.Sum() / weights.Count;
                    if (averageWeight > maxAverageWeight)
                    {
                        maxAverageWeight = averageWeight;
                        individual = node.ID;
                    }
                }
            }
            return individual;
        }

        public List<T> OutboundConnections(T nodeID) // Given a node ID, return all nodes it is connected to.
        {
            var node = GetNodeByID(nodeID);
            if (node != null)
            {
                return node.GetAdjList().ToList();
            }
            return new List<T>();
        }

        public float DegreeCentrality(T nodeID) // the number of outbound connections divided by the total number of nodes minus one.
        {
            var node = GetNodeByID(nodeID);
            if (node != null && nodes.Count > 1)
            {
                return (float)node.GetAdjList().Count / (nodes.Count - 1);
            }
            return 0;
        }

        public void RemoveNode(T id)
        {
            // First, find and remove the node from the nodes list.
            var nodeToRemove = GetNodeByID(id);
            if (nodeToRemove != null)
            {
                nodes.Remove(nodeToRemove);

                // Next, remove any edges pointing to this node from other nodes' adjacency lists.
                foreach (var node in nodes)
                {
                    var adjList = node.GetAdjList();
                    var weightsList = node.getWeights();
                    var currentNodeAdj = adjList.First;
                    var currentNodeWeight = weightsList.First;

                    while (currentNodeAdj != null)
                    {
                        // If the current adjacency node is the one to remove, delete it and its weight.
                        if (currentNodeAdj.Value.CompareTo(id) == 0)
                        {
                            var nextAdj = currentNodeAdj.Next;
                            var nextWeight = currentNodeWeight.Next;
                            adjList.Remove(currentNodeAdj);
                            weightsList.Remove(currentNodeWeight);
                            currentNodeAdj = nextAdj;
                            currentNodeWeight = nextWeight;
                            counterEdges--; // Decrement the edge count and remove it
                        }
                        else
                        {
                            currentNodeAdj = currentNodeAdj.Next;
                            currentNodeWeight = currentNodeWeight.Next;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"\nNode with ID {id} not found in the graph.");
            }
        }

        public List<T> BreadthFirstTraversal(T startID)
        {
            List<T> visited = new List<T>();
            Queue<T> toVisit = new Queue<T>();

            // Start by enqueuing the start node if it exists.
            var startNode = GetNodeByID(startID);
            if (startNode == null)
            {
                Console.WriteLine($"\nNode with ID {startID} not found in the graph.");
                return visited;
            }
            toVisit.Enqueue(startID);

            while (toVisit.Count != 0)
            {
                // Dequeue the next node.
                T currentID = toVisit.Dequeue();

                // Add the current node to the visited list if not already visited.
                if (!visited.Contains(currentID))
                {
                    visited.Add(currentID);

                    // Get the adjacency list of the current node.
                    var currentNode = GetNodeByID(currentID);
                    LinkedList<T> adj = currentNode.GetAdjList();

                    // Enqueue all adjacent nodes that haven't been visited or queued.
                    foreach (T nodeID in adj)
                    {
                        if (!visited.Contains(nodeID) && !toVisit.Contains(nodeID))
                        {
                            toVisit.Enqueue(nodeID);
                        }
                    }
                }
            }

            return visited;
        }


    }
}