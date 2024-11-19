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
        Console.WriteLine("Polog: " + arrP[countPolog]);
        countPolog++;
    }
}
for (int i = 0; i < arrOtr.Length; i++) {
    if (arrOtr[i] < 0) {
        arrO[countOtr] = arrOtr[i];
        Console.WriteLine("Otr: " + arrO[countOtr]);
        countOtr++;
    }
}

int[] arr = new int[(isZero ? countPolog+countOtr+1 : countPolog+countOtr)];
for (int i = 0; i < arrP.Length; i++) {
    arr[i] = arrP[i];
}
for (int i = 0; i < arrO.Length; i++) {
    arr[i+arrP.Length+1] = arrO[i];
}
for (int i = 0; i < arr.Length; i++) {
    Console.WriteLine(arr[i]);
}


