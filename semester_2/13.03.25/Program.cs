using System;

class methodsWithParameters {
    public int sum(int a, int b) {
        return a + b;
    }

    public int substraction(int a, int b) {
        return a - b;
    }

    public int multiplication(int a, int b) {
        return a * b;
    }

    public int division(int a, int b) {
        return b == 0 ? 0 : a / b;
    }
}


public delegate void CarWashedDelegate(string model);

class Car {
    public int year;
    public string model;
    public string owner;
    public bool isClear;
    public Car(int year, string model, string owner, bool isClear) {
        this.year = year;   
        this.model = model;
        this.owner = owner;
        this.isClear = isClear;
    }
}


class Garage {
    public List<Car> Cars = new List<Car>();
    
    public void AddCar(Car car) {
        Cars.Add(car);
    }
}                                                                               


class WashingMachine {
    public event CarWashedDelegate? CarWashed;
    public void wash(Car car) {
        car.isClear = true;
        CarWashed?.Invoke(car.model);
    }
}


class Program {
    static int a = 5;
    static int b = 2;
    public delegate int myDelegate(int a, int b);

    public void task1() {
        methodsWithParameters obj1 = new methodsWithParameters();
        myDelegate operationDelegate = obj1.sum;
        operationDelegate += obj1.substraction;
        operationDelegate += obj1.division;

        int result = a;
        foreach (myDelegate operation in operationDelegate.GetInvocationList()) {
            result = operation(result, b);
        }

        Console.WriteLine("objectClass1.result : " + result);


        methodsWithParameters obj2 = new methodsWithParameters();
        myDelegate operationDelegate2 = obj2.multiplication;
        operationDelegate2 += obj2.sum;

        int result2 = b;
        foreach (myDelegate operation in operationDelegate2.GetInvocationList()) {
            result2 = operation(a, result2);
        }
        Console.WriteLine("objectClass2.result : " + result2);
    }

    public void task2() {
        Garage garage = new Garage();
    
        garage.AddCar(new Car(2010, "Toyota Camry", "Иван Иванов", false));
        garage.AddCar(new Car(2015, "BMW X5", "Петр Петров", true));
        garage.AddCar(new Car(2020, "Kia Rio", "Сергей Сергеев", false));
        garage.AddCar(new Car(2018, "Lada Vesta", "Алексей Алексеев", false));

        WashingMachine washingMachine = new WashingMachine();


        washingMachine.CarWashed += (model) => {
            Console.WriteLine($"Машина {model} была помыта.");
        };
        
        
        foreach (Car car in garage.Cars) {
            if (!car.isClear) {
                washingMachine.wash(car);
            }
        } 
    }
    static void Main(string[] args) {
        Program program = new Program();
        // program.task1();
        program.task2();
    }
}