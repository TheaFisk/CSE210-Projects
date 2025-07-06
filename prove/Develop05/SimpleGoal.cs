
// Simple goal - complete once for points
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name}|{_description}|{_points}|{_isComplete}";
    }

    public override Goal CreateFromString(string data)
    {
        string[] parts = data.Split('|');
        var goal = new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]));
        goal._isComplete = bool.Parse(parts[3]);
        return goal;
    }
}