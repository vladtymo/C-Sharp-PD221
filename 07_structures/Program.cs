namespace _07_structures
{
    struct TimeStruct
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public TimeStruct()
        {
            Console.WriteLine("Structure constructor...");
            Minutes = Seconds = Hours = 0;
        }
        public TimeStruct(int h, int m, int s)
        {
            Hours = h;
            Minutes = m;
            Seconds = s;
        }

        public override string ToString()
        {
            return $"{Hours:00}:{Minutes:00}:{Seconds:00}";
        }
    }

    struct TestStruct
    {
        public TimeStruct Time { get; set; }
    }


    class TimeClass
    {
        public TimeStruct Time { get; set; }

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public TimeClass(int h, int m, int s)
        {
            Hours = h;
            Minutes = m;
            Seconds = s;
        }

        public override string ToString()
        {
            return $"{Hours:00}:{Minutes:00}:{Seconds:00}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // --------- using struct
            TimeStruct @struct;                 // allocate memory
            @struct = new TimeStruct(10, 4, 2); // invoke constructor

            Console.WriteLine(@struct);

            // --------- using class
            TimeClass @class;                   // create an empty reference
            @class = new TimeClass(4, 15, 51);  // allocate memory and invoke constructor

            Console.WriteLine("Time in class: " + @class.Time.ToString());

            Console.WriteLine(@class);

            TestStruct test = new TestStruct();
            Console.WriteLine("Time in struct: " + test.Time.ToString());

            TimeStruct[] array = new TimeStruct[10];
            Console.WriteLine(array[0].ToString());
        }
    }
}