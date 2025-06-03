using System;
using System.Collections.Generic;

// Program.cs
class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();
        
        // Create scripture references and add scriptures
        Reference ref1 = new Reference("John", 3, 16);
        Scripture sr1 = new Scripture(ref1, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        
        Reference ref2 = new Reference("Ether", 12, 27);
        Scripture sr2 = new Scripture(ref2, "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them.");
        
        Reference ref3 = new Reference("Proverbs", 3, 5, 6);
        Scripture sr3 = new Scripture(ref3, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        
        Reference ref4 = new Reference("1 Nephi", 3, 7);
        Scripture sr4 = new Scripture(ref4, "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");
        
        scriptures.Add(sr1);
        scriptures.Add(sr2);
        scriptures.Add(sr3);
        scriptures.Add(sr4);

        // Display menu
        int count = 1;
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorization Tool!");
        Console.WriteLine("=========================================");
        Console.WriteLine();
        
        foreach (Scripture scripture in scriptures)
        {
            Console.WriteLine($"{count} -> {scripture.GetScriptureReference()}");
            count++;
        }
        
        Console.WriteLine();
        Console.Write("On which scripture do you wish to work? (1-{0}): ", scriptures.Count);
        
        int selectedScripture;
        while (!int.TryParse(Console.ReadLine(), out selectedScripture) || 
               selectedScripture < 1 || selectedScripture > scriptures.Count)
        {
            Console.Write("Please enter a valid number (1-{0}): ", scriptures.Count);
        }
        selectedScripture--; // Convert to 0-based index

        // Scripture memorization loop
        string input = "";
        bool finished = false;
        
        while (input != "q" && !finished)
        {
            Console.Clear();
            Console.WriteLine("Scripture Memorization");
            Console.WriteLine("=====================");
            Console.WriteLine();
            Console.WriteLine(scriptures[selectedScripture].GetScriptureReference());
            Console.WriteLine();
            
            scriptures[selectedScripture].ShowScripture();
            
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words, or type 'q' to quit:");
            
            finished = scriptures[selectedScripture].HideSomeWords();
            
            if (!finished)
            {
                input = Console.ReadLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Congratulations! You've hidden all the words!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}