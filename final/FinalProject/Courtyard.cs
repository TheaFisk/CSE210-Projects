

    public class Courtyard : Location
    {
        public Courtyard() : base("Prison Courtyard", "An outdoor area surrounded by high walls topped with razor wire.")
        {
            AddItem(new Item("Wire Cutters", "Heavy-duty wire cutters left by maintenance"));
        }

        public override void DisplayLocation()
        {
            Console.WriteLine($"\n=== {name} ===");
            Console.WriteLine(description);
            Console.WriteLine("You can see the fence and freedom beyond...");
        }
    }