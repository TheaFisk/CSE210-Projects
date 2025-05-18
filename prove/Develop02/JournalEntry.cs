

public class JournalEntry
{
    
    public string _date;
    public string _question;
    public string _response;
    DateTime now = DateTime.Now;

    public JournalEntry()
    {
        _date = "";
        _question = "";
        _response = "";
    }

    public void GetQuestionAndResponse()
    {
        JournalQuestions NewQuestion = new JournalQuestions();
        _question = NewQuestion.GetRandomQuestion();
        Console.WriteLine(_question);
        _response = Console.ReadLine();
        _date = now.ToShortDateString();
    }

    public string EntryText; //<-- ?
    //Display(): void
    //Entry To String(): Void
    //CreateEntryWithPrompt(prompt: string): void
    //CreateEntryWithData(date:string, ||) <-- Use constructor instead, pass information into the JournalEntry to construct an entry
}