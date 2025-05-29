using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);
        int K = int.Parse(Console.ReadLine());

        bool[,] filled = new bool[N + 1, M + 1]; 

        for (int i = 0; i < K; i++)
        {
            string[] coords = Console.ReadLine().Split(' ');
            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);
            filled[x, y] = true;
        }

        int maxArea = 0;

        for (int top = 1; top <= M; top++)
        {
            for (int bottom = top; bottom <= M; bottom++)
            {
                for (int left = 1; left <= N; left++)
                {
                    int right = left;
                    while (right <= N)
                    {
                        bool allEmpty = true;
                        for (int x = left; x <= right; x++)
                        {
                            for (int y = top; y <= bottom; y++)
                            {
                                if (filled[x, y])
                                {
                                    allEmpty = false;
                                }
                            }
                        }

                        if (!allEmpty) break;

                        right++;
                    }
                    right--;

                    maxArea = Math.Max(maxArea, (right - left + 1) * (bottom - top + 1));
                }
            }
        }
        Console.WriteLine(maxArea);
    }
}
