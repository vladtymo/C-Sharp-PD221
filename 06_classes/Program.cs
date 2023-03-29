using _06_classes.Partials;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace _06_classes
{
    // Access Specificators
    /*
     * private (default for field)
     * protected internal
     * protected 
     * internal - access from assembly (default for classes)
     * public
     */

    public class Door //: Object - interite System.Object by default
    {
        // ============ fields ============
        // private by default
        private string color;
        private string material;
        private int width;
        private int height;

        // const (static implicit) - can be initialized only
        public const string type = "Furniture";

        // readonly - can initialize or set in constructors only
        private readonly DateTime creationDate;

        // static - has a signle instance for the all objects
        private static int identifier; 

        // ============ properties ============
        // ------------ full property 
        // snippet: propfull
        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                // value - input value parameter
                this.height = value < 0 ? 0 : value;
            }
        }

        // we can do the same with the auto-properties
        // ------------ auto property - auto create a file with simple getter and setter logic
        // snippet: prop
        public float Thickness { get; set; } // private set

        // init-only property
        public string Brand { get; init; }           

        // readonly property - has getter only
        public double Area
        {
            get
            {
                return (double)height * width;
            }
        }

        // static property
        public static int ID { get { return identifier; } }

        // ============ constructors ============
        // static cnstructors - invokes automatically, use for initialize static members
        static Door() 
        {
            Random rand = new Random();
            identifier = rand.Next(10);
        }

        public Door() { }
        public Door(string color, string material)
            : this(color, material, 100, 210)
        {
        }
        public Door(string color, string material, short width, short height)
        {
            if (string.IsNullOrWhiteSpace(color))
                this.color = "no data";
            else
                this.color = color;

            this.material = material;

            //this.width = width < 0 ? 0 : width;
            SetWidth(width);
            //this.height = height < 0 ? 0 : height;
            Height = height;

            // we can not change this value out of the constructor
            creationDate = DateTime.Now;
        }

        // ============ methods ============
        // getter & setter
        public void SetWidth(int value)
        {
            this.width = value < 0 ? 0 : value;
        }
        public int GetWidth()
        {
            return this.width;
        }

        public void ShowCreationDate()
        {
            Console.WriteLine($"Door was created in {creationDate}");
        }

        public void Show()
        {
            Console.WriteLine($"Door info: {color}, {material}, size: {width}x{height}cm");
        }
        public override string ToString()
        {
            return $"This is {color} door made of {material}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // get static members
            Console.WriteLine("ID: " + Door.ID);
            Console.WriteLine("Type: " + Door.type);

            Door myDoor = new Door("Brown", "Wood");

            myDoor.Show();
            Console.WriteLine("To string: " + myDoor.ToString());
            myDoor.ShowCreationDate();

            // use methods
            myDoor.SetWidth(87);
            Console.WriteLine($"Width: {myDoor.GetWidth()} cm");
            // use property
            myDoor.Height = 125;
            Console.WriteLine($"Height: {myDoor.Height} cm");

            //myDoor.Material = "Glass"; // inaccessible

            Console.WriteLine($"Area of the door: {myDoor.Area} cm^2");

            // use object initializer
            Door yourDoor = new Door("White", "Metal")
            {
                Thickness = 7.5F,
                Height = 235,
                Brand = "Blest" 
            };

            //yourDoor.Brand = "Blabla"; // init-only
        }
    }
}