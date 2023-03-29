using _06_classes;

namespace _08_ref_out_params
{
    class Program
    {
        // params - set many parameters
        // * - use only as last param
        static void MethodWithParams(string name, params int[] marks)
        {
            Console.WriteLine("------- " + name + " ---------");
            foreach (var m in marks)
            {
                Console.WriteLine(m);
            }
        }

        // ref - take params by reference
        static void Modify(ref int num, ref string str, ref Door door)
        {
            num += 1;
            str += "!"; // return a new string reference

            door.Height++;
            door.Height += 4;
        }

        // out - output param for return
        // * - method must initialize all out parameters
        static void GetCurrentTime(out int hour, out int minute, out int second)
        {
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;
        }

        static void Main(string[] args)
        {
            //////////////// ref
            int num = 10;
            string str = "Hello academy";
            Door door = new Door("Black", "Wood", 100, 200);

            ////// ref - put params by reference
            Modify(ref num, ref str, ref door);

            Console.WriteLine("Num: " + num);
            Console.WriteLine("Str: " + str);
            Console.WriteLine("Door height: " + door.Height);

            ////////////////// out
            // can use unitialized variables
            //int h, m, s;
            //GetCurrentTime(out h, out m, out s);

            // inline variable declaration
            GetCurrentTime(out int h, out int m, out int s);

            Console.WriteLine($"{h}:{m}:{s}");

            ///////////////// params
            MethodWithParams("Bob", new int[] { 12, 8, 9, 7 });
            MethodWithParams("Bob", 12, 8, 9, 7, 10);
        }
    }
}