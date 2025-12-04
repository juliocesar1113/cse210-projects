using System;

abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"{GetCompletionMarker()} {_shortName} ({_description})";
    }

    public string GetDisplayName() => _shortName;

    protected string GetCompletionMarker() => IsComplete() ? "[X]" : "[ ]";

    public abstract string GetStringRepresentation();
}
