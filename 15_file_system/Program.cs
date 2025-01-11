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
            
            var directories = Directory.GetDirectories(desktopPath, "*Lesson*");
            
            // searchPattern: ? - one symbol, * - many symbols
            foreach (var dir in directories)
            {
                Console.WriteLine(dir);
            }

            DirectoryInfo desktop = new DirectoryInfo(desktopPath);
            
            foreach (var file in desktop.GetFiles("*.jpg"/*, SearchOption.AllDirectories*/))
            {
                Console.WriteLine($"File: {file.Name} {file.Length / 1024}KB created at {file.CreationTime}");
            }
            
            FileInfo image = new FileInfo("cup.jpg");
            Console.WriteLine(image.FullName);
            
            // Directory methods:

            //Path.GetExtension(path);
            //Path.GetFileName(path);
            //Path.Combine("Users", "Vlad", "blabla.txt");
           
            var newFolder = Directory.CreateDirectory(Path.Combine(desktopPath, "cloudy saturday"));
            
            string filePath = Path.Combine(newFolder.FullName, "greeting.txt");
            //File.Create(filePath);
            File.WriteAllText(filePath, "Hello C#...");
            
            string content = File.ReadAllText(filePath);
            Console.WriteLine("File content:" + content);
            
            FileInfo greetingFile = new FileInfo(filePath);
            if (!greetingFile.Exists)
                 greetingFile.Create();
            
            greetingFile.CopyTo(Path.Combine(desktopPath, "greeting_copy.txt"), true);
            //greetingFile.MoveTo();
            
            greetingFile.Delete(); 
            newFolder.Delete(); // delete if folder is empty
        }
    }
}