using System;
using System.Collections;
using System.IO.Enumeration;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)

    {
        Console.WriteLine("Hello Develop02 World!");

        Menu menu = new Menu();
        int choice = 0;
        Journal myJournal = new Journal();

        while (choice != 5)
        {
            choice = menu.DisplayMenu();
            switch (choice)
            {
                case 1:
                    myJournal.AddEntry();
                    break;

                case 2:
                    List<JournalEntry> entriesList = myJournal.returnJournalEntry();
                    foreach (JournalEntry item in entriesList)
                    {
                        Console.WriteLine($"Date: {item._date} Question: {item._question}, Response: {item._response}");
                    }
                    break;

                case 3:

                    Console.WriteLine("Load Option:");
                    //DisplayFilesInDirectory();
                    Console.WriteLine("Enter the filename to load:");
                    string fileToLoad = Console.ReadLine();
                    myJournal.LoadFromFile(fileToLoad);
                    Console.WriteLine("File loaded successfully.");
                    Console.WriteLine("Press any key to go back...");
                    Console.ReadLine();
                    //Console.WriteLine("What is the name of the file you would like to read from?");
                    //string filename = Console.ReadLine();
                    //myJournal.ReadFromFile(filename);
                    break;
                case 4:

                    Console.WriteLine("Enter the filename to save the entry:");
                    string fileToSave = Console.ReadLine();
                    myJournal.SaveToFile(fileToSave); // ✅ Actually saves the entries
                    Console.WriteLine("Entry saved successfully.");
                    Console.WriteLine("Press Enter to go back...");
                    Console.ReadLine();
                    break;

                case 5:
                    //Ends program
                    break;
                default:
                    Console.WriteLine("Please select a valid number within range.");
                    break;
            }
        }
 
        //- Check for unsaved files and tell user they will lose their data
        //"dirty" for the "have you saved your work?", use a boolean value called "changed" listed below the entries in your journal class to determine if the changes have been saved. 

        //depending on the number, activate certain protocols
        // 3. Save Journal : Call Journal class .notation to the save method
        // 4. Load Journal : Call Journal class .notation to the load method

        //public override string ToString <--- Every object inherits from the base object
        //Array vs list
    }

    private static string ObtainFileName(string prompt)
    {
        Console.WriteLine(prompt);
        string fileName = Console.ReadLine();
        return fileName;
    }
}