using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<double> numbers = new List<double>();
        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            double value;
            if (!double.TryParse(input, out value))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            if (value == 0)
            {
                break; 
            }

            numbers.Add(value);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        double sum = 0;
        foreach (double n in numbers)
        {
            sum += n;
        }

        double average = sum / numbers.Count;

        double max = numbers[0];
        foreach (double n in numbers)
        {
            if (n > max) max = n;
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
    }
