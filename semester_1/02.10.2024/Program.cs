//* Задача 1
int n = int.Parse(Console.ReadLine());

int count = 0;
int maxLength = 0;
int lastNumber = -99999;
for (int i = 0; i < n; i++)
{
    int a = int.Parse(Console.ReadLine());
    if (i == 0) { lastNumber = a; continue;}
    if (lastNumber == a) { 
        count++; 
    } else {
        count++;
        maxLength = Math.Max(maxLength, count);
        count = 0;
        }
    lastNumber = a;
}
Console.WriteLine("maxLength = " + maxLength);


//* Задача 2
int n = int.Parse(Console.ReadLine());


int minLength = 10000000;
int lastNumber = -999999;
int count = 0;
for (int i = 0; i < n; i++)
{
    
    int a = int.Parse(Console.ReadLine());
    if (i == 0) { lastNumber = a; continue;}

    if (lastNumber%2==0 && a%2==0) {
        count++; 
    } else {
        if (count >= 1) {
            count++;
            minLength = Math.Min(minLength, count);
            count = 0;
        }}
    lastNumber = a;
}
Console.WriteLine("minLength = " + minLength);


//* Задача 3
int n = int.Parse(Console.ReadLine());


int maxLength = -999999;
int lastNumber = 0;
int count = 0;
for (int i = 0; i < n; i++) {
    int a = int.Parse(Console.ReadLine());
    if (i == 0) { 
        lastNumber = a; 
        continue;
    }
    if (lastNumber%2!=0 && a%2!=0) {
        if (i == n-1) {
            maxLength = Math.Max(maxLength, count);
        }
    } else if (lastNumber%2!=0 && a%2==0) { 
        if (i == n-1) {
            maxLength = Math.Max(maxLength, a);
        }
    } else if (lastNumber%2==0 && a%2==0) {
        if (i == n-1) {
            count += a + lastNumber;
            maxLength = Math.Max(maxLength, count);
        } else {
            count += lastNumber;
        }
    } else if (lastNumber%2==0 && a%2!=0){
        count += lastNumber;
        maxLength = Math.Max(maxLength, count);
        count = 0;
    }
    lastNumber = a;
}
maxLength = Math.Max(maxLength, count);
Console.WriteLine("maxLength = " + maxLength);

