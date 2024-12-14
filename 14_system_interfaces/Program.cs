using System.Collections;

namespace _14_system_interfaces
{
    class Player : IComparable<Player>, ICloneable
    {
        public int Number { get; }
        public string Name { get; set; }
        public int Goals { get; private set; }
        public int Games { get; private set; }
        public float Productivity => (float)Games / Goals;

        public Player(int number, string name, int goals = 0, int games = 0)
        {
            Number = number;
            Name = name;
            Goals = goals;
            Games = games;
        }

        public void AddGame(int goals = 0)
        {
            Goals += goals;
            ++Games;
        }

        public override string ToString()
        {
            return $"Player {Number:D2} {Name}... stats: {Games}/{Goals} - {Productivity}";
        }

        public int CompareTo(Player? other)
        {
            /* result value:
             * <0 - this less than other
             * =0 - this is equals to other
             * >0 - this is bigger than other
             */
            
            if (other == null) throw new ArgumentException();
            return other.Productivity.CompareTo(this.Productivity);
        }

        public object Clone()
        {
            // shallow copy - copy value type and references
            Player copy = (Player)this.MemberwiseClone();
        
            // deep copy - copy the values of all reference types
            copy.Name = (string)this.Name.Clone();
            //...
        
            return copy;
        }
    }

    class Team : IEnumerable
    {
        public string Name { get; set; }

        private string[] trainers;
        private Player[] players;

        public IEnumerable<string> Trainers => trainers;

        public Team()
        {
            players = new Player[] 
            {
                new Player(7, "Cristiano Ronaldo", 160, 90),
                new Player(21, "Oleksandr Zinchenko", 130, 77),
                new Player(11, "Zlatan Ibrahimović", 85, 56),
                new Player(10, "Neymar", 110, 81),
            };

            trainers = new string[]
            {
                "Pep Guardiola",
                "Antonio Conte",
                "Andrii Shevchenko",
                "Zinedine Zidane"
            };
        }

        public IEnumerator GetEnumerator()
        {
            return players.GetEnumerator();
        }

        public void Sort()
        {
            // Sort() - requires IComparable interface
            Array.Sort(this.players);
        }

        public void SortByGames()
        {
            Array.Sort(this.players, new SortPlayerByGames());
        }
    }

    class SortPlayerByGames : IComparer<Player>
    {
        public int Compare(Player? x, Player? y)
        {
            return x?.Games.CompareTo(y?.Games) ?? -1;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Team dreamTeam = new Team();
            
            // foreach() - require a realizarion of the GetEnumerator() method
            foreach (Player p in dreamTeam) 
            {
                Console.WriteLine(p);
            }

            // iterate all trainers
            foreach (string t in dreamTeam.Trainers)
            {
                Console.WriteLine("Trainer: " + t);
            }

            Console.WriteLine("--------- Sorted Players by Default ---------");
            dreamTeam.Sort();
            foreach (Player p in dreamTeam) Console.WriteLine(p);

            Console.WriteLine("--------- Sorted Players by Games ---------");
            dreamTeam.SortByGames();
            foreach (Player p in dreamTeam) Console.WriteLine(p);

            // ------ create object prototype
            Console.WriteLine("----------- Cloning Object -----------");
            Player player = new Player(10, "Ronaldinho Gaúcho", 144, 210);

            Player copy = (Player)player.Clone(); // shallow copy

            player.AddGame(3);
            Console.WriteLine(copy);
        }
    }
}