using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("What is your first name? ");
        String firstName = Console.ReadLine();
        Console.Write("What is your last name? ");
        String lastName = Console.ReadLine();

        firstName = char.ToUpper(firstName[0]) + firstName.Substring(1);
        lastName = char.ToUpper(lastName[0]) + lastName.Substring(1);

        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
        
    }
}