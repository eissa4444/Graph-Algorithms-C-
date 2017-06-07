using System;
using System.Collections.Generic;

namespace Graph_Algorithms_Csharp
{
    public class Algorithms
    {
        //depth first search
        public HashSet<T> Dfs<T>(Graph<T> graph, T start, Action<T> previsit = null)
        {
            var visited = new HashSet<T>();
            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;
            Stack<T> stack = new Stack<T>();
            stack.Push(start);
            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                if (visited.Contains(vertex))
                    continue;
                previsit?.Invoke(vertex);
                visited.Add(vertex);
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }
            return visited;

        }

        //breadth first search
        public HashSet<T> Bfs<T>(Graph<T> graph, T start, Action<T> previsit = null)
        {
            var visited = new HashSet<T>();
            if (graph.AdjacencyList.ContainsKey(start))
            {
                return visited;
            }
            var queue = new Queue<T>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                if (visited.Contains(vertex))
                    continue;
                previsit?.Invoke(vertex);

                visited.Add(vertex);
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }

            }
            return visited;
        }
    }
}
