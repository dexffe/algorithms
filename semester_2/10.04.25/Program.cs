using System;
using System.Collections.Generic;
using System.Linq;

public struct LoanDate {
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public LoanDate(int day, int month, int year) {
        Day = day;
        Month = month;
        Year = year;
    }
}

public struct LoanInfo {
    public LoanDate IssueDate;
    public LoanDate? ReturnDate;

    public LoanInfo(LoanDate issueDate, LoanDate? returnDate = null) {
        IssueDate = issueDate;
        ReturnDate = returnDate;
    }

    public bool IsReturned => ReturnDate.HasValue;
}

public struct Book {
    public string Author;
    public string Title;
    public int YearPublished;
    public string Publisher;
    public List<LoanInfo> Loans;

    public Book(string author, string title, int year, string publisher) {
        Author = author;
        Title = title;
        YearPublished = year;
        Publisher = publisher;
        Loans = new List<LoanInfo>();
    }

    public bool WasLoaned => Loans.Count > 0;
    public bool HasUnreturnedCopies => Loans.Any(l => !l.IsReturned);
}

class Program {
    static void Main() {
        List<Book> library = new List<Book>();

        // --- Заполнение базы данных ---
        Book book1 = new Book("Лев Толстой", "Война и мир", 1869, "АСТ");
        book1.Loans.Add(new LoanInfo(new LoanDate(15, 3, 2023), new LoanDate(20, 4, 2023)));
        book1.Loans.Add(new LoanInfo(new LoanDate(10, 1, 2024))); // Не возвращена

        Book book2 = new Book("Фёдор Достоевский", "Преступление и наказание", 1866, "Эксмо");

        Book book3 = new Book("Антон Чехов", "Вишневый сад", 1904, "Азбука");
        book3.Loans.Add(new LoanInfo(new LoanDate(5, 2, 2024), new LoanDate(10, 2, 2024)));

        Book book4 = new Book("Александр Пушкин", "Евгений Онегин", 1833, "Литрес");
        book4.Loans.Add(new LoanInfo(new LoanDate(1, 3, 2024))); // Не возвращена

        library.Add(book1);
        library.Add(book2);
        library.Add(book3);
        library.Add(book4);

        // --- Вывод книг, которые никогда не выдавались ---
        Console.WriteLine("=== Книги, которые ни разу не выдавались ===");
        var neverLoaned = library.Where(b => !b.WasLoaned).ToList();
        foreach (var book in neverLoaned) {
            Console.WriteLine($"{book.Author} - {book.Title}");
        }

        // --- Вывод книг, которые не сданы обратно ---
        Console.WriteLine("\n=== Книги, которые выданы, но не сданы ===");
        var unreturnedBooks = library.Where(b => b.HasUnreturnedCopies).ToList();
        foreach (var book in unreturnedBooks) {
            Console.WriteLine($"{book.Author} - {book.Title}");

            foreach (var loan in book.Loans.Where(l => !l.IsReturned)) {
                string issueDate = $"{loan.IssueDate.Day:D2}.{loan.IssueDate.Month:D2}.{loan.IssueDate.Year}";
                Console.WriteLine($"  Выдана: {issueDate}");
            }
        }
    }
}
