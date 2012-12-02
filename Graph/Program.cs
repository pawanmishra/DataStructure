using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"Resources\tinyG.txt");
            Graph g = new Graph(Convert.ToInt32(lines[0]));
            foreach (var str in lines.Skip(2))
            {
                int fromEdge = Convert.ToInt32(str.Split(' ')[0]);
                int toEdge = Convert.ToInt32(str.Split(' ')[1]);
                g.AddEdge(fromEdge, toEdge);
            }

            DFS(g);
            BFS(g);

            Console.WriteLine();
            Console.WriteLine(g.ToString());
        }

        private static void BFS(Graph g)
        {
            BFS bfs = new BFS(g, 0);
            for (int i = 0; i < g.Vertices; i++)
            {
                if (bfs.Marked(i))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();

            IEnumerable<int> path = bfs.Path(3);

            if (path != null)
            {
                path.ToList().ForEach(x => Console.Write(x + " "));
            }
            Console.WriteLine();
        }

        private static void DFS(Graph g)
        {
            DFS dfs = new DFS(g, 0);
            for (int i = 0; i < g.Vertices; i++)
            {
                if (dfs.Marked(i))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();


            if (dfs.Count == g.Vertices)
                Console.WriteLine("Connected");
            else
                Console.WriteLine("Not Connected");

            IEnumerable<int> path = dfs.Path(3);

            if (path != null)
            {
                path.ToList().ForEach(x => Console.Write(x + " "));
            }
            Console.WriteLine();
        }
    }
}
