using System;
using System.Collections.Generic;

class Phone {
    public string numberPhone;
    public string operatorPhone;
    public Phone(string numberPhone, string operatorPhone) {
        this.numberPhone = numberPhone;
        this.operatorPhone = operatorPhone;
    } 
}

class Program {
    static Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

    static void Main(string[] args) {
        Console.WriteLine("q - выход");
        Console.WriteLine("t - таблица операторов");
        Console.WriteLine("Введите номер телефона и оператора (123456789 MTS): ");
        while (true) {
            string[] input = Console.ReadLine().Split(" "); 
            if (input[0] == "t") {
                foreach (var item in dict) {
                    Console.WriteLine($"{item.Key}: {string.Join(", ", item.Value)}");
                }
            }else if (input[0] == "q") {
                break;
            } else if (input.Length == 2) {
                Phone phone = new Phone(input[0], input[1]);

                if (dict.ContainsKey(phone.operatorPhone)) {
                    dict[phone.operatorPhone].Add(phone.numberPhone);
                } else {
                    dict[phone.operatorPhone] = new List<string> { phone.numberPhone };
                }
            } else {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
    }
}