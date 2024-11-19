int MaxMoney = int.Parse(Console.ReadLine());


int reqursion(int N, int Z) {
    for (int K = 1; K < 100; K++) {
        
    }
}


int NumberOfCombinations = 0;
for (int money = 1; money <= MaxMoney; money++) {
    for (int Z = 1; Z < 100; Z++) {
        reqursion(money, Z);
    }
}

Console.WriteLine(NumberOfCombinations);
// (N*Z - K)*Z - K = 0