using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class SymbolGraph
    {
        private string _path;
        private string _delimiter;
        private Dictionary<string, int> _symbolTable;
        private string[] _keys;
        private Graph _graph;

        public SymbolGraph(string filePath, string delimiter)
        {
            _path = filePath;
            _delimiter = delimiter;
            ConstructGraph(_path, _delimiter);
        }

        private void ConstructGraph(string _path, string _delimiter)
        {
            _symbolTable = new Dictionary<string, int>();
            string[] lines = File.ReadAllLines(_path);

            foreach (var line in lines)
            {
                foreach (var item in line.Split('/'))
                {
                    if (!_symbolTable.ContainsKey(item))
                    {
                        _symbolTable.Add(item, _symbolTable.Count);
                    }
                }
            }

            _keys = _symbolTable.Keys.ToArray();

            _graph = new Graph(_symbolTable.Count);
        }
    }
}
