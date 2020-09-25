using System;

namespace OOP_Lab_03
{
    class Book
    {
        private int id;
        private string name;
        public string[] authors;
        public string editors;
        private int year;
        public int pages;
        public double cost;
        public string type;

        public string Name
        {
            get=> name;
            set=> name = value;
        }
        public int Year
        {
            get => year;
            set => year = value;
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
        }
        public Book(int a, string n, string[] b, string c, int d, int e, double f, string g = "Твердый"):this() // конструктор с массивом авторов и параметром по умолчанию
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
        }
        public Book(int a, string n, string b, string c, int d, int e, double f, string g):this() // конструктор с одиночным автором
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
        }
        public void GetInfo()
        {
            Console.WriteLine("----------------------------------------------");
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
    }

    class Program
    {

        static void FindByAuthor(Book[] shelf, string auth)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"По автору: {auth}");
            foreach (Book book in shelf)
            {
                foreach (string name in book.authors)
                {
                    if (name == auth) Console.WriteLine($"- '{book.Name}' {book.Year}");
                }
            }
        }

        static void PublishedAfterYear(Book[] shelf, int year)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Издано после {year} года:");
            foreach (Book book in shelf)
            {
                if(book.Year > year) Console.WriteLine($" {book.authors[0]} - '{book.Name}' {book.Year}");
            }
        }

        static void Main(string[] args)
        {

            Book one = new Book(14, "Че Геваре", "И.Лаврецкий", "United BookShelf Organisation", 2000, 350, 149.99, "Твердый");
            string[] authors = { "John Dexter", "Alan Blueberry" };
            Book two = new Book(65, "Samurai", authors, "Eastern Traditions Factory", 2015, 500, 299.99);
            one.Name = "Эрнесто Че Геваре";
            one.GetInfo();
            two.GetInfo();

            var three = new { id = 11, name = "Fortnite", authors = new string[2]{ "John Asshole", "Mathew Machine"}, editors = "UAR: United Anime Republic", year = 2020, pages = 100, cost = 1.99, type = "Туалетная бумага" };

            Book[] myshelf = new Book[6];
            myshelf[0] = new Book(12, "Путь Воина", "Ямамото Ценэтомо", "Japanese Heritage Books", 1854, 200, 499.99, "Твердый, с декорациями");
            myshelf[1] = new Book(40, "Финансирование", "John Moneyfield", "Economics & Politics Fiction", 1995, 530, 349.99, "Мягкий");
            myshelf[2] = new Book(84, "Medicine in 2020", "Crystal Blake", "USA Library Organization", 2020, 985, 649.99, "Мягкий");
            myshelf[3] = new Book(52, "Истина бытия", "Ямамото Ценэтомо", "Japanese Heritage Books", 1860, 250, 599.99, "Твердый");
            myshelf[4] = new Book(73, "В поисках себя", "Ямамото Ценэтомо", "Japanese Heritage Books", 1880, 300, 199.99, "Твердый");
            myshelf[5] = new Book(99, "Бусидо: кодекс чести самурая", "Юдзан Дайдодзи", "АСТ: Библиотека военной и исторической литературы", 2017, 400, 1239.99, "Твердый");
            foreach (Book x in myshelf)
            {
                x.GetInfo();
            }
            FindByAuthor(myshelf, "Ямамото Ценэтомо");
            PublishedAfterYear(myshelf, 1900);
        }
    }
}
