
using System.ComponentModel.DataAnnotations;

public class Journal
{
    //attributes = entries
    //methods = save, load, display

    private List<JournalEntry> _entries = new List<JournalEntry>();
    public void Entries()
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

    /*
        public void WriteToFile(string filename)
        {
            //WriteToFile(filename: string): void
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (JournalEntry entry in entries)
                {
                    outputFile.WriteLine(entry.ToString());
                }
            }
        }
        */
    
    public void ReadFromFile(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("#");

            string date = parts[0];
            string question = parts[1];
            string response = parts[2];

            JournalEntry entry = new JournalEntry();

            //entry.JournalEntry(date, question, response);
            //this.AddEntry(entry);
        }
    }
    
}