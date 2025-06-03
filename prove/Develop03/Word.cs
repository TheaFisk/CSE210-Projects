
using System;


public class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public string GetWordString()
    {
        if (_hidden)
        {
            // Create underscores for each character in the word (excluding punctuation)
            string result = "";
            foreach (char c in _word)
            {
                if (char.IsLetter(c))
                {
                    result += "_";
                }
                else
                {
                    result += c; // Keep punctuation visible
                }
            }
            return result;
        }
        else
        {
            return _word;
        }
    }
}