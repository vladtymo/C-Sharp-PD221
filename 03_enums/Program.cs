namespace _03_enums
{
    internal class Program
    {
        enum Menu { Open, Save, Close, SaveAs }

        enum Direction : short
        { 
            North = 1, South, East, West, aregaer, aergarrr
        }

        static void Main(string[] args)
        {
            // ---------- working with enum ----------
            // directions: North, South, East, West

            Direction planA = Direction.South;
            Direction planB = Direction.East;

            Console.WriteLine($"Plan A: go {planA} - {(short)planA}");
            Console.WriteLine($"Plan B: go {planB} - {(short)planB}");

            // ---------- get enum values
            string[] names = Enum.GetNames(typeof(Direction));
            short[] values = (short[])Enum.GetValues(typeof(Direction));

            Console.WriteLine("Choose your direction:");

            foreach (Direction value in values)
                Console.WriteLine($"{(short)value} - {value}");

            string? input = Console.ReadLine();

            // ---------- enum parsing
            Direction myDir = (Direction)Enum.Parse(typeof(Direction), input);

            // ---------- check if value is defined
            if (!Enum.IsDefined(typeof(Direction), myDir))
            {
                Console.WriteLine("Your value is not defined!");
            }

            Console.Write("The opposite direction is ... ");

            switch (myDir)
            {
                case Direction.North: Console.WriteLine("south"); break;
                case Direction.South: Console.WriteLine("north"); break;
                case Direction.East: Console.WriteLine("west"); break;
                case Direction.West: Console.WriteLine("east"); break;
            }
        }
    }
}