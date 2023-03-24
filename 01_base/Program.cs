using System.Text;

namespace _01_base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // entry point
            Console.WriteLine("Hello, World!");

            // -------------- data types --------------
            /* default values for types:
             *  numeric types:   0
             *  boolean:         false
             *  reference types: null
             */

            bool flagVal = true;                        // 1 byte: 0 - false, <0> - true
            byte byteVal = 255;                         // 1 byte: 0...+255
            short shortVal = 30143;                     // 2 bytes: -32xxx...+32xxx
            int intVal = 10;                            // 4 bytes
            long longVal = 4545;                        // 8 bytes
            float floatVal = 56.7F;                     // F - float: 4 bytes
            double doubleVal = floatVal;                // 8 bytes
            decimal decimalVal = 10000000.99999999999M; // M - decimal: 16 bytes

            // signed / unsigned
            sbyte sbyteVal = -128;  // signed byte: -128...+127
            uint uintVal = 123;     // unsigned int: 0...
            // ulong, ushort

            string strVal = "some string value...";

            // ---------- base type Syste.Object ----------
            object obj = new object();

            Console.WriteLine($"Type: {obj.GetType()}");
            Console.WriteLine($"Equals: {obj.Equals(123)}");
            Console.WriteLine($"Hash Code: {obj.GetHashCode()}");
            Console.WriteLine($"String: {obj.ToString()}"); // automatically ToString()

            // -------------- literals --------------
            // GetType() - get information of the variable type
            Type type = strVal.GetType();
            if (type.IsClass) Console.WriteLine("String is a class!");

            Console.WriteLine($"Type of 123: {123.GetType()}");
            Console.WriteLine($"Type of 123L: {123L.GetType()}");
            Console.WriteLine($"Type of 123.5: {123.5.GetType()}");
            Console.WriteLine($"Type of 123.5F: {123.5F.GetType()}");
            Console.WriteLine($"Type of 123.5M: {123.5M.GetType()}");

            // -------------- Type Conversion --------------
            // Implicit (неявне)            
            float fl1 = 4.5F;
            int in1 = 44;
            float fl2 = fl1 + in1;
            double db1 = fl2;
            //int in2 = fl1; // error            

            // Explicit (явне)
            int in2 = (int)fl1;

            // -------------- nullable types --------------
            // non-nullable: structures (primitives types: int, enum, DateTime, long...)
            // nullable:     classes (String, Array, Random...)

            //intVal = null; // error
            strVal = null;

            // [.?] - null-condition operator
            strVal?.ToUpper(); // error with null

            // [??] - null-coalescing operator
            string message = $"We have string value: {strVal ?? "no data"}"; // (strVal == null ? "no data" : strVal)

            Console.WriteLine(message);

            Nullable<int> nullableVal = null; // allow null
            // or
            int? nullableInt = 56; // int? = Nullable<int>
            nullableInt = null;

            if (nullableInt.HasValue)
                Console.WriteLine($"Variable has value: {nullableInt.Value}");

            // -------------- string interpolation --------------
            // interpolation (comes from C# 6): $"text{expression}text"
            Console.WriteLine($"Expresion: {2 + 2 * 2}!!! 2^4 = {Math.Pow(2, 4)}");

            Console.Write("Enter your login: ");
            string username = Console.ReadLine(); // read until end of line [enter]

            Console.WriteLine($"Hello, dear {username}!");

            // -------------- parsing / converting --------------
            Console.Write("Enter current year: ");
            
            // type.Parse() - convert any type to string 
            int year = int.Parse(Console.ReadLine());

            decimal result = Convert.ToDecimal("454.12");
            Console.WriteLine($"Result of converting to decimal: {result}, type: {result.GetType()}");

            // -------------- base statements --------------
            Console.WriteLine($"Result: {(4 > 1 ? "Bigger" : "Less")}");

            if (5 > 0)
            {

            }
            else
            {

            }

            switch (intVal)
            {
                case 1: break;
                default:
                    break;
            }

            for (int i = 0; i < 5; i++)
            {

            }

            // -------------- console --------------
            WorkingWithConsole();

            // -------------- randomizer --------------
            Random rnd = new Random();
            rnd.Next();             // randome value [0...IntMax]
            rnd.Next(100);          // max value [0...99]
            rnd.Next(-100, 100);    // range [-100...99]
            rnd.NextDouble();       // real value: [0...1]

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rnd.Next(-10, 10));
            }
        }

        static void WorkingWithConsole()
        {
            // -------------- working with console --------------
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("українські символи в консолі...");

            Console.Title = "First C# Console Application -:)";

            Console.Write("This is C#!");
            // snippet: cw
            Console.WriteLine(" - some text with end of line at the end...");
            // excape sequences
            Console.WriteLine("Hello \"Vladyslav\"...\nTab\tTab\tTab");

            Console.ResetColor();

            // read key
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Spacebar)
            {
                Console.Beep();
            }
        }
    }
}