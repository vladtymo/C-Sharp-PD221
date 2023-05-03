using System.Linq;

namespace _19_linq
{
    // LINQ (Language-Integrated Query)

    // Існує декілька різновидів LINQ:
    /*
        LINQ to Objects:        застосовується для роботи з масивами та колекціями
        LINQ to Entities:       використовується при зверненні до баз даних через технологію Entity Framework
        LINQ to Sql:            технологія доступу до даних у MS SQL Server
        LINQ to XML:            застосовується під час роботи з файлами XML
        LINQ to DataSet:        застосовується під час роботи з об'єктом DataSet
        Parallel LINQ (PLINQ):  використовується для виконання паралельної запитів 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 5, 5, 120, 6, 6, -4, 44, -30, -1, -1, 0, 4, 194, 242, 52 };
            string[] colors = { "red", "gray", "white", "blue", "green", "yellow", "cyan", "dark" };
            Product[] products =
            {
                new Product() { Model = "Samsung", Price = 345.5M, Category = "Phone" },
                new Product() { Model = "Apple", Price = 325.3M, Category = "Laptop" },
                new Product() { Model = "Xiaomi", Price = 1240, Category = "Phone" },
                new Product() { Model = "LG", Price = 12500.5M, Category = "TV" }
            };

            ShowCollection(array, "Original");

            // 1 - синтаксис методів

            // Where() - фільтрує колекцію елементів по умові
            //var result = array.Where(IsEven);
            //var result = array.Where((n) => n % 2 == 0);
            var result = array.Where((n) => Math.Pow(n, 2) < 20);

            ShowCollection(result, "Filtered");

            // OrderBy() - сортує елементи по певному параметру
            result = array.OrderBy(x => Math.Abs(x));
            result = array.OrderByDescending(x => Math.Abs(x));
            var prSorted = products.OrderBy(x => x.Price);

            ShowCollection(result, "Ordered");
            ShowCollection(prSorted, "Ordered products");

            // Select() - проектує елементи колекції в певний вигляд
            var mapped = array.Select(x => $"[{x}]");
            var models = products.Select(p => p.Model);

            ShowCollection(mapped, "Mapped numbers");
            ShowCollection(models, "Models");

            // Aggregation: Min, Max, Sum, Average, Count

            var maxNumber = array.Max();

            var minPrice = products.Min(x => x.Price);      // return price
            var minProduct = products.MinBy(x => x.Price);  // return product

            var totalChars = colors.Sum(x => x.Length);
            var avg = array.Average();
            var negativeCount = array.Count(x => x < 0);

            Console.WriteLine("Max number: " + maxNumber);
            Console.WriteLine("Min price: " + minPrice);
            Console.WriteLine("Min product: " + minProduct);
            Console.WriteLine("Total chars: " + totalChars);
            Console.WriteLine("Average number: " + avg);
            Console.WriteLine("Negative count: " + negativeCount);

            // Take(), TakeLast(), TakeWhile(), Distict()
            var topNumbers = array.OrderByDescending(x => x).Take(3); // TOP 3 numbers
            var firstPositiveNumbers = array.TakeWhile(x => x > 0);

            ShowCollection(firstPositiveNumbers, "First Positives");
            ShowCollection(topNumbers, "TOP 3 numbers");
            ShowCollection(array.Distinct(), "Distinct");

            // First(), FirstOrDefault(), Last(), LastOrDefault()
            var first = array.First(x => x > 200);                           // if no element - throw exception
            var firstProduct = products.FirstOrDefault(p => p.Price > 1000); // if no element - return default value

            if (firstProduct != null)
                Console.WriteLine("First product: " + firstProduct);
            else
                Console.WriteLine("Product not found!");

            Console.WriteLine("First: " + first);

            // GroupBy() - виконує групування елементів по певному ключу
            //var groups = colors.GroupBy(s => s.Length);
            var groups = products.GroupBy(p => p.Category);

            foreach (var g in groups)
            {
                Console.Write($"Group key: {g.Key} : ");
                foreach (var item in g)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

            // 2 - синтаксис запитів
            var querySyntax = from number in array
                              where number > 0 && number < 100
                              orderby Math.Abs(number)
                              select number;

            // теж саме за допомогою синтаксису методів
            var methodSyntax = array.Where(x => x > 0 && x < 100).OrderBy(x => Math.Abs(x));
        }

        static void ShowCollection<T>(IEnumerable<T> collection, string? title = null)
        {
            Console.Write($"{title ?? "Collection"}: ");

            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
    }

    class Product
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return $"{Model}:{Price}$";
        }
    }
}