using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        string magicInput = Console.ReadLine();
        int magic;
        if (!int.TryParse(magicInput, out magic))
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        Console.Write("What is your guess? ");
        string guessInput = Console.ReadLine();
        int guess;
        if (!int.TryParse(guessInput, out guess))
        {
            Console.WriteLine("Invalid guess.");
            return;
        }

        if (guess < magic)
            Console.WriteLine("Higher");
        else if (guess > magic)
            Console.WriteLine("Lower");
        else
            Console.WriteLine("You guessed it!"); 
        
    }
    }
