

int[] CreateArreyList(){
    int n = int.Parse(Console.ReadLine());
    int[] list = new int[n];
    for (int i = 0; i < n; i++) {
        list[i] = int.Parse(Console.ReadLine());
    }
    return list;
}


int[] ReformatList(int[] list){
    for (int i = 0; i < list.Length; i++) {
        list[i] = list[i] * list[i];
    }
    return list;
}


void OutputList(int[] list){
    for (int i = 0; i < list.Length; i++) {
        Console.WriteLine(list[i]);
    }
}

OutputList(ReformatList(CreateArreyList()));

