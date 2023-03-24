Console.WriteLine("Working with String!");

// class System.String - reference type (nullable)
string? nullStr = null;
Console.WriteLine(nullStr ?? "null string");

Console.WriteLine(nullStr?.ToLower()); // .? - avoid NullReferenceException

// ------------------------- constructors
string str = "Hello, world!";
//String str = new String("Hello, world!");
Console.WriteLine(str);

string line = new string('#', 10);
Console.WriteLine(line);

char symbol = 'Ї'; // 2 bytes (UNICODE)
char[] characters = { 'H', 'e', 'l', 'l', 'o' };

string str2 = new string(characters, 1, 3);
Console.WriteLine(str2);

string result = "Hi! " + str + "..."; // string.Concat()
Console.WriteLine("Result: " + result);

Console.WriteLine("Element at 4 index: " + str[4]); // o
// str[4] = 'a'; // readonly

// ------------------------- methods
if (str.Contains("world"))
    Console.WriteLine("String contains 'world' substring");

if (str.StartsWith('H')) Console.WriteLine("String starts with 'H'");
if (str.EndsWith('P')) Console.WriteLine("String ends with 'P'");

Console.WriteLine($"Index of comma: {str.IndexOf(',')}");

Console.WriteLine("Replaced: " + str.Replace(' ', '-'));
Console.WriteLine("Substrign: " + str.Substring(0, 5));

Console.WriteLine("Upper: " + str.ToUpper());
Console.WriteLine("Lower: " + str.ToLower());

Console.WriteLine("Original: " + str);


Console.Write("Enter your email: ");
string email = Console.ReadLine()!;

// ------- Trim() - remove white-scapes from the sides
// white-space symbols: '\t' '\n' ' '
Console.WriteLine($"Original email: |{email}|");
Console.WriteLine($"Trimmed email: |{email.Trim()}|"); // TrimStart(), TrimEnd()

// ------- split() and join() example
str = "Hi, there! How are you? Super-puper.";

string[] words = str.Split(new[] { ' ', ',', '.', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries);

Console.WriteLine($"Words: {words.Length}");
foreach (var w in words) Console.WriteLine(w);

string joined = string.Join(", ", words);
Console.WriteLine("Joined string: " + joined);

// ------- string validation
Console.Write("Enter your name:");
string name = Console.ReadLine();

// empty string: "" (string.Empty)

if (string.IsNullOrEmpty(name)) 
    Console.WriteLine("Empty name!");

if (string.IsNullOrWhiteSpace(name))
    Console.WriteLine("Empty name or contains only white-space characters!");