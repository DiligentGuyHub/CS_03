using System;
using System.Threading.Tasks.Dataflow;

namespace OOP_Lab_03
{
    class Book
    {
        private readonly int id;
        private string name;
        private string[] authors;
        private string editors;
        private int year;
        private int pages;
        private double cost;
        static string type;
        private const double basic_cost = 99.99;
        static int amount = 0;

        public int ID { get => id; }
        public string Name { get => name; set => name = value; }
        public int Year { get => year; }
        public string[] Authors { get => authors; set => authors = value; }
        public int Pages { get => pages; set => pages = value; }
        public double Cost { get => cost; set => cost = value; }

        static public void OutAmount()
        {
            Console.WriteLine($"\nВсего создано {amount} объектов класса Book");
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Book book = (Book)obj;
            return (this.Name == book.Name);
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Name)) return base.ToString();
            return Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        static Book()
        {
            string type = "Твердый";
        }
        
        public Book() // пустой конструктор без параметров
        {
            id = 0;
            name = "no info";
            authors = new string[1];
            authors[0] = "no info";
            editors = "no info";
            year = 0;
            pages = 0;
            cost = 0;
            type = "no info";
            amount++;
        }
        public Book(int a, string n, string[] b, string c, int d, int e, double f = basic_cost, string g = "Твердый") // конструктор с массивом авторов и параметром по умолчанию
        {
            id = a;
            name = n;
            authors = new string[b.Length];
            authors = b;
            editors = c;
            year = d;
            pages = e;
            cost = f;
            type = g;
            amount++;
        }
        public Book(int a, string n, string b, string c, int d, int e, double f = basic_cost, string g = "Твердый") // конструктор с одиночным автором
        {
            id = a;
            name = n;
            authors = new string[1];
            authors[0] = b;
            editors = c;
            year = d;
            pages = e;
            cost = f;
            type = g;
            amount++;
        }
        public void GetInfo()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.Write($"[{id}] \"{name}\"\n");
            if (authors.Length == 1) Console.Write($"Автор: {authors[0]}\n");
            else
            {
                Console.Write("Авторы: ");
                foreach(string x in authors)
                {
                    Console.Write($"{x} ");
                }
                Console.Write('\n');
            }
            Console.WriteLine($"Издательство: {editors}\nГод издания: {year}\nКоличество страниц: {pages}\nЦена: {cost}\nПереплет: {type}");
        }

        public static void FindByAuthor(Book[] shelf, string auth)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine($"По автору: {auth}");
            foreach (Book book in shelf)
            {
                foreach (string name in book.Authors)
                {
                    if (name == auth) Console.WriteLine($"- '{book.Name}' {book.Year}");
                }
            }
        }

        public static void PublishedAfterYear(Book[] shelf, ref int year)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine($"Издано после {year} года:");
            foreach (Book book in shelf)
            {
                if (book.Year > year) Console.WriteLine($" {book.Authors[0]} - '{book.Name}' {book.Year}");
            }
        }
        public static void ChangeCost(out Book newbook, Book book, double cost)
        {
            newbook = book;
            newbook.Cost = cost;
        }
    }

    public partial class Person
    {
        public int age;
    }

    public partial class Person
    {
        public void Birthday()
        {
            age++;
            Console.WriteLine($"\nHappy birthday! You are {age} years old now!");
        }
    }
    class Program
    {

        
        static void Main(string[] args)
        {

            Book one = new Book(14, "Че Геваре", "И.Лаврецкий", "United BookShelf Organisation", 2000, 350, 149.99, "Твердый");
            string[] authors = { "John Dexter", "Alan Blueberry" };
            Book two = new Book(65, "Samurai", authors, "Eastern Traditions Factory", 2015, 500, 299.99);
            one.Name = "Эрнесто Че Геваре";
            one.GetInfo();
            two.GetInfo();

            Book[] myshelf = new Book[7];
            myshelf[0] = new Book(12, "Путь Воина", "Ямамото Ценэтомо", "Japanese Heritage Books", 1854, 200, 499.99, "Твердый, с декорациями");
            myshelf[1] = new Book(40, "Финансирование", "John Moneyfield", "Economics & Politics Fiction", 1995, 530, 349.99, "Мягкий");
            Book.ChangeCost(out myshelf[1], myshelf[1], 299.99);
            myshelf[2] = new Book(84, "Medicine in 2020", "Crystal Blake", "USA Library Organization", 2020, 985, 649.99, "Мягкий");
            myshelf[3] = new Book(52, "Истина бытия", "Ямамото Ценэтомо", "Japanese Heritage Books", 1860, 250, 599.99, "Твердый");
            myshelf[4] = new Book(73, "В поисках себя", "Ямамото Ценэтомо", "Japanese Heritage Books", 1880, 300, 199.99, "Твердый");
            myshelf[5] = new Book(99, "Бусидо: кодекс чести самурая", "Юдзан Дайдодзи", "АСТ: Библиотека военной и исторической литературы", 2017, 400, 1239.99, "Твердый");
            myshelf[6] = new Book(98, "Бусидо: кодекс чести самурая", "Юдзан Дайдодзи", "Japanese Heritage Books", 2018, 360, 1039.99, "Твердый");
            foreach (Book x in myshelf)
            {
                x.GetInfo();
            }
            Book.FindByAuthor(myshelf, "Ямамото Ценэтомо");
            int year = 1900;
            Book.PublishedAfterYear(myshelf, ref year);
            Book.OutAmount();

            var three = new { id = 11, name = "Castle Bridge", authors = new string[2] { "John Anderson", "Mathew Machine" }, editors = "United Animated Republic", year = 2020, pages = 100, cost = 1.99, type = "Мягкий" };
            Console.WriteLine(
                $"\nАнонимный тип:\n\"{three.name}\" - {three.authors[0]}, {three.authors[1]}\n" +
                $"{three.editors}, {three.year}, {three.pages} страниц, {three.type} переплет"
                );

            Person human = new Person { age = 18 };
            human.Birthday();

            Console.WriteLine(
                $"\nСовпадает ли название книги с индексом {myshelf[5].ID}" +
                $" с названием книги под индексом {myshelf[6].ID}? {myshelf[5].Equals(myshelf[6])}"
                );
            Console.WriteLine(
                $"\nСовпадает ли название книги с индексом {myshelf[4].ID}" +
                $" с названием книги под индексом {myshelf[5].ID}? {myshelf[4].Equals(myshelf[5])}"
                );
            Console.WriteLine(
                $"\nМетод toString() для книги с индексом {myshelf[0].ID}" +
                $" возвращает: \"{myshelf[0].ToString()}\""
                );
            Console.WriteLine(
                $"\nМетод GetHashCode() для книги с индексом {myshelf[3].ID}" +
                $" возвращает: {myshelf[3].GetHashCode()}"
                );
        }
    }
}
