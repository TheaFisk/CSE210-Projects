
using System.ComponentModel.DataAnnotations;

public class Journal
{
    private List<JournalEntry> _entries = new List<JournalEntry>();

    public void AddEntry()
    {
        Console.WriteLine("You have correctly reached the journal!");
        JournalEntry newEntry = new JournalEntry();
        newEntry.GetQuestionAndResponse();
        _entries.Add(newEntry);
    }

    public List<JournalEntry> returnJournalEntry()
    {
        return _entries;
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
                Console.WriteLine($"Saving {_entries.Count} entries to {filename}");
                Console.WriteLine($"Saved to: {Path.GetFullPath(filename)}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            string[] parts = line.Split('#');
            if (parts.Length == 3)
            {
                string date = parts[0];
                string question = parts[1];
                string response = parts[2];
                _entries.Add(new JournalEntry(date, question, response));
            }
            else
            {
                Console.WriteLine($"Skipped malformed line: {line}");
            }
        }
    }
}