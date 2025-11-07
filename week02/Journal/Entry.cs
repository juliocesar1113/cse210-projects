using System;
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;

    }

    public void Display()
    {
        Console.WriteLine($"{_date} - {_promptText}");

        Console.WriteLine(_entryText);
        Console.WriteLine();
    }
    public string ToFileFormat()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    // Crea un Entry desde una línea del archivo
    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length != 3)
        {
            throw new Exception("Formato de archivo inválido");
        }
        return new Entry(parts[0], parts[1], parts[2]);
    }
}