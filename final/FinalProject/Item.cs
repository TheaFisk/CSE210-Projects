    // Item class demonstrating encapsulation
    public class Item
    {
        private string name;
        private string description;
        private bool isUseful;

        public Item(string name, string description, bool isUseful = true)
        {
            this.name = name;
            this.description = description;
            this.isUseful = isUseful;
        }

        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public bool IsUseful { get { return isUseful; } }
    }
