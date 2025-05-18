using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {

        //Asks user for grade percentage
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int studentGrade = int.Parse(userInput);
        string grade = "";

        //Tests for percentage and returns letter grade
        if (studentGrade >= 90)
        {
            grade = "A";
        }
        else if (studentGrade >= 80)
        {
            grade = "B";
        }
        else if (studentGrade >= 70)
        {
            grade = "C";
        }
        else if (studentGrade >= 60)
        {
            grade = "D";
        }
        else if (studentGrade <= 50)
        {
            grade = "F";
        }
        Console.WriteLine($"Your grade is: {grade}!");

        //Tests whether student passed
        if (studentGrade >= 70)
        {
            Console.WriteLine("Great job passing the class!");
        }
        else 
        {
            Console.WriteLine("Oh no! You failed. To the gladiator ring!");
        }
    }

}