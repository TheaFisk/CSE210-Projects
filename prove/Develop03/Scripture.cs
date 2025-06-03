
// Scripture.cs
public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _reference;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        
        // Split text into words and create Word objects
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public string GetScriptureReference()
    {
        return _reference.ToString();
    }

    public void ShowScripture()
    {
        foreach (Word word in _words)
        {
            Console.Write(word.GetWordString() + " ");
        }
        Console.WriteLine();
    }

    public bool HideSomeWords()
    {
        // Check if all words are already hidden
        bool allHidden = true;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                allHidden = false;
                break;
            }
        }

        if (allHidden)
        {
            return true; // All words are hidden, memorization complete
        }

        // Hide 3 random visible words (or fewer if less than 3 remain)
        Random random = new Random();
        List<Word> visibleWords = new List<Word>();
        
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        int wordsToHide = Math.Min(3, visibleWords.Count);
        
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }

        return false; // Not all words are hidden yet
    }
}