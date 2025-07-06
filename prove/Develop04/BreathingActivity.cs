
public class BreathingActivity : Activities
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 
        30)
    {
    }

    protected override void PerformActivity()
    {
        while (!HasTimerExpired())
        {
            Console.WriteLine("Breathe in...");
            RunCountDown("", 4);
            
            if (HasTimerExpired()) break;
            
            Console.WriteLine("Breathe out...");
            RunCountDown("", 4);
        }
    }
}