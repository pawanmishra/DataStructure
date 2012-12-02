using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph
    {
        private int _vertices;
        private List<int>[] adjList;
        private int _edge;

        public Graph(int V)
        {
            _vertices = V;
            _edge = 0;
            adjList = new List<int>[V];
            for (int v = 0; v < V; v++)
            {
                adjList[v] = new List<int>();
            }
        }

        public int Vertices
        {
            get { return _vertices; }
        }

        public int Edges
        {
            get { return _edge; }
        }

        public void AddEdge(int v, int w)
        {
            adjList[v].Add(w);
            adjList[w].Add(v);
            _edge++;
        }

        public IEnumerable<int> AdjacentVertices(int v)
        {
            return adjList[v];
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Vertices + " vertices, " + Edges + " edges\n");
            for (int i = 0; i < Vertices; i++)
            {
                builder.Append(i + ": ");
                foreach (var item in this.AdjacentVertices(i))
                {
                    builder.Append(item + " ");
                }
                builder.Append("\n");
            }

            return builder.ToString();
        }
    }
}
