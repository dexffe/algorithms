using System;
using System.Collections.Generic;
using System.Linq;

class Product {
    public int numberProduct { get; set; }
    public string? nameProduct { get; set; }
}

class Supplier {
    public int numberSupplier { get; set; }
    public string? nameSupplier { get; set; }
    public string? phoneSupplier { get; set; }
}

class MovementOfGoods {
    public int numberProduct { get; set; }
    public int numberSupplier { get; set; }
    public string? dateOfReceipt { get; set; }
    public int countProduct { get; set; }
    public int pricePerUnit { get; set; }
}



class Program {
    static List<Product> products = new List<Product>() {
        new Product { numberProduct = 1, nameProduct = "Ноутбук" },
        new Product { numberProduct = 2, nameProduct = "Смартфон" },
        new Product { numberProduct = 3, nameProduct = "Планшет" },
        new Product { numberProduct = 4, nameProduct = "Монитор" },
        new Product { numberProduct = 5, nameProduct = "Клавиатура" }
    };

    static List<Supplier> suppliers = new List<Supplier>() {
        new Supplier { numberSupplier = 101, nameSupplier = "ТехноПоставка", phoneSupplier = "+7(123)456-7890" },
        new Supplier { numberSupplier = 102, nameSupplier = "Электроникс", phoneSupplier = "+7(234)567-8901" },
        new Supplier { numberSupplier = 103, nameSupplier = "ГаджетЛэнд", phoneSupplier = "+7(345)678-9012" },
        new Supplier { numberSupplier = 104, nameSupplier = "КомпьютерМаркет", phoneSupplier = "+7(456)789-0123" }
    };

    static List<MovementOfGoods> movementOfGoods = new List<MovementOfGoods>() {
        new MovementOfGoods { numberProduct = 1, numberSupplier = 101, dateOfReceipt = "2023-01-15", countProduct = 10, pricePerUnit = 50000 },
        new MovementOfGoods { numberProduct = 2, numberSupplier = 102, dateOfReceipt = "2023-01-16", countProduct = 20, pricePerUnit = 30000 },
        new MovementOfGoods { numberProduct = 3, numberSupplier = 103, dateOfReceipt = "2023-01-17", countProduct = 15, pricePerUnit = 25000 },
        new MovementOfGoods { numberProduct = 4, numberSupplier = 104, dateOfReceipt = "2023-01-18", countProduct = 8, pricePerUnit = 15000 },
        new MovementOfGoods { numberProduct = 5, numberSupplier = 101, dateOfReceipt = "2023-01-19", countProduct = 30, pricePerUnit = 2000 },
        new MovementOfGoods { numberProduct = 1, numberSupplier = 102, dateOfReceipt = "2023-01-20", countProduct = 5, pricePerUnit = 52000 },
        new MovementOfGoods { numberProduct = 3, numberSupplier = 104, dateOfReceipt = "2023-01-21", countProduct = 12, pricePerUnit = 24000 }
    };

    static public void Query1() {
        // Запрос: выдать все товары сгруппированные по поставщикам
        var productsBySupplier = from mov in movementOfGoods
                                join prod in products on mov.numberProduct equals prod.numberProduct
                                join supp in suppliers on mov.numberSupplier equals supp.numberSupplier
                                group prod.nameProduct by supp.nameSupplier into supplierGroup
                                select new {
                                    SupplierName = supplierGroup.Key,
                                    Products = supplierGroup.ToList()
                                };

        foreach (var supplier in productsBySupplier) {
            Console.WriteLine($"Поставщичек: {supplier.SupplierName}");
            Console.WriteLine("Товарчики:");
            foreach (var productName in supplier.Products) {
                Console.WriteLine($"- {productName}");
            }
            Console.WriteLine();
        }
    }

    static public void Query2() {
        // Запрос: определить суммарную стоимость товаров по дате поставки
        var totalCostByDate = from mov in movementOfGoods
                             group mov by mov.dateOfReceipt into dateGroup
                             select new {
                                 Date = dateGroup.Key,
                                 TotalCost = dateGroup.Sum(m => m.countProduct * m.pricePerUnit)
                             };

        Console.WriteLine("Суммарная стоимость товаров по дате поставки:");
        Console.WriteLine("--------------------------------------------");
        foreach (var item in totalCostByDate.OrderBy(d => d.Date))
        {
            Console.WriteLine($"{item.Date}: {item.TotalCost} руб.");
        }
    }

    static public void Query3() {
        // Запрос: выдать поставщика поставившего товар на большую сумму
        var supplierWithMaxDelivery = from mov in movementOfGoods
                                    join supp in suppliers on mov.numberSupplier equals supp.numberSupplier
                                    group new { mov, supp } by supp.nameSupplier into supplierGroup
                                    let totalSum = supplierGroup.Sum(x => x.mov.countProduct * x.mov.pricePerUnit)
                                    orderby totalSum descending
                                    select new
                                    {
                                        SupplierName = supplierGroup.Key,
                                        TotalSum = totalSum,
                                    } into result
                                    orderby result.TotalSum descending
                                    select result;

        var topSupplier = supplierWithMaxDelivery.FirstOrDefault();

        Console.WriteLine("Поставщик, поставивший товар на наибольшую сумму:");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"Наименование: {topSupplier.SupplierName}");
        Console.WriteLine($"Общая сумма поставок: {topSupplier.TotalSum} руб.");
    
    
    }

    static void Main(string[] args) {
        Query1();  // Запрос: выдать все товары сгруппированные по поставщикам
        //Query2();  // Запрос: определить суммарную стоимость товаров по дате поставки
        //Query3();  // Запрос: выдать поставщика поставившего товар на большую сумму
    }
}