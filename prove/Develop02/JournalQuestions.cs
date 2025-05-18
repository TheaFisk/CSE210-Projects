using System;
using System.Collections.Generic;

public class JournalQuestions
{
    private Random random = new Random();

    // List of possible journal questions
    private List<string> Questions = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Who did you put on The List today? Why?",
        "Who did you remove from The List today? How?",
        "Are there any crimes you'd like to confess to today?"
    };

    // Method to get a random question
    public string GetRandomQuestion()
    {
        int index = random.Next(Questions.Count);
        return Questions[index];
    }
    //NextQuestion(): String || <-- string class to select the next question
    //Stretch goal ideas: Display a random day, display a random answer and you have to guess the day minigame, display a 1 year ago memory day
}