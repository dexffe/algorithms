using System.Collections;

class Lst<T> {
    private List<T> list = new List<T>();
    public void add(T obj) {
        list.Add(obj);
    }
    public void remove(int index) {
        try {
            list = list[0..index].Concat(list[(index + 1)..]).ToList();
        } catch {
            Console.WriteLine("ErrorIndex");
        }
    }
    public void serch(int index) {
        try {
            foreach (var item in list) {
                if (list.IndexOf(item) == index) {
                    Console.WriteLine(item);
                }
            }      
        } catch {
            Console.WriteLine("ErrorIndex");
        }
    }
}

class Pass {
    public void p() {
        Console.WriteLine("pass");
        }
}

class Program {
    static void Main(string[] args) {
        Lst<object> lst = new Lst<object>();

        lst.add(123);
        lst.add(new Pass());
        lst.serch(0);
        lst.remove(0);
        lst.serch(0);
    
    }
} 