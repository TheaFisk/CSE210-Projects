
using System;
using System.Collections.Generic;

public class FutureFocusActivity : Activities
{
    private List<string> _futurePrompts;

    public FutureFocusActivity() : base("Future Focus Activity",
        "This activity will help you envision positive outcomes and set intentions for your future. Focusing on achievable goals can reduce anxiety and increase motivation.",
        45)
    {
        _futurePrompts = new List<string>
        {
            "Imagine yourself successfully completing a goal you're working toward.",
            "Picture a typical day in your ideal future lifestyle.",
            "Visualize yourself overcoming a current challenge you're facing.",
            "Think about a skill you want to develop and see yourself using it confidently.",
            "Imagine a relationship in your life becoming stronger and more positive.",
            "Picture yourself in a place where you feel completely at peace.",
            "Visualize yourself helping someone else achieve their dreams.",
            "Think about a fear you have and imagine conquering it.",
            "Picture yourself celebrating a future accomplishment.",
            "Imagine waking up tomorrow feeling excited about the day ahead."
        };
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Let's focus on positive possibilities for your future.");
        Console.WriteLine("Take each visualization seriously and let yourself really see it happening.");
        Console.WriteLine();

        while (!HasTimerExpired())
        {
            string prompt = GetPromptString(_futurePrompts);
            Console.WriteLine(prompt);
            Console.WriteLine();
            
            DisplaySpinner("Visualizing your positive future: ", 12);
            
            if (!HasTimerExpired())
            {
                Console.WriteLine("Hold onto that positive feeling for a moment...");
                DisplaySpinner("", 4);
                Console.WriteLine();
            }
        }
    }

    public override void DisplayEnding()
    {
        Console.WriteLine("Great work! You've spent time envisioning positive futures.");
        Console.WriteLine("Remember: the future you imagine can become the future you create.");
        Console.WriteLine($"You focused on your future potential for {_duration} seconds.");
        DisplaySpinner("Carrying this optimism forward: ", 3);
    }
}