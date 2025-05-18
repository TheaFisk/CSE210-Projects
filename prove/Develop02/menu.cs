
using System;
using System.Globalization;

public class Menu
{
    public int DisplayMenu()
    {
        Console.WriteLine("Here's the Journal menu! Choose a number:");
        Console.WriteLine("1. New Journal Entry");
        Console.WriteLine("2. Display Journal");
        Console.WriteLine("3. Read Journal From File");
        Console.WriteLine("4. Write Journal to File");
        Console.WriteLine("5. Quit");

        string input = Console.ReadLine();
        int number;

        while (!int.TryParse(input, out number))
        {
            Console.Write("Please enter a valid number within range.");
            input = Console.ReadLine();
        }
        
        return number;
    }


}