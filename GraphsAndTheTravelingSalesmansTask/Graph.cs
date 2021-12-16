using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphsAndTheTravelingSalesmansTask
{
    class GraphEdge 
    {
        public GraphVertex LinkedVertex { get; set; }

        public int EdgeWeidht { get; set; }
        public GraphEdge(GraphVertex linkedVertex, int weidht)
        {
            LinkedVertex = linkedVertex;
            EdgeWeidht = weidht;
        }
    }

    class GraphVertexInfo
    {
        public GraphVertex Vertex { get; set; }
        public bool IsUnvisited { get; set; }
        public int EdgesWeidhtSum { get; set; }
        public GraphVertex PreviosVertex { get; set; }
        public GraphVertexInfo(GraphVertex vertex)
        {
            Vertex = vertex;
            IsUnvisited = true;
            EdgesWeidhtSum = int.MaxValue;
            PreviosVertex = null;
        }
    }

    class GraphVertex
    {
        public string Name { get; }
        public List<GraphEdge> Edges { get; }
        public GraphVertex(string name)
        {
            Name = name;
            Edges = new List<GraphEdge>();
        }

        public void AddEdge(GraphEdge graphEdge)
        {
            Edges.Add(graphEdge);
        }

        public void AddEdge(GraphVertex graphEdge, int edgeWidht)
        {
            AddEdge(new GraphEdge(graphEdge, edgeWidht));
        }

        public override string ToString() => Name;
    }

    class Graph
    {
        public List<GraphVertex> Vertices { get; }

        public Graph()
        {
            Vertices = new List<GraphVertex>();
        }

        public void AddVertex(string name)
        {
            Vertices.Add(new GraphVertex(name));
        }

        public GraphVertex FindVertex(string vertexName)
        {
            foreach(var vertex in Vertices)
            {
                if(vertex.Name == vertexName)
                {
                    return vertex;
                }
            }
            throw new Exception("Element not found");
        }

        public void AddEdge(string firstName, string lastName, int weidht)
        {
            var element1 = FindVertex(firstName);
            var element2 = FindVertex(lastName);
            element1.AddEdge(element2, weidht);
            element2.AddEdge(element1, weidht);
        }

        public void OutPutGraph()
        {
            foreach(var element in Vertices)
            {
                Console.Write($@"Вершина:{element.Name} ");
                foreach(var elems in element.Edges)
                {
                    Console.Write($@" |{elems.LinkedVertex}| ");
                    foreach(var elem in elems.LinkedVertex.Edges)
                    {
                        Console.Write($@" #{elem}# ");
                    }
                }
            }
        }
    }
}
