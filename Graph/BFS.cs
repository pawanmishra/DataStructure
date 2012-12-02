using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class BFS
    {
        private int source;
        private bool[] marked;
        private int[] edgeTo;
        private int count;

        public BFS(Graph g, int vertex)
        {
            source = vertex;
            marked = new bool[g.Vertices];
            edgeTo = new int[g.Vertices];
            Search(g, vertex);
        }

        private void Search(Graph g, int vertex)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(vertex);           

            while (queue.Count != 0)
            {
                int element = queue.Dequeue();
                marked[element] = true;
                
                foreach (var item in g.AdjacentVertices(element))
                {
                    if (!marked[item])
                    {
                        marked[item] = true;
                        edgeTo[item] = vertex;
                        queue.Enqueue(item);
                    }
                }
            }
        }

        public bool Marked(int v)
        {
            return marked[v];
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

        private bool HasPath(int v)
        {
            return Marked(v);
        }
    }
}
