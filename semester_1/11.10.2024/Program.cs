bool isOver = false;
int lastNum = 0;
int endN = 0;

int number = int.Parse(Console.ReadLine());
if (number <= 0) {
    isOver = true;
    Console.WriteLine("Invalid number");
}

while (!isOver) {
    if (number < 10) {
        isOver = true;
    }
    lastNum = number % 10;
    number /= 10;
    if (lastNum % 2 != 0) {
        endN = endN * 10 + lastNum;
    }
}
if (endN == 0) {
    Console.WriteLine("Invalid number");
} else {
    Console.WriteLine(endN);
}
