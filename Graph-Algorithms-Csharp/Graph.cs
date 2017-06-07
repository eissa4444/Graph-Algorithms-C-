﻿using System;
using System.Collections.Generic;

namespace Graph_Algorithms_Csharp
{
    public class Graph<T>
    {
        public Graph() { }

        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var vertex in vertices)
            {
                AddVertex(vertex);
            }
            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public Dictionary<T, HashSet<T>> AdjacencyList { get; set; } = new Dictionary<T, HashSet<T>>();

        private void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }

        private void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }
    }

}
