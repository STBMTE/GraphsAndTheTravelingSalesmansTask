using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphsAndTheTravelingSalesmansTask
{
    public class BruteForceAlgoritm : SalesmansTask
    {
        public List<List<GraphVertex>> BruteForceList = new List<List<GraphVertex>>();
        private ulong Constant { get; set; }
        private ulong Visits { get; set; }
        public override void Algoritm(Graph graph)
        {
            Constant = factorial(graph.GetAllVertex().Count() - 1);
            Visits = 0;
            BruteForce(graph);
        }

        private ulong factorial(int a)
        {
            ulong l = 1;
            for (int i = 1; i <= a; i++)
            {
                l *= Convert.ToUInt64(i);
            }

            return l;
        }

        public void BruteForce(Graph graph)
        {
            var graphAllVertex = graph.GetAllVertex();
            foreach (var vert in graphAllVertex)
            {
                BruteForceList.Add(Rec(vert));
            }
        }

        public List<GraphVertex> Rec(GraphVertex gr)
        {
            List<GraphVertex> graphVertices = new List<GraphVertex>();
            RecursiveBruteForce(gr, graphVertices);
            return graphVertices;
        }

        public void RecursiveBruteForce(GraphVertex vertex, List<GraphVertex> graphVertices)
        {
            if (vertex.IsUnvisited && Visits <= Constant)
            {
                graphVertices.Add(vertex);
                vertex.IsUnvisited = true;
                Visits++;
                foreach (var linkdVertex in vertex.GetLinkedVertex())
                {
                    if (linkdVertex.IsUnvisited)
                    {
                        RecursiveBruteForce(linkdVertex, graphVertices);
                        linkdVertex.IsUnvisited = true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}