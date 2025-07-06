
using System;
using System.Collections.Generic;
using System.Threading;

public class Activities
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected DateTime _endTime;

    public Activities(string name, string description, int seconds)
    {
        _name = name;
        _description = description;
        _duration = seconds;
        _endTime = DateTime.Now.AddSeconds(seconds);
    }

    public virtual void DisplayGreeting()
    {
        Console.WriteLine($"Welcome to the {_name}!");
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    public virtual void DisplayDescription()
    {
        Console.WriteLine($"This activity will help you {_description.ToLower()}");
        Console.WriteLine($"Duration: {_duration} seconds");
        Console.WriteLine();
    }

    public virtual void DisplayEnding()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"You spent {_duration} seconds on {_name}.");
        DisplaySpinner("", 3);
    }

    public void RunCountDown(string message, int seconds)
    {
        Console.Write(message);
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}...");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void DisplaySpinner(string message, int seconds)
    {
        Console.Write(message);
        char[] spinnerChars = { '|', '/', '-', '\\' };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        
        int spinnerIndex = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[spinnerIndex]);
            Thread.Sleep(250);
            Console.Write("\b");
            spinnerIndex = (spinnerIndex + 1) % spinnerChars.Length;
        }
        Console.WriteLine();
    }

    public void StartTime()
    {
        _endTime = DateTime.Now.AddSeconds(_duration);
    }

    public bool HasTimerExpired()
    {
        return DateTime.Now >= _endTime;
    }

    public virtual void ObtainDuration()
    {
        Console.Write("Enter the duration in seconds: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int duration))
        {
            _duration = duration;
        }
        else
        {
            Console.WriteLine("Invalid input. Using default duration of 30 seconds.");
            _duration = 30;
        }
    }

    public virtual string GetPromptString(List<string> prompts)
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }

    public virtual void RunActivity()
    {
        DisplayGreeting();
        ObtainDuration();
        DisplayDescription();
        RunCountDown("Prepare to begin in: ", 3);
        StartTime();
        PerformActivity();
        DisplayEnding();
    }

    protected virtual void PerformActivity()
    {
        // Base implementation - to be overridden by derived classes
    }
}