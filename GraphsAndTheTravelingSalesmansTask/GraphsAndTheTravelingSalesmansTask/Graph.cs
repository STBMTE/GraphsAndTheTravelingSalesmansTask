using System;
using System.Collections.Generic;

namespace GraphsAndTheTravelingSalesmansTask
{
    public class GraphVertex
    {
        public int Id { get; set; }
        public int? EdgeWeidht { get; set; }
        public List<GraphVertex> LinkedVertex = new List<GraphVertex>();
        public bool IsUnvisited { get; set; }

        public IEnumerable<GraphVertex> GetLinkedVertex()
        {
            return LinkedVertex;
        }
        public GraphVertex(int id)
        {
            Id = id;
            IsUnvisited = true;
        }

        public GraphVertex(int id, int weidht)
        {
            Id = id;
            EdgeWeidht = weidht;
        }

        public void AddVertex(GraphVertex newVertex)
        {
            LinkedVertex.Add(newVertex);
        }
    }
    public class Graph
    {
        private List<GraphVertex> AllVertex = new List<GraphVertex>();

        public IEnumerable<GraphVertex> GetAllVertex()
        {
            return AllVertex;
        }
        public void AddVertex(GraphVertex vertex)
        {
            AllVertex.Add(vertex);
        }

        public void AddLinkVertex(GraphVertex vertex, GraphVertex linkVertex)
        {
            vertex.LinkedVertex.Add(linkVertex);
        }

        public override string ToString()
        {
            List<string> str = new List<string>();
            string stri = "";
            foreach (var vertex in AllVertex)
            {
                str.Add(Convert.ToString(vertex.Id));
                foreach (var linkedVertex in vertex.LinkedVertex)
                {
                    str.Add($@"     {Convert.ToString(linkedVertex.Id)}");
                }
            }

            foreach (var s in str)
            {
                stri += s +"\n"; 
            }

            return stri;
        }
    }
}