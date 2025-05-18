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
                    myJournal.Entries();
                    break;

                case 2:
                    List<JournalEntry> entriesList = myJournal.returnJournalEntry();
                    foreach (JournalEntry item in entriesList)
                    {
                        Console.WriteLine($"Date: {item._date} Questions: {item._question}, Responsive: {item._response}");
                    }
                    break;

                case 3:
                    /* 3. Read Journal From File
                    - Has to ask for the file you want to read from
                    - ONLY displays the content of the file
                    - Essentially a basic file reader
                    - Should display the journal in format of: 
                    - Date: Question (newline) Answer. (newline) Repeat
                    - THAT IS ALL IT DOES */
                    Console.WriteLine("What is the name of the file you would like to read from?");
                    string filename = Console.ReadLine();
                    myJournal.ReadFromFile(filename);
                    

                    break;
                case 4:
                    /* 4. Write Journal To File
                        - HAS to ask for the file to write to, creates new file if file not found
                        - Takes the current unsaved entries string list from New Journal Entry and saves them to file
                        - Again, THAT IS ALL IT DOES */
                    //Journal.WriteToFile();
                    Console.WriteLine("You chose 4!");
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