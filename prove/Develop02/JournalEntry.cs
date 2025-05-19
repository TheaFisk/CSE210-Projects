

public class JournalEntry
{
    // Fields
    public string _date;
    public string _question;
    public string _response;

    // Default constructor
    public JournalEntry()
    {
        _date = "";
        _question = "";
        _response = "";
    }

    // Constructor used for loading from file
    public JournalEntry(string date, string question, string response)
    {
        _date = date;
        _question = question;
        _response = response;
    }

    // Used to generate a new entry interactively
    public void GetQuestionAndResponse()
    {
        JournalQuestions newQuestion = new JournalQuestions();
        _question = newQuestion.GetRandomQuestion();
        Console.WriteLine(_question);
        _response = Console.ReadLine();
        _date = DateTime.Now.ToShortDateString();
    }

    // Convert the entry to a formatted string for display
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_question}");
        Console.WriteLine($"Response: {_response}\n");
    }

    // Convert the entry to a string for saving to a file
    public string ToFileString()
    {
        return $"{_date}#{_question}#{_response}";
    }
}