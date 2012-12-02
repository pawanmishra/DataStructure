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
        private int[] edgeTo;
        private int source;

        public DFS(Graph g, int sourceVertex)
        {
            marked = new bool[g.Vertices];
            edgeTo = new int[g.Vertices];
            source = sourceVertex;
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
                    edgeTo[vertex] = sourceVertex;
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

        public bool HasPath(int v)
        {
            return Marked(v);
        }

        public IEnumerable<int> Path(int v)
        {
            if (!HasPath(v)) return null;
            Stack<int> path = new Stack<int>();
            
            for (int vertex = v; vertex != source; vertex = edgeTo[vertex])
            {
                path.Push(vertex);
            }

            path.Push(source);
            return path;
        }
    }
}
