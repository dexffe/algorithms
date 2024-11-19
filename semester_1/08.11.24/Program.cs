

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

 
for (int j = 0; j < n; j++) {
    
    for (int i = 0; i < m; i++) {  //выписывает элементы одного столбца
        Console.WriteLine(numbersList[i,j]);
    }
}





// for (int i = 0; i < m; i++) {
//     for (int j = 0; j < n; j++) {
//         Console.Write(numbersList[i,j] + " ");
//     }
//     Console.WriteLine();
// }


