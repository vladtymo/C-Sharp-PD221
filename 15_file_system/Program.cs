using System.IO;

namespace _15_file_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // for working with file system we can use:
            // File / Directory         - represent static methods
            // FileInfo / DirectoryInfo - represent an instance methods

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine("Desktop: " + desktopPath);

            // searchPattern: ? - one symbol, * - many symbols
            foreach (var dir in Directory.GetDirectories(desktopPath, "*pd?21*"))
            {
                Console.WriteLine(dir);
            }

            DirectoryInfo desktop = new DirectoryInfo(desktopPath);

            foreach (var file in desktop.GetFiles("*.txt"/*, SearchOption.AllDirectories*/))
            {
                Console.WriteLine($"File: {file.Name} {file.Length / 1024}KB created at {file.CreationTime}");
            }

            // Directory methods:

            //Path.GetExtension(path);
            //Path.GetFileName(path);
            //Path.Combine("Users", "Vlad", "blabla.txt");

            var newFolder = Directory.CreateDirectory(Path.Combine(desktopPath, "PV221_test_folder"));

            string filePath = Path.Combine(newFolder.FullName, "greeting.txt");
            //File.Create(filePath);
            File.WriteAllText(filePath, "Hello C#...");

            string content = File.ReadAllText(filePath);

            FileInfo greetingFile = new FileInfo(filePath);
            if (!greetingFile.Exists)
                greetingFile.Create();

            greetingFile.CopyTo(Path.Combine(desktopPath, "greeting_copy.txt"), true);
            //file.MoveTo();

            greetingFile.Delete();
            newFolder.Delete(); // delete if folder is empty
        }
    }
}