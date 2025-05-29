using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int N = input[0], M = input[1];

        string[] lines = new string[M + 1];
        for (int i = 1; i <= M; i++) lines[i] = Console.ReadLine();

        List<List<(int node, int cost)>> graph = new List<List<(int, int)>>(N + 1);
        for (int i = 0; i <= N; i++) graph.Add(new List<(int, int)>());

        for (int i = 1; i <= M; i++)
        {
            var parts = lines[i].Split(' ');
            int I = int.Parse(parts[0]), J = int.Parse(parts[1]), L = int.Parse(parts[2]);
            graph[I].Add((J, L));
            graph[J].Add((I, L));
        }

        int maxDist = 0;
        for (int start = 1; start <= N; start++)
        {
            int[] dist = new int[N + 1];
            Array.Fill(dist, int.MaxValue);
            dist[start] = 0;
            bool[] visited = new bool[N + 1];

            for (int i = 0; i < N; i++)
            {
                int curr = -1;
                for (int j = 1; j <= N; j++)
                    if (!visited[j] && (curr == -1 || dist[j] < dist[curr]))
                        curr = j;

                if (dist[curr] == int.MaxValue) break;
                visited[curr] = true;

                foreach (var (next, cost) in graph[curr]) {
                    if (dist[next] > dist[curr] + cost)
                    {
                        dist[next] = dist[curr] + cost;
                    }
                }
            }

            for (int j = 1; j <= N; j++)
                maxDist = Math.Max(maxDist, dist[j]);
        }

        Console.WriteLine(maxDist);
    }
}
