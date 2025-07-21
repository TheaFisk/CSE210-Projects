
    public class GuardRoom : Location
    {
        public GuardRoom() : base("Guard Room", "The guards' break room with monitors showing security cameras.")
        {
            AddItem(new Item("Uniform", "A guard uniform that might help you blend in"));
            AddNPC(new NPC("Guard Johnson", 120, "Hey! You're not supposed to be here!", false));
        }

        public override void DisplayLocation()
        {
            Console.WriteLine($"\n=== {name} ===");
            Console.WriteLine(description);
            Console.WriteLine("Multiple screens show various parts of the prison...");
        }
    }
