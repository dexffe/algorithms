
// Задание 1
int a, b;
a = Convert.ToInt32(Console.ReadLine());
b = Convert.ToInt32(Console.ReadLine());

a = a + b;
b = a - b;
a = a - b; 

Console.WriteLine($"{a} {b}");


//Задание 2

a = Convert.ToInt32(Console.ReadLine());  
b = Convert.ToInt32(Console.ReadLine());  



Console.WriteLine(((a+b)+Math.Abs(a-b))/2);



//Задание 3
int P, m, l, N;

P = Convert.ToInt32(Console.ReadLine()); // 5
m = Convert.ToInt32(Console.ReadLine()); // 3
l = Convert.ToInt32(Console.ReadLine()); // 3
N = Convert.ToInt32(Console.ReadLine()); // 1 - 22  2 - 50 3 - 84 4 - 124

int res;
res = N*(2*m+2*P) + (N*N+N)*l;
Console.WriteLine(res);
