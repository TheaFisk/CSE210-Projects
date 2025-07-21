    // Location class demonstrating abstraction
    public abstract class Location
    {
        protected string name;
        protected string description;
        protected List<Item> items;
        protected List<NPC> npcs;

        public Location(string name, string description)
        {
            this.name = name;
            this.description = description;
            this.items = new List<Item>();
            this.npcs = new List<NPC>();
        }

        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public List<Item> Items { get { return items; } }
        public List<NPC> NPCs { get { return npcs; } }

        public abstract void DisplayLocation();

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void AddNPC(NPC npc)
        {
            npcs.Add(npc);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }
    }
