
public class Scripture
{
    private List<Word> _words = new List<Word>();

    private Reference _reference;

    public Scripture(Reference reference, string text)
    {
        Console.WriteLine("the scripture");
    }

    bool HideSomewords()
    {
        Console.WriteLine("Okay");
        return true;
    }


}