//Задание 1

int temp;
int n = int.Parse(Console.ReadLine());
int[] arrPolog = new int[n];
int countPolog = 0, countOtr = 0;
int[] arrOtr = new int[n];
bool isZero = false; 
for (int i = 0; i < n; i++)
{
    int num = int.Parse(Console.ReadLine());
    if (num > 0) {
        arrPolog[i] = num;
        countPolog++;
    } else if (num < 0) {
        arrOtr[i] = num;
        countOtr++;
    } else {
        isZero = true;
    }
}

int[] arrP = new int[countPolog];
int[] arrO = new int[countOtr];
countPolog = 0;
countOtr = 0;
for (int i = 0; i < arrPolog.Length; i++) {
    if (arrPolog[i] > 0) {
        arrP[countPolog] = arrPolog[i];
        countPolog++;
    }
}
for (int i = 0; i < arrOtr.Length; i++) {
    if (arrOtr[i] < 0) {
        arrO[countOtr] = arrOtr[i];
        countOtr++;
    }
}
Console.WriteLine("---------------");
int[] arr = new int[(isZero ? countPolog+countOtr+1 : countPolog+countOtr)];
for (int i = 0; i < arrP.Length; i++) {
    arr[i] = arrP[i];
}
for (int i = 0; i < arrO.Length; i++) {
    arr[i+arrP.Length+(isZero ? 1 : 0)] = arrO[i];
}
for (int i = 0; i < arr.Length; i++) {
    Console.WriteLine(arr[i]);
}


// Задание 2
bool isDown = true;
int difference = 0;
if (arr.Length > 2) {
    difference = arr[0] - arr[1];
}
for (int i = 0; i < arr.Length-1; i++) {
    if ((arr[i] > arr[i+1]) && (arr[i] - arr[i+1] == difference)) {
        continue;
    } else {
        isDown = false;
        break;
    }
}

Console.WriteLine((isDown ? "Равно убывающая последовательность" : "Не равно убывающая последовательность"));


// Задание 3

bool isEven = true;
for (int i = 0; i < arr.Length; i++) {
    if (arr[i] % 2 == 0) {
        continue;
    } else {
        isEven = false;
        break;
    }
}

Console.WriteLine((isEven ? "Все элементы четные" : "Не все элементы четные"));