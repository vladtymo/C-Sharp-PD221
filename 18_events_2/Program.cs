using System.Threading.Channels;

class Human
{
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    public string Addresss { get; set; }
    public int Age => DateTime.Now.Year - Birthdate.Year; // readonly property

    public event Action<string, int> CelebrateEvent;
    
    public void Celebrate()
    {
        Console.WriteLine($"{Name} is celebrating his birthday. He is {Age} years old!");
        Console.WriteLine(new string('-', 30));
        
        // повідомляємо всії підписників про святкування
        CelebrateEvent?.Invoke(Name, Age);
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
            Console.WriteLine($"{Name} is presenting you a pack of milk!");
        else
            Console.WriteLine($"{Name} is presenting you a bottle of red wine!");
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Human donald = new()
        {
            Name = "Donald",
            Birthdate = new DateTime(1983, 3, 16),
            Addresss = "San-Francisko, USA"
        };

        Console.WriteLine(donald);
        
        donald.Celebrate();
        
        Friend bob = new() { Name = "Bob" };
        Friend baiden = new() { Name = "Baiden" };
        Friend makron = new() { Name = "Makron" };

        donald.CelebrateEvent += baiden.Congratulate;
        donald.CelebrateEvent += makron.Congratulate;
        donald.CelebrateEvent += (name, age) => Console.WriteLine("Uraaaaaa!");

        // donald.CelebrateEvent = null;
        // donald.CelebrateEvent.Invoke("Huck", 777);
        
        donald.Celebrate();
    }
}