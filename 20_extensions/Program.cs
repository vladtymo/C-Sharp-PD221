namespace _20_extensions
{
    static class ExampleExtensions
    {
        public static int NumberWords(this string data)
        {
            if (string.IsNullOrEmpty(data)) return 0;
            // data = System.Text.RegularExpressions.Regex.Replace(data.Trim(), @"\s+", " ");
            return data.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int NumberSymbol(this string data, char s)
        {
            if (string.IsNullOrEmpty(data)) return 0;

            int c = 0;
            foreach (var item in data)
            {
                if (item == s) ++c;
            }
            return c;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string:");
            string str = Console.ReadLine();

            ExampleExtensions.NumberWords(str);
            ExampleExtensions.NumberSymbol(str, 'f');
            // the same but as an extension method
            str.NumberWords();
            str.NumberSymbol('f');

            Console.WriteLine($"The number of words in the string: {str.NumberWords()}");
            Console.WriteLine($"The number of symbol in the string: {str.NumberSymbol('f')}");
        }
    }
}