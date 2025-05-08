using System;
using System.Collections.Generic;
using System.Linq;

public struct LoanInfo {
    public DateTime IssueDate;
    public DateTime? ReturnDate; // null если не возвращена

    public LoanInfo(DateTime issueDate, DateTime? returnDate) {
        IssueDate = issueDate;
        ReturnDate = returnDate;
    }

    public bool IsReturned => ReturnDate.HasValue;
}

public struct Book {
    public string AuthorSurname;
    public string Title;
    public int YearPublished;
    public string Publisher;
    public List<LoanInfo> Loans;

    public Book(string authorSurname, string title, int yearPublished, string publisher) {
        AuthorSurname = authorSurname;
        Title = title;
        YearPublished = yearPublished;
        Publisher = publisher;
        Loans = new List<LoanInfo>();
    }

    public bool WasLoaned => Loans.Count > 0;

    public bool HasUnreturnedCopies => Loans.Any(loan => !loan.ReturnDate.HasValue);
}

class Library {
    private List<Book> books = new List<Book>();

    public void AddBook(Book book) => books.Add(book);

    public List<Book> GetNeverLoanedBooks() =>
        books.Where(b => !b.WasLoaned).ToList();

    public List<Book> GetUnreturnedBooks() =>
        books.Where(b => b.HasUnreturnedCopies).ToList();
}

class Program {
    static void Main() {
        Library library = new Library();

        Book b1 = new Book("Толстой", "Война и мир", 1869, "АСТ");
        b1.Loans.Add(new LoanInfo(new DateTime(2023, 10, 1), new DateTime(2023, 10, 15)));
        b1.Loans.Add(new LoanInfo(new DateTime(2024, 1, 5), null)); // Не возвращена

        Book b2 = new Book("Достоевский", "Преступление и наказание", 1866, "Эксмо");
        b2.Loans.Add(new LoanInfo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 10)));

        Book b3 = new Book("Чехов", "Вишнёвый сад", 1904, "Азбука"); // Никогда не выдавалась

        Book b4 = new Book("Пушкин", "Евгений Онегин", 1833, "Литрес");
        b4.Loans.Add(new LoanInfo(new DateTime(2024, 3, 1), null)); // Не возвращена

        library.AddBook(b1);
        library.AddBook(b2);
        library.AddBook(b3);
        library.AddBook(b4);

        // Выводим книги, которые ни разу не выдавались
        Console.WriteLine("Книги, которые ни разу не выдавались:");
        foreach (var book in library.GetNeverLoanedBooks()) {
            Console.WriteLine($"{book.AuthorSurname} - {book.Title}");
        }

        Console.WriteLine("\nКниги, которые не возвращены обратно:");
        foreach (var book in library.GetUnreturnedBooks()) {
            Console.WriteLine($"{book.AuthorSurname} - {book.Title}");
        }
    }
}
