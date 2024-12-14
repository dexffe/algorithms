using System;
class Car(string brand, string year, string color, string country) {
    public string brand = brand;
    public string year = year;
    public string color = color;
    public string country = country;
}

class Program {
    static void Main() {
        // Cars base
        Console.Write("Предел по количеству машин в базе: ");
        Car[] cars = new Car[int.Parse(Console.ReadLine())];
        for (int i = 0; i < cars.Length; i++) {
            cars[i] = new Car("none", "none", "none", "none"); // заполним массив пустышками во избежании ошибок
        }

        // count cars in base
        int CountCars = 0;

        // Start program
        MainMenu(); 

        void MainMenu() {
            // main menu
            Console.Clear();
            Console.WriteLine("\n---------ГЛАВНОЕ МЕНЮ---------");
            Console.WriteLine("add - добавить автомобиль в базу");
            Console.WriteLine("sort - сделать выборку автомобилей");
            Console.WriteLine("exit - выход из программы\n");

            // render menu
            while(true) {
                switch (Console.ReadLine()) {
                    case "exit": // exit in program
                        Environment.Exit(0);
                        break;
                    case "add": // add car in base
                        if (cars.Length == CountCars) {
                            Console.WriteLine("База машин заполненна.");
                            Thread.Sleep(1500);
                            MainMenu();
                        } else AddCar();
                        break;
                    case "sort": // sort cars by parameter
                        if (CountCars == 0) {
                            Console.WriteLine("База машин пуста! Добавьте машину.");
                            Thread.Sleep(1500);
                            MainMenu();
                        } else RequestData();
                        break;
                }   
            }
        }

        void AddCar() {
            // get info
            Console.Clear();
            Console.WriteLine("\n---------ДОБАВЛЕНИЕ АВТОМОБИЛЯ---------");
            Console.Write("Введите марку автомобиля: ");
            string brand = Console.ReadLine();
            Console.Write("Введите год выпуска автомобиля: ");
            string year = Console.ReadLine();
            Console.Write("Введите цвет автомобиля: ");
            string color = Console.ReadLine();
            Console.Write("Введите страну производства автомобиля: ");
            string country = Console.ReadLine();

            // checking for emptiness
            if (brand == "" || year == "" || color == "" || country == "") {
                Console.WriteLine("Не все поля заполнены!");
                Console.WriteLine("Поворить попытку? (y/n)");
                if (Console.ReadLine() == "y") {
                    AddCar();
                }
                MainMenu();
                return;
            }

            // add car in base
            cars[CountCars] = (new Car(brand, year, color, country));
            CountCars++;

            // success
            Console.WriteLine("Автомобиль успешно добавлен!");
            Thread.Sleep(1500);
            MainMenu();
        }

        void RequestData() {
            // request data
            Console.Clear();
            Console.WriteLine("\n---------ВЫБОРКА АВТОМОБИЛЕЙ---------");
            Console.WriteLine("year - выборка по году выпуска автомобиля");
            Console.WriteLine("country - выборка по стране производства автомобиля");
            Console.WriteLine("brand - выборка по марке автомобиля");
            Console.WriteLine("back - вернуться в главное меню\n");

            // render request data
            while (true) {
                switch (Console.ReadLine()) {
                    case "year":
                        SortedByYear();
                        break;
                    case "country":
                        SortedByCountry();
                        break;
                    case "brand":
                        SortedByBrand();
                        break;
                    case "back":
                        MainMenu();
                        return;
                }
            }

            void SortedByYear() {
                Console.Write("Введите год выпуска автомобиля: ");
                string year = Console.ReadLine();

                for (int i = 0; i < cars.Length; i++) {
                    if (cars[i].year == year) {
                        Console.WriteLine($"{cars[i].brand} {cars[i].year} {cars[i].color} {cars[i].country}\n");
                    }
                }
            }

            void SortedByCountry() {
                Console.Write("Введите страну производства автомобиля: ");
                string country = Console.ReadLine();

                for (int i = 0; i < cars.Length; i++) {
                    if (cars[i].country == country) {
                        Console.WriteLine($"{cars[i].brand} {cars[i].year} {cars[i].color} {cars[i].country}\n");
                    }
                }
            }

            void SortedByBrand() {
                Console.Write("Введите марку автомобиля: ");
                string brand = Console.ReadLine();                

                for (int i = 0; i < cars.Length; i++) {
                    if (cars[i].brand == brand) {
                        Console.WriteLine($"{cars[i].brand} {cars[i].year} {cars[i].color} {cars[i].country}\n");
                    }       
                }
            }
        }
    }
}