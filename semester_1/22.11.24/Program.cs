int countString = int.Parse(Console.ReadLine());
int[][] arr = new int[countString][];

for (int i = 0; i < countString; i++) {
    arr[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
}


// Задание 1
for (int i = 0; i < countString; i++) {
    for (int j = 0; j < arr[i].Length; j++) {
        if (arr[i].Sum()-arr[i].Max() < arr[i].Max()) {
            Console.WriteLine($"В строке {i+1} макс элемент > суммы остальных");
            break;
        }
    }
}

// Задание 2
for (int i = 0; i < countString; i++) {
    int smallestSequence = 1000000000;
    int sequence = 0;
    bool isStart = false;
    int constNum = 0;

    for (int j = 0; j < arr[i].Length-1; j++) {
        if (arr[i][j] == 2) {
            constNum = arr[i][j] - arr[i][j+1];
            isStart = true;
            sequence++;
        }
        if (isStart) {
            if ((arr[i][j] > arr[i][j+1]) && (arr[i][j] - arr[i][j+1] == constNum)) {
                sequence++;
            } else {
                isStart = false;
                if ((sequence < smallestSequence) && (sequence != 1)) {
                    smallestSequence = sequence;
                }
                sequence = 0;
            }
        }
    }
    if (sequence != 0) {
        smallestSequence = sequence;
    }
    if (smallestSequence == 1000000000) {
        Console.WriteLine($"В строке {i+1} нет последовательностей");
    } else {
        Console.WriteLine($"В строке {i+1} самая короткая последовательность {smallestSequence}");
    }
}
