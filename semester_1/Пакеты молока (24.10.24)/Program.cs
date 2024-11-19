int n = int.Parse(Console.ReadLine());
int fabrika = 0;
int x1, x2, x3, y1, y2, y3;
float c1, c2;
float V1, V2, S1, S2;
float price_milk, min_price_milk = 99999999;

for (int i = 0; i < n; i++)
{
    /*var toConvert = Console.ReadLine().Split(' ');
    int[] numbers1 = new int[6];
    for (int j = 0; j < 6; j++) {
        numbers1[j] = int.Parse(toConvert.Take(6).ToArray()[j]);
    }
    float[] numbers2 = new float[2];
    for (int j = 0; j < 6; j++) {
        numbers2[j] = float.Parse(toConvert.Skip(6).Take(2).ToArray()[j]);
    }*/
    var toConvert = Console.ReadLine().Split(' ');

    x1 = int.Parse(toConvert[0]);
    x2 = int.Parse(toConvert[1]);
    x3 = int.Parse(toConvert[2]);    
    y1 = int.Parse(toConvert[3]);
    y2 = int.Parse(toConvert[4]);
    y3 = int.Parse(toConvert[5]);
    c1 = Convert.ToSingle(toConvert[6]);
    c2 = float.Parse(toConvert[7]);

    V1 = x1 * x2 * x3;
    V2 = y1 * y2 * y3;
    S1 = 2*(x1*x2 + x1*x3 + x2*x3);
    S2 = 2*(y1*y2 + y1*y3 + y2*y3);

    price_milk = (-c1 + (S1*c2)/S2)/(-((V1-S1)/1000) + (S1*((V2-S2)/1000))/S2);

    if (price_milk < min_price_milk)
    {
        min_price_milk = price_milk;
        fabrika = i + 1;
    }
}
Console.WriteLine(fabrika + " " + min_price_milk);