using System.Text;

Console.WriteLine("---------- String Builder ----------");

string str = "Hello!\n"; // 
str += "How are you?\n";
str += "I'am fine!";
str += "!";
str += "!";
str += "\n";

Console.WriteLine(str);

StringBuilder buider = new StringBuilder();

Console.WriteLine($"Builder Length: {buider.Length}");
Console.WriteLine($"Builder Capacity: {buider.Capacity}");

buider.Append("Hello");
buider.AppendLine("!!!");
buider.AppendLine("How do you feel?");

Console.WriteLine($"Builder Length: {buider.Length}");
Console.WriteLine($"Builder Capacity: {buider.Capacity}");

string result = buider.ToString();
