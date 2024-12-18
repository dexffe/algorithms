int n = int.Parse(Console.ReadLine());
int fabrika = 0;
float x1, x2, x3, y1, y2, y3;
float c1, c2;
float V1, V2, S1, S2;
float price_milk, min_price_milk = 99999999;

for (int i = 0; i < n; i++)
{
    string[] toConvert = Console.ReadLine().Split(' ');

    x1 = float.Parse(toConvert[0]);
    x2 = float.Parse(toConvert[1]);
    x3 = float.Parse(toConvert[2]);    
    y1 = float.Parse(toConvert[3]);
    y2 = float.Parse(toConvert[4]);
    y3 = float.Parse(toConvert[5]);
    c1 = float.Parse(toConvert[6].Replace('.', ','));
    c2 = float.Parse(toConvert[7].Replace('.', ','));

    V1 = x1 * x2 * x3;
    V2 = y1 * y2 * y3;
    S1 = 2*(x1*x2 + x1*x3 + x2*x3);
    S2 = 2*(y1*y2 + y1*y3 + y2*y3);

    price_milk = 1000*(S1*c2-S2*c1)/(V2*S1-V1*S2);

    if (price_milk < min_price_milk)
    {
        min_price_milk = price_milk;
        fabrika = i + 1;
    }
}
Console.WriteLine(fabrika + " " + Math.Round(min_price_milk, 2));