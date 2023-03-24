using System;

Console.WriteLine("Working with Array!");

// class Array - contains all properties and methods
int[] array = new int[] { 2, 6, 8, 23, -4, 0, 44, 23, 4, -1 };

Console.WriteLine($"Array length: {array.Length}");

// -------------- iterate array items --------------
//for (int i = 0; i < array.Length; i++)
//{
//    Console.WriteLine(array[i]);
//}

// automaticaly iterate all the array items
// var - inferred type
foreach (var num in array)
{
    Console.Write(num + ", ");
}
Console.WriteLine();

// -------------- array methods --------------
array[2] = 7;                //array.SetValue(7, 2); 
Console.WriteLine(array[2]); //array.GetValue(2);

Array.Resize(ref array, 13);
Array.Sort(array);
Array.Reverse(array);
Array.Fill(array, 9, 1, 3);
Console.WriteLine($"First Index of 23: {Array.IndexOf(array, 23)}"); // if not found: -1
Console.WriteLine($"Last Index of 23: {Array.LastIndexOf(array, 23)}"); // if not found: -1

int[] copy = new int[10];
Array.Copy(array, copy, 10);
Console.WriteLine($"Copy array length: {copy.Length}");

//Array.Clear(array);

foreach (var num in array) Console.Write(num + ", ");
Console.WriteLine();

// -------------- multidimention array --------------
int[,] matrix = new int[3, 4]
                {
                    { 5, 6, 2, 4 },
                    { 1, 4, 0, 9 },
                    { 5, 2, 5, 3 }
                };

Console.WriteLine($"Matrix length: {matrix.Length}"); // 12

for (int y = 0; y < matrix.GetLength(0); y++)
{
    Console.Write("[ ");
    for (int x = 0; x < matrix.GetLength(1); x++)
    {
        Console.Write(matrix[y, x] + " ");
    }
    Console.WriteLine("]");
}
