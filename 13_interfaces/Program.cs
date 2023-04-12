namespace _13_interfaces
{
    // interface - defines public members of the object
    // interface can contains properties, methods, events, indexer
    // naming: I{Name}
    interface IRunnable : IMovable // interface inheritance
    {
        // public by default
        int Speed { get; set; }
        void Run();
    }
    interface IMovable
    {
        // default interface member realization
        void Move(double distance)
        {
            Console.WriteLine($"I went {distance}m...");
        }
    }
    interface IFlyable
    {
        float FlyingHeight { get; } // {getter} is required but {setter} is optional
        void Fly();
    }
    interface ISwimable
    {
        float SwimmingDepth { get; }
        void Swim();
    }
    interface ISoundMaker
    {
        void MakeSound();
    }

    abstract class Animal
    {
        public string Environment { get; set; }
        public string Type { get; set; }

        public Animal(string env, string type)
        {
            Environment = env;
            Type = type;
        }

        public void WhoAmI()
        {
            Console.WriteLine(new String('-', 40));
            Console.WriteLine(this.ToString());
        }
        public override string ToString() => $"I am an {Type} animal that is living in {Environment}.";
    }
    class Tiger : Animal, IRunnable, ISoundMaker //... can implement many interfaces
    {
        public int Speed { get; set; }

        public Tiger() : base("Forests and Savannas", "Largest Cat") { }

        public void Run()
        {
            Console.WriteLine($"Tiger is running with {Speed} km/h...");
        }
        public void MakeSound()
        {
            Console.WriteLine($"Garrr garr garrr.....");
        }
    }
    class Parrot : Animal, IFlyable, ISoundMaker
    {
        public float FlyingHeight { get; set; }

        public Parrot() : base("Warm areas", "Birds") { }

        public void Fly()
        {
            Console.WriteLine($"Parrot is flying for the {FlyingHeight}m...");
        }
        public void MakeSound()
        {
            Console.WriteLine($"Gosha is a good parrot:)...");
        }
    }
    class Shark : Animal, ISwimable
    {
        public float SwimmingDepth { get; set; }

        public Shark() : base("Oceans and Seas", "Fish") { }

        public void Swim()
        {
            Console.WriteLine($"Shark is swimming up to the depth of {SwimmingDepth}m...");
        }
    }
    class Turtle : Animal, ISwimable
    {
        public float SwimmingDepth { get; set; }
        public int Speed { get; set; }

        public Turtle() : base("Rivers, Seas and Oceans", "Reptiles") { }

        public void Swim()
        {
            Console.WriteLine($"Turtle is swimming up to the depth of {SwimmingDepth}m...");
        }
        // it can crawl but cannot run
        public void Crawl()
        {
            Console.WriteLine($"Turtle is crawling for the {Speed}km/s...");
        }
    }
    class Chicken : Animal, IRunnable, IFlyable, ISoundMaker
    {
        public float FlyingHeight { get; set; }
        public int Speed { get; set; }

        public Chicken() : base("Farm areas", "Birds") { }

        public void Fly()
        {
            Console.WriteLine($"Parrot is flying for the {FlyingHeight}m...");
        }
        public void Run()
        {
            Console.WriteLine($"Chicken is running with {Speed} km/h...");
        }
        public void MakeSound()
        {
            Console.WriteLine($"Kukurikuuuuu kukuku...");
        }
    }


    internal class Program
    {
        public static void Introduce(ISoundMaker animal)
        {
            Console.WriteLine("----------- Introduce animal -----------");
            Console.WriteLine(animal);
            animal.MakeSound();
        }

        static void Main(string[] args)
        {
            Shark shark = new Shark() { SwimmingDepth = 950 };
            Turtle turtle = new Turtle() { Speed = 4, SwimmingDepth = 290 };
            Parrot parrot = new Parrot() { FlyingHeight = 8200 };
            Chicken chicken = new Chicken() { Speed = 20, FlyingHeight = 14 };
            Tiger tiger = new Tiger() { Speed = 60 };

            shark.WhoAmI();
            shark.Swim();

            chicken.FlyingHeight = 12;
            chicken.WhoAmI();
            chicken.Fly();
            chicken.Run();

            // interface references
            IRunnable runner = chicken;

            runner.Speed += 1;
            runner.Run();
            runner.Move(35);

            Introduce(tiger);
            Introduce(chicken);
            Introduce(parrot);
            //Introduce(shark); // interface ISoundMaker is not implemented

            ISwimable[] fish =
            {
                shark,
                turtle,
                new Shark() { SwimmingDepth = 6700 }
            };

            foreach (var i in fish)
            {
                Console.WriteLine($"Swimming depth: {i.SwimmingDepth}m");
                i.Swim();
            }
        }
    }
}