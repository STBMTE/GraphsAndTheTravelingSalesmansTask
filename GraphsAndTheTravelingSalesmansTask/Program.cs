using System;

namespace GraphsAndTheTravelingSalesmansTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Graph();
            for(int i = 0; i < 5; i++)
            {
                g.AddVertex($"{i}");
            }
            var rnd = new Random();
            for(int i = 0; i < 5; i++)
            {
                g.AddEdge($"{i}", $"{4-i}", rnd.Next() % 10);
            }

            g.OutPutGraph();
        }
    }
}
