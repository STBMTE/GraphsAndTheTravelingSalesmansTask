using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAndTheTravelingSalesmansTask
{
    class TravelingSalesmansTask
    {
        Graph graph { get; set; }
        List<GraphVertexInfo> graphVertexInfos { get; set; }
        public TravelingSalesmansTask(Graph graph)
        {
            this.graph = graph;
            graphVertexInfos = new List<GraphVertexInfo>();
        }

        void InitInfo()
        {
            foreach (var graphElement in graph.Vertices)
            {
                graphVertexInfos.Add(new GraphVertexInfo(graphElement));
            }
        }

        GraphVertexInfo GetVertexInfo(GraphVertex graphVertex)
        {
            foreach(var graphElement in graphVertexInfos)
            {
                if (graphElement.Vertex.Equals(graphVertex))
                {
                    return graphElement;
                }
            }
            throw new Exception("Element not found");
        }

        public GraphVertexInfo FindUnvisitedVertexWithMinSum()
        {
            int minValue = int.MaxValue;
            GraphVertexInfo minVertexInfo = null;
            foreach(var element in graphVertexInfos)
            {
                if(element.IsUnvisited && element.EdgesWeidhtSum < minValue)
                {
                    minVertexInfo = element;
                    minValue = element.EdgesWeidhtSum;
                }
            }
            return minVertexInfo;
        }
    }
}
