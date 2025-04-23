using System;
using System.Runtime.ExceptionServices;
public class User {
    public string name;
    public int idNumberPhone;
    public string city;

    public User(string name, int idNumberPhone, string city) {
        this.name = name;
        this.idNumberPhone = idNumberPhone;
        this.city = city;
    }
}


public class Phone {
    public int idNumberPhone;
    public string operatorPhone;
    public string yearStart; 
    public string phone;

    public Phone(int idNumberPhone, string phone, string operatorPhone, string yearStart) {
        this.idNumberPhone = idNumberPhone;
        this.operatorPhone = operatorPhone;
        this.yearStart = yearStart;
        this.phone = phone;
    }
}


class Program {
    static void Main() {
        //base
        List<User> users = new List<User>();
        List<Phone> phones = new List<Phone>();

        mainMenu();
        void mainMenu() {
            // main menu
            Console.WriteLine("\n---------ГЛАВНОЕ МЕНЮ---------");
            Console.WriteLine("1 - добавить пользователя в базу");
            Console.WriteLine("2 - сделать выборку");
            Console.WriteLine("q - выход из программы\n");
            while(true) {
                switch (Console.ReadLine()) {
                    case "q": // exit in program
                        Console.WriteLine("mainMenu");
                        Environment.Exit(0);
                        break;
                    case "1": // add user
                        addUser();
                        break;
                    case "2": // select user
                        menuSelectUser();
                        break;
                        

                }   
            }
        }

        void addUser() {
            // add user in base
            Console.WriteLine("\n---------Добавление пользователя---------");
            Console.WriteLine("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите город проживания: ");
            string city = Console.ReadLine();
            users.Add(new User(name, users.Count+1, city));
            addPhonesUser(users.Count);
            mainMenu();
        }

        void addPhonesUser(int idNumberPhone) {
            // add phone in user
            Console.Clear();
            Console.WriteLine("\n---------Добавление телефона---------");
            Console.WriteLine("Введите номер телефона: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Введите оператор: ");
            string operatorPhone = Console.ReadLine();
            Console.WriteLine("Введите год начала использования: ");
            string yearStart = Console.ReadLine();
            phones.Add(new Phone(idNumberPhone, phone, operatorPhone, yearStart));
            Console.WriteLine("Телефон добавлен");
            Console.WriteLine(idNumberPhone);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1 - добавить еще один телефон");
            Console.WriteLine("q - вернуться в главное меню");
            while(true) {
                switch (Console.ReadLine()) {
                    case "1":
                        addPhonesUser(idNumberPhone);
                        break;
                    case "q":
                        Console.WriteLine("addPhonesUser");

                        mainMenu();
                        break;
                }
            }
        }

        void menuSelectUser() {
            // select user in base
            Console.WriteLine("\n---------Выборка пользователя---------");
            Console.WriteLine("Выберите параметр выборки: ");
            Console.WriteLine("1 - по номеру телефона");
            Console.WriteLine("2 - по оператору");
            Console.WriteLine("3 - по году начала использования");
            Console.WriteLine("4 - по городу");
            Console.WriteLine("q - вернуться в главное меню");
            while(true) {
                switch (Console.ReadLine()) {
                    case "1":
                        Console.WriteLine("Введите номер телефона :");
                        string param = Console.ReadLine();
                        phoneSelect(param);
                        break;
                    case "2":
                        Console.WriteLine("Введите оператор :");
                        param = Console.ReadLine();
                        phoneSelect(param);
                        break;
                    case "3":
                        Console.WriteLine("Введите год начала использования :");
                        param = Console.ReadLine();
                        phoneSelect(param);
                        break;
                    case "4":
                        Console.WriteLine("Введите город :");
                        param = Console.ReadLine();
                        citySelect(param);
                        break;  
                    case "q":
                        Console.WriteLine("menuSelectUser");
                        mainMenu();
                        break;
                }
            }
        }

        void phoneSelect(string param) {
            for (int i = 0; i < phones.Count; i++) {
                if (phones[i].phone == param || phones[i].operatorPhone == param || phones[i].yearStart == param) {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("ФИО: " + users[phones[i].idNumberPhone-1].name); 
                    Console.WriteLine("Город: " + users[phones[i].idNumberPhone-1].city);
                    for (int j = 0; j < phones.Count; j++) {
                        if (phones[j].idNumberPhone == phones[i].idNumberPhone) {
                            Console.WriteLine("Телефон: " + phones[j].phone);
                            Console.WriteLine("Оператор: " + phones[j].operatorPhone);
                            Console.WriteLine("Год начала использования: " + phones[j].yearStart);
                        }
                    }
                }
            }
        }


        void citySelect(string param) {
            for (int i = 0; i < users.Count; i++) {
                if (users[i].city == param) {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("ФИО: " + users[i].name); 
                    Console.WriteLine("Город: " + users[i].city);
                    for (int j = 0; j < phones.Count; j++) {
                        if (phones[j].idNumberPhone == users[i].idNumberPhone) {
                            Console.WriteLine("Телефон: " + phones[j].phone);
                            Console.WriteLine("Оператор: " + phones[j].operatorPhone);
                            Console.WriteLine("Год начала использования: " + phones[j].yearStart);
                        }
                    }
                }
            }
        }
    }
}
