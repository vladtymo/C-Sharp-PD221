namespace _17_delegates
{
    // Delegate - reference to a method
    // create delegate: delegate return_type Name(parameters);
    delegate double Operation(double a, double b);

    delegate bool CheckValue(int value);

    internal class Program
    {
        static void Main(string[] args)
        {
            var data = Div(15, 3);
            Console.WriteLine($"Result: {data}");

            // create delegate
            Operation operation = Summ; //new Operation(Summ);
            Operation[] operations = { Mult, Div, Sub, Summ };
            
            // invoke delegate methods
            operation?.Invoke(1, 5);
            
            // change method reference
            operation = Div; 
            
            if (operation != null)
                operation(30, 5);

            // ---------------- multicast delegate ----------------
            Console.WriteLine("-------------- Multicast --------------");
            // add new reference
            operation += Summ;
            operation += Sub;
            // remove reference
            // operation -= Div;
            // operation -= Mult;

            double? result = operation?.Invoke(10, 2);
            Console.WriteLine($"Invoke Result: {result}");

            // ----------------- Filter -----------------
            Console.WriteLine("-------------- Example --------------");
            int[] numbers = { 4, 6, 1, -3, 14, 19, 99, 124, 3, 21, 49, -54, 4, 51, 0 };

            Filter(numbers, IsEven);
            Filter(numbers, IsOneDigit);
            // anonymous delegate
            Filter(numbers, delegate (int value) { return value < 0; });
            // lambda expression
            Filter(numbers, (n) => n % 7 == 0);
            Filter(numbers, (n) => n >= 10 && n <= 20);

            // ----------------- System Delegates -----------------
            // Action - does not return a value (void)
            Action action; // void Name()
            Action<float, float> op; // void Name(float, float);

            Action<string> greeting = (msg) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Greeting message: " + msg);
                Console.ResetColor();
            };

            greeting.Invoke("Hello Delegates!");

            // Func - must return a value
            Func<double, double, double> calculate = Mult; // new(operation);
            calculate.Invoke(4, 7);

            // Predicate - take only one parameter and return boolean value
            Predicate<int> check = IsEven;
        }

        static void Filter(int[] array, CheckValue check)
        {
            Console.Write("Filtered items: ");
            foreach (var item in array)
            {
                if (check(item))
                    Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        // filter methods
        static bool IsEven(int value) { return value % 2 == 0; }
        static bool IsOneDigit(int value) { return value > -10 && value < 10; }

        // ariphmetic operation methods
        static double Summ(double a, double b)
        {
            Console.WriteLine($"Summ: {a} + {b} = {a + b}");
            return a + b;
        }
        static double Sub(double a, double b)
        {
            Console.WriteLine($"Substract: {a} - {b} = {a - b}");
            return a - b;
        }
        static double Mult(double a, double b)
        {
            Console.WriteLine($"Multiple: {a} * {b} = {a * b}");
            return a / b;
        }
        static double Div(double a, double b)
        {
            Console.WriteLine($"Division: {a} / {b} = {a / b}");
            return a / b;
        }
    }
}