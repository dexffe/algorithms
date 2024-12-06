using System;
namespace Task
{
    class Task {
        public int x;
        public int y;

        public Task() {
            this.x = 0;
            this.y = 0;
        }
        public Task(int x) {
            this.x = x;
            this.y = 0;
        }
        public Task(int x, int y) {
            this.x = x;
            this.y = y;
        }
        
        public void Sum() {
            Console.WriteLine(x + y);
        }
        public void Generation() {
            Console.WriteLine(x * y);
        }
        public void Divide() {
            if (y == 0) {
                Console.WriteLine("Деление на 0 невозможно"); 
            } else {
                Console.WriteLine(x / y); 
            }
        }
        public void Subtraction() {
            Console.WriteLine(y - x);
        }
}
class Program {
    static void Main() {
        Task t1 = new Task();
        t1.Sum();
        t1.Generation();
        t1.Divide();
        t1.Subtraction();
        Console.WriteLine("-----");

        Task t2 = new Task(4);
        t2.Sum();
        t2.Generation();
        t2.Divide();
        t2.Subtraction();
        Console.WriteLine("-----");

        Task t3 = new Task(10, 5);
        t3.Sum();
        t3.Generation();
        t3.Divide();
        t3.Subtraction();
        Console.WriteLine("-----");
    }
}
}
