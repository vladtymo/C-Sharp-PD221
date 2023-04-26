using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

// Attribute - add metadata to member (property, class, method, interface...)
[Serializable]
public class Person
{
    [NonSerialized]
    private static int initialId = 1000;

    private string password;

    public int Id { get; set; }
    public string Name { get; set; }

    public DateTime Birthdate { get; set; }
    public string Address { get; set; }
    public string[] Children { get; set; } = { "Bob", "Vika", "Luda" };

    public Person() { }
    public Person(string name, DateTime birth, string? address, string? password)
    {
        this.Id = initialId++;
        this.Name = name;
        this.Birthdate = birth;
        this.Address = address ?? "no address";
        this.password = password ?? "123";
    }

    public override string ToString()
    {
        return $"Person [{Id}]: {Name} born at {Birthdate.ToShortDateString()} living address: {Address}. Password: {password}";
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // -------------------------------------------
        // -------------- serialization --------------
        // -------------------------------------------

        // ================= JSON =================
        // serialize public members only

        Person person = new("John", new DateTime(2010, 4, 1), "New-York, USA", "Qwerty");
        List<Person> people = new()
        {
            person,
            new("Olga", new DateTime(1998, 2, 24), "San-Francisco, USA", "Test1122")
        };

        // --------------- .Serialize(object) - convert object to JSON format
        string json = JsonSerializer.Serialize(people);

        // save to file
        File.WriteAllText("data.json", json);

        // read json from file
        string jsonResult = File.ReadAllText("data.json");

        // --------------- .Deserealize(json) - create object instance from JSON data
        var peopleResult = JsonSerializer.Deserialize<List<Person>>(jsonResult);

        foreach (var p in peopleResult)
        {
            Console.WriteLine(p);
        }

        // ================= XML =================
        // serialize public members only
        XmlSerializer serializer = new(typeof(List<Person>));

        using (Stream fs = File.Create("data.xml"))
        {
            // fs.Write() - write content to file
            // fs.Read()  - read content from file

            serializer.Serialize(fs, people);
        
        } // close stream

        // ================= Binary =================
        // serialize all members
        BinaryFormatter formatter = new BinaryFormatter();

        using (Stream fs = File.Create("data.bin"))
        {
            formatter.Serialize(fs, people);
        }

        List<Person> binaryResult = null;
        using (Stream fs = File.OpenRead("data.bin"))
        {
            binaryResult = (List<Person>)formatter.Deserialize(fs);
        }

        foreach (var p in binaryResult)
        {
            Console.WriteLine(p);
        }
    }
}