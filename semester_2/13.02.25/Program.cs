using System;


public class Shape {
    public string Name;
    public Shape(string name) {
        Name = name;
    }
}

public interface IShapeCalculations {
    double CalculateArea();
    double CalculatePerimeter();
}


public class Circle : Shape, IShapeCalculations {
    public double Radius;
    public Circle(double radius) : base("Окружность") { 
        Radius = radius;
    }

    public double CalculateArea() {
        return Math.PI * Radius * Radius;
    }

    public double CalculatePerimeter() {
        return 2 * Math.PI * Radius;
    }
}

public class Square : Shape, IShapeCalculations {
    public double SideLength;
    public Square(double sideLength) : base("Квадрат") {
        SideLength = sideLength;
    }

    public double CalculateArea() {
        return SideLength * SideLength;
    }
    
    public double CalculatePerimeter() {
        return 4 * SideLength;
    }
}

public class EquilateralTriangle : Shape, IShapeCalculations {
    public double SideLength;
    public EquilateralTriangle(double sideLength) : base("Равносторонний треугольник") {
        SideLength = sideLength;
    }

    public double CalculateArea() {
        return (Math.Sqrt(3) / 4) * SideLength * SideLength;
    }

    public double CalculatePerimeter() {
        return 3 * SideLength;
    }
}


class Program {
    static void Main(string[] args) {
        Console.WriteLine("Введите радиус окружности:");
        double radius = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Введите длину стороны квадрата:");
        double squareSide = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Введите длину стороны равностороннего треугольника:");
        double triangleSide = double.Parse(Console.ReadLine());


        Circle circle = new Circle(radius);
        Square square = new Square(squareSide);
        EquilateralTriangle equilateralTriangle = new EquilateralTriangle(triangleSide);


        PrintShapeCalculations(circle);
        PrintShapeCalculations(square);
        PrintShapeCalculations(equilateralTriangle);
    }

    static void PrintShapeCalculations(IShapeCalculations shape) {
        Console.WriteLine($"Фигура: {((Shape)shape).Name}");
        Console.WriteLine($"Площадь: {shape.CalculateArea()}");
        Console.WriteLine($"Периметр: {shape.CalculatePerimeter()}");
        Console.WriteLine();
    }
}