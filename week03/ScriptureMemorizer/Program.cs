using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, 
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        bool allHidden = false;

        while (!allHidden)
        {
            Console.Clear();
            
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to hide words, or type 'quit' to exit.");
            
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);

            allHidden = scripture.IsCompletelyHidden();
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        Console.ReadLine();
    }
}

