using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> ages = new Dictionary<string, int>();

        ages["Alice"] = 25;
        ages["Bob"] = 30;
        ages.Add("Charlie", 35);

        Console.WriteLine($"Alice's age: {ages["Alice"]}");

        if (ages.ContainsKey("Bob"))
        {
            Console.WriteLine("Bob is in the dictionary.");
        }

        foreach (var kvp in ages)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        ages.Remove("Charlie");


        Console.WriteLine($"Total entries: {ages.Count}");
    }
}