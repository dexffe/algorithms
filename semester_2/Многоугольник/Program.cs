using System;
using System.Collections.Generic;
using System.Globalization;

public class Program
{
    public struct Point
    {
        public long X, Y;

        public Point(long x, long y)
        {
            X = x;
            Y = y;
        }
    }

    // Векторное произведение (cross product) для определения поворота
    private static long Cross(Point o, Point a, Point b)
    {
        return (a.X - o.X) * (b.Y - o.Y) - (a.Y - o.Y) * (b.X - o.X);
    }

    // Построение выпуклой оболочки методом Эндрю (Monotone Chain)
    private static List<Point> ConvexHull(List<Point> points)
    {
        int n = points.Count;
        if (n <= 1) return points;

        points.Sort((a, b) =>
        {
            if (a.X != b.X) return a.X.CompareTo(b.X);
            return a.Y.CompareTo(b.Y);
        });

        List<Point> lower = new List<Point>();
        List<Point> upper = new List<Point>();

        foreach (var p in points)
        {
            while (lower.Count >= 2 && Cross(lower[^2], lower[^1], p) <= 0)
            {
                lower.RemoveAt(lower.Count - 1);
            }
            lower.Add(p);
        }

        for (int i = points.Count - 1; i >= 0; i--)
        {
            var p = points[i];
            while (upper.Count >= 2 && Cross(upper[^2], upper[^1], p) <= 0)
            {
                upper.RemoveAt(upper.Count - 1);
            }
            upper.Add(p);
        }

        upper.RemoveAt(upper.Count - 1);
        lower.RemoveAt(lower.Count - 1);

        upper.AddRange(lower);
        return upper;
    }

    // Вычисление площади многоугольника по формуле Гаусса (shoelace formula)
    private static double PolygonArea(List<Point> polygon)
    {
        double area = 0.0;
        int n = polygon.Count;
        for (int i = 0; i < n; i++)
        {
            int j = (i + 1) % n;
            area += (double)(polygon[i].X * polygon[j].Y - polygon[j].X * polygon[i].Y);
        }
        return Math.Abs(area) / 2.0;
    }

    public static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        int n = int.Parse(Console.ReadLine());
        List<Point> points = new List<Point>();

        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            long x = long.Parse(line[0]);
            long y = long.Parse(line[1]);
            points.Add(new Point(x, y));
        }

        List<Point> convexHull = ConvexHull(points);
        double area = PolygonArea(convexHull);

        Console.WriteLine($"{area:F3}");
    }
}
