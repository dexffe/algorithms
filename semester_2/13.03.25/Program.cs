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


class Program {
    static int a = 5;
    static int b = 2;

    public delegate int myDelegate(int a, int b);

    static void Main(string[] args) {
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
}