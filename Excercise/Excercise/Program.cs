using System;
using System.Collections.Generic;

class Graph
{
    int[,] adj = new int[6, 6]
    {
            {-1, 15, -1, 35, -1, -1 },
            {15, 0-1 05, 10, -1, -1 },
            {-1, 05, -1, -1, -1, -1 },
            {35, 10, -1, -1, 05, -1 },
            {-1, -1, -1, 05, -1, 05 },
            {-1, -1, -1, -1, 05, -1 },
    };



    // 2) now와 연결된 정점들을 하나씩 확인해서, 아직 미발견 상태라 방문한다.
    List<int>[] adj2 = new List<int>[]
    {
        new List<int>() {1,3},
        new List<int>() {0,2,3},
        new List<int>() {1},
        new List<int>() {0,1,4},
        new List<int>() {3,5},
        new List<int>() {4}
    };


    //#region DFS
    //public void DFS(int now, bool[] visited)
    //{
    //    Console.WriteLine(now);
    //    visited[now] = true; // 1) 우선 now부터 방문하고,

    //    for (int next = 0; next < 6; next++)
    //    {
    //        if (adj[now, next] == 0) //연결되어있지 않으면 스킵
    //            continue;
    //        if (visited[next]) // 이미 방문 했으면 스킵.
    //            continue;
    //        DFS(next, visited);
    //    }
    //}
    //public void DFS2(int now, bool[] visited)
    //{
    //    Console.WriteLine(now);
    //    visited[now] = true; // 1) 우선 now부터 방문하고,

    //    foreach (int next in adj2[now])
    //    {
    //        if (visited[next]) // 이미 방문 했으면 스킵.
    //            continue;
    //        DFS2(next, visited);
    //    }
    //}

    //public void SearchAll()
    //{
    //    bool[] visited = new bool[6];
    //    for (int now = 0; now < 6; now++)
    //        if (visited[now] == false)
    //            DFS(now, visited);
    //}
    //#endregion


    public void Dijikstra(int start)
    {
        bool[] visited = new bool[6];
        int[] distance = new int[6];
        Array.Fill(distance, Int32.MaxValue);

        distance[start] = 0;

        // 가장 유력한 후보의 거리와 번호를 저장한다.
        int closest = Int32.MaxValue;
        int now = -1;
        while (true)
        {
            //제일 좋은 후보를 찾는다 (가장 가까이에 있는)

            for (int i = 0; i < 6; i++)
            {
                //이미 방문한 정점은 스킵
                if (visited[i])
                    continue;
                //아직 발견(예약)된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
                if (distnace[i] == )
            }    
        }

    }

    #region BFS
    public void BFS(int start)
    {
        bool[] found = new bool[6];
        int[] parent = new int[6];
        int[] distance = new int[6];

        Queue<int> q = new Queue<int>();
        q.Enqueue(start);
        found[start] = true;
        parent[start] = start;
        distance[start] = 0;

        while (q.Count > 0)
        {
            int now = q.Dequeue();
            Console.WriteLine(now);

            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0)
                    continue;
                if (found[next])
                    continue;
                q.Enqueue(next);
                found[next] = true;
                parent[next] = now;
                distance[start] = distance[now] + 1;
            }
        }
    }
    #endregion


}



class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        //graph.SearchAll();
        graph.BFS(0);

    }
}

