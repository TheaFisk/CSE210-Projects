
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Relaxation Activity Program!");
        
        int input = 0;
        
        while (input != 5)
        {
            Console.WriteLine("\nHere are your options:");
            Console.WriteLine("1. Reflection Activity");
            Console.WriteLine("2. Breathing Activity");
            Console.WriteLine("3. Enumeration Activity");
            Console.WriteLine("4. Future Focus Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Enter a number to get started: ");
            
            string userInput = Console.ReadLine();
            
            if (int.TryParse(userInput, out input))
            {
                Activities activity = null;
                
                switch (input)
                {
                    case 1:
                        activity = new ReflectionActivity();
                        break;
                    case 2:
                        activity = new BreathingActivity();
                        break;
                    case 3:
                        activity = new EnumerationActivity();
                        break;
                    case 4:
                        activity = new FutureFocusActivity();
                        break;
                    case 5:
                        Console.WriteLine("Thank you for using the Relaxation Activity Program!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        continue;
                }
                
                if (activity != null)
                {
                    Console.Clear();
                    activity.RunActivity();
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}