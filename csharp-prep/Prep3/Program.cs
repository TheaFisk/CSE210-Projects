using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        Console.Write("What's the magic number? ");
        string magicNumberInput = Console.ReadLine();
        int magicNumber = int.Parse(magicNumberInput);
        int guess;

        do 
        {
           Console.WriteLine("What is your guess?");
            string guessInput = Console.ReadLine();
            guess = int.Parse(guessInput);

            if (magicNumber > guess)
                Console.WriteLine("Too low!");
            else if (magicNumber < guess)
                Console.WriteLine("Too high!");
            else
                Console.WriteLine("You guessed it!");
        } while (guess != magicNumber);
        
    }
}