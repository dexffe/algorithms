void Task1() {
    string testString = Console.ReadLine();
    string alf = "abcdefghijklmnopqrstuvwxyz";
    int count = 0;
    string simvol = "";
    for (int j = 0; j < 26; j++) {
        int localCount = 0;
        string localSimvol = alf[j].ToString();
        for (int i = 0; i < testString.Length-2; i++) {
            if (testString[i] == 'a' && testString[i+2] == 'b' && testString[i+1].ToString() == localSimvol) {
                localCount++;
            }
        }
        if (localCount > count) {
            count = localCount;
            simvol = localSimvol;
        }
    }

    Console.WriteLine(simvol);
}

void Task2() {
    string testString = Console.ReadLine(); 
    testString = testString.Replace("abc", "0");
    testString = testString.Replace("ab", "2");
    testString = testString.Replace("a", "1");
    int localLen = 0;
    int resultLen = 0;
    for (int i = 0; i < testString.Length; i++) {
        if (testString[i] == '0') {
            localLen += 3;
        } else {
            if (testString[i] == '1' || testString[i] == '2') {
                localLen += int.Parse(testString[i].ToString());
            }
            resultLen = Math.Max(resultLen, localLen);
            localLen = 0;
        }
    }
    resultLen = Math.Max(resultLen, localLen);
    Console.WriteLine(resultLen);
}

// Task1();
// Task2();
