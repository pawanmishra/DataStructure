using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class DFS
    {
        private bool[] marked;
        private int count;

        public DFS(Graph g, int sourceVertex)
        {
            marked = new bool[g.Vertices];
            Search(g, sourceVertex);
        }

        private void Search(Graph g, int sourceVertex)
        {
            marked[sourceVertex] = true;
            count++;

            foreach (var vertex in g.AdjacentVertices(sourceVertex))
            {
                if (!marked[vertex])
                {
                    Search(g, vertex);
                }
            }
        }

        public bool Marked(int vertex)
        {
            return marked[vertex];
        }

        public int Count
        {
            get { return count; }
        }
    }
}
