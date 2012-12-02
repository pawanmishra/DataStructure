using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public static class GraphExtension
    {
        public static int Degree(this Graph g, int v)
        {
            return g.AdjacentVertices(v).Count();
        }

        public static int MaxDegree(this Graph g, int v)
        {
            return Enumerable.Range(0, g.Vertices).Select(x => g.Degree(x)).Max();
        }

        public static int AverageDegree(this Graph g)
        {
            return 2 * g.Edges / g.Vertices;
        }

        public static int NumberOfSelfLoops(this Graph g)
        {
            int count = 0;
            for (int i = 0; i < g.Vertices; i++)
            {
                foreach (var item in g.AdjacentVertices(i))
                {
                    if (item == i)
                        count++;
                }
            }

            return count / 2;
        }
    }
}
