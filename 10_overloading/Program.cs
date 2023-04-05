using _10_overloading.Indexer;

namespace _10_overloading
{
    class Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        // Constructors
        public Point3D() : this(0, 0, 0) { }
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"Point: x: {X}, y: {Y}, z: {Z}";
        }

        public static explicit operator Point(Point3D p)
        {
            return new Point(p.X, p.Y);
        }
    }
    class Point
    {
        // Auto-properties
        public int X { get; set; }
        public int Y { get; set; }

        // Constructors
        public Point() : this(0, 0) { }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }


        // Override ToString
        public override string ToString()
        {
            return $"Point: x: {X}, y: {Y}";
        }

        /*
         * ref out - not allow
        public static return_type operator[symbol](parameters)
        {
            // code...
        }
        */

        #region Унарні оператори
        public static Point operator -(Point p)
        {
            //Point newPoint = new Point
            //{
            //    X = p.X * -1,
            //    Y = p.Y * -1
            //};
            return new Point(-p.X, -p.Y);
        }
        public static Point operator ++(Point p)
        {
            ++p.X;
            ++p.Y;
            return p;
        }
        public static Point operator --(Point p)
        {
            --p.X;
            --p.Y;
            return p;
        }
        #endregion

        #region Бінарні оператори
        public static Point operator +(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X + p2.X,
                Y = p1.Y + p2.Y
            };
            return p3;
        }
        public static Point operator -(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X - p2.X,
                Y = p1.Y - p2.Y
            };
            return p3;
        }
        public static Point operator *(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X * p2.X,
                Y = p1.Y * p2.Y
            };
            return p3;
        }
        public static Point operator /(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X / p2.X,
                Y = p1.Y / p2.Y
            };
            return p3;
        }
        #endregion

        #region Оператори відношення
        // Override Equals and GetHashCode
        public override bool Equals(object? obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }
        // recommended to override GetHashCode() also
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }
        // must be defined in pair
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Логічні оператори       
        public static bool operator >(Point p1, Point p2)
        {
            return p1.X + p1.Y > p2.X + p2.Y;
        }
        // must be defined in pair
        public static bool operator <(Point p1, Point p2)
        {
            return p1.X + p1.Y < p2.X + p2.Y;
        }

        public static bool operator >=(Point p1, Point p2)
        {
            return !(p1 < p2);
        }
        // must be defined in pair
        public static bool operator <=(Point p1, Point p2)
        {
            return !(p1 > p2);
        }
        #endregion

        #region true/false operators
        public static bool operator true(Point p)
        {
            return p.X != 0 || p.Y != 0;
        }
        // must be defined in pair
        public static bool operator false(Point p)
        {
            return p.X == 0 && p.Y == 0;
        }
        #endregion

        #region Оператори приведення типу
        public static explicit operator int(Point p)
        {
            return p.X + p.Y;
        }
        public static implicit operator double(Point p)
        {
            return p.X + p.Y;
        }
        public static implicit operator Point3D(Point p)
        {
            return new Point3D(p.X, p.Y, 0);
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            ////////////////// Standart Operators
            int num1 = 5, num2 = 12;
            int summ = num1 + num2; // 17

            string str1 = "start", str2 = "end";
            string result = str1 + "-" + str2; // start-end

            ////////////////// Unary Operators
            Point p1 = new Point(3, 2);
            Point p2 = new Point(5, 9);

            Console.WriteLine("Point 1: " + p1);
            Console.WriteLine("Point 1(-p): " + -p1);
            Console.ReadKey();

            Console.WriteLine("Point 1: " + p1);
            Console.WriteLine("Point 1(++p): " + ++p1);
            Console.WriteLine("Point 1(p--): " + p1--);

            // operator chain: p1++ + p2-- + -p1;

            ////////////////////// Binary Operators
            Point p3 = p1 + p2;

            Console.WriteLine("Point 1: " + p1);
            Console.WriteLine("Point 2: " + p2);
            Console.WriteLine("Point 3(p1 + p2): " + p3);
            Console.ReadKey();

            /////////////////////////////// Equals
            p1 = new Point(2, 5);
            p2 = new Point(2, 6);
            p1 = p2; // the same reference

            Console.WriteLine("Hash p1: " + p1.GetHashCode());
            Console.WriteLine("Hash p2: " + p2.GetHashCode());

            // Reference Equals
            if (object.ReferenceEquals(p1, p2))
                Console.WriteLine("Reference Equals");
            else
                Console.WriteLine("Reference Not Equals");

            p1 = new Point(2, 5);
            //p2 = null; // would be an error

            // Equals
            if (p1.Equals(p2))
                Console.WriteLine("Equals");
            else
                Console.WriteLine("Not Equals");

            // Equals
            if (p1 == p2)
                Console.WriteLine("==");
            else
                Console.WriteLine("!=");

            /////////////////////////////// Logic Operators
            if (p1 > p2) Console.WriteLine("p1 is bigger then p2");
            else Console.WriteLine("p1 not bigger then p2");

            ////////////////////////// True/False Operators
            p1 = new Point(0, 1);
            // p1 = null; // would be an error

            if (p1)
                Console.WriteLine("TRUE");
            else
                Console.WriteLine("FALSE");

            p1++;

            if (p1)
                Console.WriteLine("TRUE");
            else
                Console.WriteLine("FALSE");

            //////////////////////////// Conversion Operators
            int a = 5;
            double d = 6.7;

            // int to double
            d = a;            // implicit
            a = (int)d;       // explicit

            p1 = new Point(1, 1);

            a = (int)p1;      // explicit
            d = p1;           // implicit
            Point3D p3d = p1; // implicit
            p1 = (Point)p3d;  // explicit      

            Console.WriteLine(a);
            Console.WriteLine(d);
            Console.WriteLine(p3d);
            Console.WriteLine(p1.ToString());

            ///////////////////////// Indexer Operator
            Shop shop = new Shop(3);

            ///////// without indexer
            //shop.SetLaptop(0, new Laptop() { Vendor = "Samsung", Price = 5200 });
            //Laptop laptop = shop.GetLaptop(1);
            //Console.WriteLine(laptop);

            ///////// with indexer
            shop[0] = new Laptop() { Vendor = "Samsung", Price = 5200 };
            var laptop = shop[0];
            Console.WriteLine(laptop);

            shop[0] = new Laptop
            {
                Vendor = "Samsung",
                Price = 5200
            };
            shop[1] = new Laptop
            {
                Vendor = "Asus",
                Price = 4700
            };
            shop[2] = new Laptop
            {
                Vendor = "LG",
                Price = 4300
            };
            try
            {
                for (int i = 0; i < shop.Length + 1; i++)
                {
                    Console.WriteLine(shop[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // multi-dimentional array
            Table multArray = new Table(2, 3);

            for (int i = 0; i < multArray.Rows; i++)
            {
                for (int j = 0; j < multArray.Cols; j++)
                {
                    multArray[i, j] = i + j;
                    Console.Write($"{multArray[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}