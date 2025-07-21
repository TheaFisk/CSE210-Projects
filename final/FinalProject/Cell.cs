    // Specific location classes demonstrating inheritance and polymorphism
    public class Cell : Location
    {
        public Cell() : base("Prison Cell", "Your cramped cell with cold stone walls and iron bars.")
        {
            AddItem(new Item("Rusty Spoon", "An old spoon that might be useful for digging"));
            AddItem(new Item("Torn Blanket", "A raggedy blanket from your bed"));
        }

        public override void DisplayLocation()
        {
            Console.WriteLine($"\n=== {name} ===");
            Console.WriteLine(description);
            Console.WriteLine("The door is locked, but there's a loose stone in the wall...");
        }
    }