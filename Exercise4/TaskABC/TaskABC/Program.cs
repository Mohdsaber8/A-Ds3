using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskABC
{
     class Program
    {
         static void Main(string[] args)
        {
            Graph<String> graph = new Graph<String>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nGraph Operations Menu:");
                Console.WriteLine("1 - Insert a new individual (node)");
                Console.WriteLine("2 - Insert a directed edge between two individuals");
                Console.WriteLine("3 - Display the number of individuals (nodes)");
                Console.WriteLine("4 - Display the number of edges");
                Console.WriteLine("6 - Display average number of outbound connections");
                Console.WriteLine("7 - Display average weight of edges");
                Console.WriteLine("8 - Display individual with most outbound connections");
                Console.WriteLine("9 - Display individual who communicates most frequently");
                Console.WriteLine("10 - Display outbound connections for an individual");
                Console.WriteLine("11 - Remove an individual");
                Console.WriteLine("12 - Display individuals that can be reached");
                Console.WriteLine("5 - Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        InsertNode(graph);
                        break;
                    case 2:
                        InsertEdge(graph);
                        break;
                    case 3:
                        Console.WriteLine($"\nTotal number of individuals (nodes): {graph.NumNodesGraph()}");
                        break;
                    case 4:
                        Console.WriteLine($"\nTotal number of edges: {graph.NumEdgesGraph()}");
                        break;
                    case 5:
                        exit = true;
                        break;
                    case 6:
                        Console.WriteLine($"\nAverage outbound connections: {graph.AvgConnectivity()}");
                        break;
                    case 7:
                        Console.WriteLine($"\nAverage weight of edges: {graph.AvgWeightOfEdges()}");
                        break;
                    case 8:
                        Console.WriteLine($"\nIndividual with most outbound connections: {graph.IndividualWithMostOutboundConnections()}");
                        break;
                    case 9:
                        Console.WriteLine($"\nIndividual who communicates most frequently: {graph.IndividualCommunicatesMostFrequently()}");
                        break;
                    case 10:
                        Console.Write("\nEnter the ID (name) of the individual: ");
                        string id = Console.ReadLine();
                        var connections = graph.OutboundConnections(id);
                        Console.WriteLine($"\n{id} has sent messages to: {string.Join(", ", connections)}");
                        break;
                    case 11:
                        Console.Write("\nEnter the ID (name) of the individual to remove: ");
                        string removeID = Console.ReadLine();
                        graph.RemoveNode(removeID);
                        Console.WriteLine($"\nIndividual {removeID} has been removed from the network.");
                        break;
                    case 12:
                        Console.Write("\nEnter the ID (name) of the individual to start the rumor from: ");
                        string startID = Console.ReadLine();
                        var reachableNodes = graph.BreadthFirstTraversal(startID);
                        Console.WriteLine($"\nIndividuals that can be reached from {startID}: {string.Join(", ", reachableNodes)}");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
        }

        static void InsertNode(Graph<string> graph)
        {
            Console.Write("\nEnter the name of the individual: ");
            string name = Console.ReadLine();
            graph.AddNode(name);
            Console.WriteLine("\nIndividual added successfully.");
        }

        static void InsertEdge(Graph<string> graph)
        {
            Console.Write("\n Enter the ID (name) of the from individual: ");
            string from = Console.ReadLine();

            Console.Write("\nEnter the ID (name) of the to individual: ");
            string to = Console.ReadLine();

            Console.Write("Enter the message frequency weight (1-10): ");
            int weight;
            while (!int.TryParse(Console.ReadLine(), out weight) || weight < 1 || weight > 10)
            {
                Console.WriteLine("Invalid input. Please enter an integer between 1 and 10 for the weight.");
                Console.Write("Enter the message frequency weight (1-10): ");
            }

            graph.AddEdge(from, to, weight);
        }
    }
}
