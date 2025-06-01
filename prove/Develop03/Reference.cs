
public class Reference
{
    string book = "";
    int chapter = 0;
    int startVerse = 0;
    int endVerse = 0;

    Reference()
    {
        Console.Clear();
    }

    
    public Reference(string name, int chapter, int startVerse, int endVerse, string text)
    {
        Console.WriteLine("Whaaaat");
    }
    public Reference
    (Reference _reference, string text)
    {
        Console.WriteLine("Scripture");
    }

    public override string ToString()
    {
        return base.ToString();
    }
}