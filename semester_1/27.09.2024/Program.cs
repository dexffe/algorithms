
// Задание 1
int n = int.Parse(Console.ReadLine());

int count=0;
int num1=0, num2=0, num3=0;
for (int i = 0; i < n; i++)
{
    int a = int.Parse(Console.ReadLine());
    switch (i)
    {
        case (0): num1 = a; break;
        case (1): num2 = a; break;
        default: if (num1 > num2 && num2 < a) {count++;}; num1 = num2; num2 = a; break; 
    }
}
Console.WriteLine(count);



//Задание 2
int n = int.Parse(Console.ReadLine());

int count = 0;
for (int i = 0; i < n; i++)
{
    int a = int.Parse(Console.ReadLine());
    if (Math.Abs(a)%10 == 2)
    {
        count++;
    }


}
Console.WriteLine(count);

// Задание 3

int n = int.Parse(Console.ReadLine());

int firstMaxNumber = -9999999, secondMaxNumber = -9999999;
for (int i = 0; i < n; i++)
{
    int newNumber = int.Parse(Console.ReadLine());
    if (i==0) { firstMaxNumber = newNumber; continue; }
    if (newNumber < firstMaxNumber && newNumber > secondMaxNumber) { 
        secondMaxNumber= newNumber;
    } else if (firstMaxNumber < newNumber) { secondMaxNumber = firstMaxNumber; firstMaxNumber = newNumber;}
}
Console.WriteLine(secondMaxNumber);


// Задние 4
int n = int.Parse(Console.ReadLine());

int counter = 0, maxCounter = 0;
for (int i = 0; i < n; i++)
{
    int newNumber = int.Parse(Console.ReadLine());
    if (newNumber%2 == 0) { counter++; }
    else {maxCounter = Math.Max(counter, maxCounter); counter = 0; }
}
Console.WriteLine(maxCounter);