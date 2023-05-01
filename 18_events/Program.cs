namespace _18_events
{
    // --------------- Events ---------------

    class Human
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Addresss { get; set; }
        public int Age => DateTime.Now.Year - Birthdate.Year; // readonly property

        // event - incapsulate delegate and give -= += interface only
        public event Action<string, int> CelebrateEvent;
        public event Action Anniversary;

        // human manage the celebrate event invokation time
        public void Celebrate()
        {
            Console.WriteLine($"{Name} is celebrating his birthday. He is {Age} years old!");
            Console.WriteLine(new string('-', 30));

            // notify all friends
            CelebrateEvent?.Invoke(this.Name, this.Age);
            // notify about anniversary
            if (Age % 10 == 0)
                Anniversary?.Invoke();
        }

        public override string ToString()
        {
            return $"My name is {Name}, I'm living in {Addresss}";
        }
    }

    class Friend
    {
        public string Name { get; set; }

        public void Congratulate(string name, int age)
        {
            Console.WriteLine($"Congratulations... Happy Birthday dear {name}!");
            if (age < 18)
                Console.WriteLine($"{Name} is gifing you a pack of milk!");
            else
                Console.WriteLine($"{Name} is gifting you a bottle of red wine!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Human human = new()
            {
                Name = "Donald",
                Birthdate = new DateTime(1983, 3, 16),
                Addresss = "San-Francisko, USA"
            };

            // subscribe to anniversary event
            human.Anniversary += Human_Anniversary; ;
            human.Anniversary += () => Console.WriteLine("Gift you a sport car!");

            Friend bob = new Friend() { Name = "Bob" };
            Friend john = new Friend() { Name = "John" };
            Friend andres = new Friend() { Name = "Andres" };

            // subscribe
            human.CelebrateEvent += bob.Congratulate;
            human.CelebrateEvent += john.Congratulate;
            human.CelebrateEvent += andres.Congratulate;
            human.CelebrateEvent += (name, age) => Console.WriteLine("Play Rock music for you!");

            // unsubscribe
            human.CelebrateEvent -= bob.Congratulate;

            // cannot access to event properties
            //human.CelebrateEvent = null;

            human.Celebrate();
        }

        private static void Human_Anniversary()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Happy anniversary!");
            Console.ResetColor();
        }
    }
}
