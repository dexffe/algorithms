using System;
using System.IO;

class Program
{
    static void Main()
    {
        int[] coordsCity1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] coordsCity2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int R = int.Parse(Console.ReadLine());

        double lat1 = coordsCity1[0] * Math.PI / 180.0;
        double lon1 = coordsCity1[1] * Math.PI / 180.0;
        double lat2 = coordsCity2[0] * Math.PI / 180.0;
        double lon2 = coordsCity2[1] * Math.PI / 180.0;

        double dLon = Math.Abs(lon1 - lon2);
        if (dLon > Math.PI)
            dLon = 2 * Math.PI - dLon;

        double centralAngle = Math.Acos(
            Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(dLon)
        );

        double distance = R * centralAngle;
        Console.WriteLine(distance.ToString("0.000"));
    }
}
