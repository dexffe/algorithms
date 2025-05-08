using System;
using System.Collections.Generic;
using System.Linq;

public class Car {
    public string Make { get; set; }
    public int Year { get; set; }
    public string City { get; set; }
}

class Program {
    static void Main(string[] args) {
        List<Car> cars = new List<Car> {
            new Car { Make = "Toyota", Year = 2018, City = "Москва" },
            new Car { Make = "Honda", Year = 2020, City = "Санкт-Петербург" },
            new Car { Make = "Toyota", Year = 2021, City = "Москва" },
            new Car { Make = "Ford", Year = 2019, City = "Екатеринбург" },
            new Car { Make = "BMW", Year = 2020, City = "Москва" },
            new Car { Make = "Honda", Year = 2017, City = "Казань" },
            new Car { Make = "Toyota", Year = 2020, City = "Санкт-Петербург" },
            new Car { Make = "BMW", Year = 2021, City = "Новосибирск" },
            new Car { Make = "Ford", Year = 2020, City = "Москва" }
        };

        // 1. Данные по каждой марке автомобиля
        Console.WriteLine("=== Количество автомобилей по маркам ===");
        var groupedByMake = cars.GroupBy(c => c.Make);
        foreach (var group in groupedByMake) {
            Console.WriteLine($"{group.Key}: {group.Count()} шт.");
        }

        // 2. Данные по заданному году выпуска
        int targetYear = 2020;
        Console.WriteLine($"\n=== Автомобили {targetYear} года выпуска ===");
        var carsByYear = cars.Where(c => c.Year == targetYear);
        foreach (var car in carsByYear) {
            Console.WriteLine($"{car.Make}, {car.Year} г., зарегистрирован в {car.City}");
        }

        // 3. Данные, сгруппированные по городу регистрации
        Console.WriteLine("\n=== Автомобили, сгруппированные по городу ===");
        var groupedByCity = cars.GroupBy(c => c.City);
        foreach (var group in groupedByCity) {
            Console.WriteLine($"\nГород: {group.Key}");
            foreach (var car in group) {
                Console.WriteLine($" - {car.Make}, {car.Year} г.");
            }
        }
    }
}
