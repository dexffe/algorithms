using System;

class Program {
    static bool IsPalindrom(int num) {
        if (num < 0) return false;
        int original = num;
        int reversed = 0;

        while (num > 0) {
            reversed = reversed * 10 + num % 10;
            num /= 10;
        }
        return original == reversed;
    }

    static unsafe void Main() {
        Console.WriteLine("Введите размер массива:");
        int size = int.Parse(Console.ReadLine());
        int* array = stackalloc int[size];
        Console.WriteLine($"Введите {size} элементов массива:");
        for (int i = 0; i < size; i++) {
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Палиндромы в массиве:");
        for (int i = 0; i < size; i++) {
            if (IsPalindrom(array[i])) {
                Console.WriteLine(array[i]);
            }
        }
    }
}
