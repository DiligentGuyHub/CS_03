using System;

namespace OOP_Lab_03
{
    class Book
    {
        private int id;
        public string name;
        public string[] authors;
        public string editors;
        public int year;
        public int pages;
        public double cost;
        public string type;
        public Book()
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
        public Book(int a, string n, string[] b, string c, int d, int e, double f, string g = "Твердый")
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

        public Book(int a, string n, string b, string c, int d, int e, double f, string g)
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
        static void Main(string[] args)
        {
            Book one = new Book(14, "Че Геваре", "И.Лаврецкий", "United BookShelf Organisation", 2000, 350, 149.99, "Твердый");
            string[] authors = { "John Dexter", "Alan Blueberry" };
            Book two = new Book(65, "Samurai", authors, "Eastern Traditions Factory", 2015, 500, 299.99);
            one.GetInfo();
            two.GetInfo();
        }
    }
}
