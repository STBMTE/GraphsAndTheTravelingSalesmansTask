using System;
using System.Collections.Generic;

namespace GraphsAndTheTravelingSalesmansTask
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Graph graph = new Graph();
            List<GraphVertex> graphVertex = new List<GraphVertex>();
            for (int i = 0; i < 4; i++)
            {
                GraphVertex gv = new GraphVertex(i);
                graph.AddVertex(gv);
                graphVertex.Add(gv);
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    graph.AddLinkVertex(graphVertex[i], graphVertex[j]);
                }
            }

            BruteForceAlgoritm bt = new BruteForceAlgoritm();
            bt.Algoritm(graph);
            var a =bt.BruteForceList;
            foreach (var s in a)
            {
                foreach (var z in s)
                {
                    Console.WriteLine(z.Id);
                }
            }
            /*Console.WriteLine(graph);*/
        }
    }
}