using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest - Menu");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goal names");
            Console.WriteLine("3. List goal details");
            Console.WriteLine("4. Record an event");
            Console.WriteLine("5. Display score");
            Console.WriteLine("6. Save goals");
            Console.WriteLine("7. Load goals");
            Console.WriteLine("8. Quit");
            Console.Write("Choose an option (1-8): ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalNames(); break;
                case "3": ListGoalDetails(); break;
                case "4": RecordEvent(); break;
                case "5": DisplayPlayerInfo(); break;
                case "6": SaveGoals(); break;
                case "7": LoadGoals(); break;
                case "8": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your current score: {_score}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter short name: ");
        string name = Console.ReadLine();

        Console.Write("Enter description: ");
        string desc = Console.ReadLine();

        int points = ReadInt("Enter the points: ");

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points, false));
                Console.WriteLine("Simple goal created.");
                break;

            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                Console.WriteLine("Eternal goal created.");
                break;

            case "3":
                int target = ReadInt("Enter target total completions: ");
                int bonus = ReadInt("Enter bonus points: ");
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                Console.WriteLine("Checklist goal created.");
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        ListGoalDetails();
        int index = ReadInt("Select a goal to record: ") - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal index.");
            return;
        }

        int points = _goals[index].RecordEvent();
        _score += points;

        Console.WriteLine($"Points awarded: {points}");
        Console.WriteLine($"New total score: {_score}");
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score|{_score}");

            foreach (Goal g in _goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = 0;

        foreach (string line in lines)
        {
            if (line.StartsWith("Score|"))
            {
                string[] parts = line.Split("|");
                _score = int.Parse(parts[1]);
            }
            else
            {
                string[] split = line.Split("|");
                string type = split[0];
                string data = split[1];
                string[] parts = data.Split(",");

                Goal g = null;

                if (type == "SimpleGoal")
                {
                    g = new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
                }
                else if (type == "EternalGoal")
                {
                    g = new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
                }
                else if (type == "ChecklistGoal")
                {
                    g = new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]),
                        int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                }

                if (g != null)
                {
                    _goals.Add(g);
                }
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
                return value;

            Console.WriteLine("Invalid number. Try again.");
        }
    }
}
