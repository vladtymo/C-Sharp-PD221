namespace _11_inheritance
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
        public int Age => DateTime.Now.Year - Birthdate.Year; // readonly property
      
        public virtual void Introduce()
        {
            Console.WriteLine($"I am a Person. {ToString()}");
        }

        // polymorphism using keywords {virtual} and {override}
        public virtual void DoMyJob()
        {
            Console.WriteLine("I am living!");
        }
        public override string ToString()
        {
            return $"My name is {FirstName} {LastName}. I'am {Age} years old.";
        }
    }

    // inheritance: DerivedClass : ParentClass, Interface1, Interface2...
    // C# does not support multiple inheritance
    class Citizen : Person
    {
        protected long IdentityNumber { get; }
        public string Address { get; set; }
        public string Country { get; set; }

        public Citizen(long idNumber)
        {
            IdentityNumber = idNumber;
        }

        // new - explicit hides the inherited member
        public new void Introduce()
        {
            Console.WriteLine($"I'm a citizen of {Country}");
        }

        // override - override the inherited member
        public override void DoMyJob()
        {
            Console.WriteLine($"I am livin in {Country}, {Address}!");
        }
    }

    // {sealed class} - can not has child classes
    /*sealed*/ class Employee : Citizen
    {
        public decimal Salary { get; set; }
        public string Position { get; set; }

        // {base} - reference to the parent instance
        public Employee(long idNumber) : base(idNumber)
        { }

        // {sealed override} - can not the overried in child classes
        public /*sealed*/ override void DoMyJob()
        {
            base.DoMyJob();
            Console.WriteLine($"I am working on a {Position} position!");
        }

        public void PayTaxes()
        {
            Console.WriteLine($"I am paying tax with ID code: {IdentityNumber}");
        }
    }

    // can not derive from a sealed class
    class Administrator : Employee // - error
    {
        public Administrator(long idNumber) : base(idNumber) { }
        // can not override sealed methods
        public override void DoMyJob() { } // - error
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                FirstName = "John",
                LastName = "Maa",
                Birthdate = new DateOnly(1998, 1, 4)
            };

            person.Introduce();
            //Console.WriteLine(person);

            Citizen citizen = new Citizen(44968383323)
            {
                FirstName = "Igor",
                LastName = "Plushka",
                Birthdate = new DateOnly(2005, 4, 3),
                Country = "Ukraine",
                Address = "Garna 5, Rivne"
            };

            citizen.Introduce();
            //Console.WriteLine(citizen);

            Person baseClass = citizen;

            baseClass.Introduce();
            baseClass.DoMyJob();

            Employee employee = new Employee(34509273455)
            {
                FirstName = "Olga",
                LastName = "Rishniak",
                Birthdate = new DateOnly(1994, 10, 10),
                Country = "Spain",
                Address = "Amigosna 3, Madrid",
                Position = "Marketing",
                Salary = 4500
            };

            employee.Introduce();
            employee.DoMyJob();
            employee.PayTaxes();
        }
    }
}