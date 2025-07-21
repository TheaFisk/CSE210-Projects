
using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        try
        {
            GameEngine game = new GameEngine();
            game.StartGame();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
            
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
