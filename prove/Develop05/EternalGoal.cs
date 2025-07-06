
// Eternal goal - never complete, gain points each time
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false; // Never complete
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_name}|{_description}|{_points}";
    }

    public override Goal CreateFromString(string data)
    {
        string[] parts = data.Split('|');
        return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
    }
}