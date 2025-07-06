
public class EnumerationActivity : Activities
{
    private List<string> _prompts;

    public EnumerationActivity() : base("Enumeration Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a specific area.",
        45)
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    protected override void PerformActivity()
    {
        string prompt = GetPromptString(_prompts);
        Console.WriteLine(prompt);
        Console.WriteLine();
        
        DisplaySpinner("Think about this prompt: ", 5);
        
        Console.WriteLine("Start listing items (press Enter after each item):");
        
        int itemCount = 0;
        while (!HasTimerExpired())
        {
            Console.Write($"Item {itemCount + 1}: ");
            
            // Set up a timeout for user input
            DateTime inputStart = DateTime.Now;
            string input = "";
            
            while (DateTime.Now.Subtract(inputStart).TotalSeconds < 10 && !HasTimerExpired())
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        itemCount++;
                        break;
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (char.IsLetterOrDigit(keyInfo.KeyChar) || char.IsPunctuation(keyInfo.KeyChar) || keyInfo.KeyChar == ' ')
                    {
                        input += keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);
                    }
                }
                Thread.Sleep(100);
            }
            
            if (HasTimerExpired()) break;
            
            // If no input was given in time, move to next item
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("(Moving to next item...)");
            }
        }
        
        Console.WriteLine($"\nYou listed {itemCount} items!");
    }
}
