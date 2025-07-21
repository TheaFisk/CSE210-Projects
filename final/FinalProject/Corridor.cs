

    public class Corridor : Location
    {
        public Corridor() : base("Prison Corridor", "A long, dimly lit hallway with flickering lights.")
        {
            AddNPC(new NPC("Marcus", 80, "Hey, you trying to get out too? I know these halls like the back of my hand.", true));
            AddItem(new Item("Keycard", "A guard's keycard - this could be very useful!"));
        }

        public override void DisplayLocation()
        {
            Console.WriteLine($"\n=== {name} ===");
            Console.WriteLine(description);
            Console.WriteLine("You hear footsteps echoing in the distance...");
        }
    }