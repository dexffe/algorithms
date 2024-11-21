
// Задание 1

// Формирование матрицы
string razmer = Console.ReadLine();
int m = int.Parse(razmer.Split()[0]);
int n = int.Parse(razmer.Split()[1]);
int[,] numbersList = new int[m,n];
for (int i = 0; i < m; i++) {
    string nums = Console.ReadLine();
    for (int j = 0; j < n; j++) {
        numbersList[i,j] = int.Parse(nums.Split()[j]);
    }
}

//преобразование столбца матрицы в вид {{количество нулей, сумма, произведение}, {количество нулей, сумма, произведение}, ...}, где индекс массива соответствует номеру столбца
int countZero = 0;
int sumNumbers = 0;
int compositionNumbers = 1;
int[,] conditions = new int[n, 3];
for (int i = 0; i < n; i++) {
    for (int j = 0; j < m; j++) {
        if (numbersList[j, i] == 0) {
            countZero++;
        }
        sumNumbers += numbersList[j, i];
        compositionNumbers *= numbersList[j, i];
    }
    conditions[i, 0] = countZero;
    conditions[i, 1] = sumNumbers;
    conditions[i, 2] = compositionNumbers;
    countZero = 0;
    sumNumbers = 0;
    compositionNumbers = 1;
}

// Проверка на совпадение условий (количество нулей, сумма, произведение)
for (int i = 0; i < m; i++) {
    for (int j = i+1; j < n; j++) {
        if ((conditions[i, 0] == conditions[j, 0]) && (conditions[i, 1] == conditions[j, 1]) && (conditions[i, 2] == conditions[j, 2]) ) {
            Console.WriteLine($"Совпадение: {i + 1}, {j + 1}");
        }
    }
}


// Задание 2

// Формирование матрицы и нахождение столбцов с минимальным и максимальным элементами
string razmer = Console.ReadLine();
int m = int.Parse(razmer.Split()[0]);
int n = int.Parse(razmer.Split()[1]);
int minNumber = int.MaxValue;
int columnWithMinNumber = 0;
int maxNumber = int.MinValue;
int columnWithMaxNumber = 0;
int[,] numbersList = new int[m,n];
for (int i = 0; i < m; i++) {
    string nums = Console.ReadLine();
    for (int j = 0; j < n; j++) {
        numbersList[i,j] = int.Parse(nums.Split()[j]);
        if (numbersList[i,j] < minNumber) {
            minNumber = numbersList[i,j];
            columnWithMinNumber = j;
        }
        if (numbersList[i,j] > maxNumber) {
            maxNumber = numbersList[i,j];
            columnWithMaxNumber = j;
        }
    }
}

Console.WriteLine($"min: {columnWithMinNumber+1} | max: {columnWithMaxNumber+1}");
// Меняем местами колонку с минимальным и максимальным элементами
int Element;
for (int i = 0; i < m; i++) {
    Element = numbersList[i, columnWithMinNumber];
    numbersList[i, columnWithMinNumber] = numbersList[i, columnWithMaxNumber];
    numbersList[i, columnWithMaxNumber] = Element;
}

for (int i = 0; i < m; i++) {
    for (int j = 0; j < n; j++) {
        Console.Write($"{numbersList[i, j]} ");
    }
    Console.WriteLine();
}


// Задание 3

string razmer = Console.ReadLine();
int m = int.Parse(razmer.Split()[0]);
int n = int.Parse(razmer.Split()[1]);
int[,] numbersList = new int[m,n];
for (int i = 0; i < m; i++) {
    string nums = Console.ReadLine();
    for (int j = 0; j < n; j++) {
        numbersList[i,j] = int.Parse(nums.Split()[j]);
    }
}

int difference = 0;
bool isSequence = true;
for (int i = 0; i < m; i++) {
    isSequence = true;
    for (int j = 0; j < n-1; j++) {
        difference = numbersList[i, j] - numbersList[i, j+1];
        if ((numbersList[i, j] > numbersList[i, j+1]) && (numbersList[i, j] - numbersList[i, j+1] == difference)) {
            continue;
        }
        isSequence = false;
        break;
    }
    if (isSequence) {
        Console.WriteLine($"Равномерно убывающая последовательность в строке {i+1}");
    }
}