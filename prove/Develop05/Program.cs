using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Main program
public class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}