using System;
using System.Collections.Generic;
using System.Threading;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration; // seconds
    private static readonly Random _rng = new Random();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    // Ask user for duration and prepare
    protected void Setup()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = GetDurationFromUser();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    private int GetDurationFromUser()
    {
        int seconds;
        while (true)
        {
            Console.Write("Enter the duration in seconds: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out seconds) && seconds > 0)
                return seconds;
            Console.WriteLine("Please enter a positive integer value for seconds.");
        }
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        Console.WriteLine();
        Thread.Sleep(1000);
    }

    // rotates for given seconds
    protected void ShowSpinner(int seconds)
    {
        char[] spinner = new char[] { '|', '/', '-', '\\' };
        int totalSteps = seconds * 4; // 250ms per step
        for (int i = 0; i < totalSteps; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    // Countdown 
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public virtual void Run()
    {
    
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Setup();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountDown(4); // inhale for 4 secs
            Console.WriteLine();

            if (DateTime.Now >= endTime) break;

            Console.Write("Breathe out... ");
            ShowCountDown(6); // exhale for 6 secs
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() : base("Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    private string GetRandomPrompt()
    {
        return _prompts[_randomIndex(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        return _questions[_randomIndex(_questions.Count)];
    }

    private int _randomIndex(int max)
    {
        return new Random().Next(0, max);
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Setup();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you're ready, reflect on the following questions.");
        Thread.Sleep(1000);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string q = GetRandomQuestion();
            Console.WriteLine();
            Console.WriteLine(q);
            ShowSpinner(8); // pause with spinner for 8 seconds between questions
        }

        DisplayEndingMessage();
    }
}

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    private string GetRandomPrompt()
    {
        return _prompts[new Random().Next(0, _prompts.Count)];
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Setup();

        Console.WriteLine();
        string prompt = GetRandomPrompt();
        Console.WriteLine($"List as many responses as you can to this prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("You will have a short moment to think...");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items. Press Enter after each item.");

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            // If there's remaining small time, give a tightened prompt
            Console.Write("> ");
            // Use ReadLine with time check — if user is typing but time elapses, we still accept what they typed after Enter.
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
            {
                items.Add(entry.Trim());
            }
            // loop continues until time is up
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} item(s).");
        Console.WriteLine();
        DisplayEndingMessage();
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
            Console.Write("Choose an option (1-4): ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    Thread.Sleep(500);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();

            Console.WriteLine("Press Enter to return to main menu...");
            Console.ReadLine();
        }
    }
}
