namespace _01_base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // entry point
            Console.WriteLine("Hello, World!");

            // -------------- data types --------------
            bool flagVal = true;
            int intVal = 10;
            float floatVal = 56.7F; // F - float
            double doubleVal = floatVal;
            decimal decimalVal = 10000000.99999999999M; // M - decimal (16 bytes)

            string strVal = "some string value...";

            // non-nullable types: structures
            // nullable types: classes
            //intVal = null;
            strVal = null;

            // .? - null condition operator
            strVal?.ToUpper(); // error with null

            // Nullable<> structure
            //Nullable<int> nullableVal = null;
            int? nullableInt = 56;
            nullableInt = null;

            // -------------- working with console --------------
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("This is C#!");
            // snippet: cw
            Console.WriteLine(" - some text with end of line at the end...");
            // excape sequences
            Console.WriteLine("Hello \"Vladyslav\"...\nTab\tTab\tTab");

            Console.ResetColor();

            // interpolation (comes from C# 6): $"text{expression}text"
            Console.WriteLine($"Expresion: {2 + 2 * 2}!!! 2^4 = {Math.Pow(2, 4)}");

            Console.Write("Enter your login: ");
            string username = Console.ReadLine(); // read until end of line [enter]

            Console.WriteLine($"Hello, dear {username}!");

            // parsing
            Console.Write("Enter current year: ");
            int year = int.Parse(Console.ReadLine());

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Spacebar)
            {
                Console.Beep();
            }

            // base statements still the same as in C++

            if (5 > 0)
            {

            }
            else
            {

            }

            Console.WriteLine($"Result: {(4 > 1 ? "Bigger" : "Less")}");
            
            for (int i = 0; i < 5; i++)
            {

            }
        }
    }
}