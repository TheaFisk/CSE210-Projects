

    // Player class inheriting from Character
    public class Player : Character
    {
        private List<Item> inventory;
        private bool hasFriend;
        private string friendName;

        public Player(string name) : base(name, 100)
        {
            inventory = new List<Item>();
            hasFriend = false;
            friendName = "";
        }

        public bool HasFriend { get { return hasFriend; } }
        public string FriendName { get { return friendName; } }

        public override string GetDescription()
        {
            return $"You are {name}, a prisoner determined to escape. Health: {health}/100";
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
            Console.WriteLine($"You picked up: {item.Name}");
        }

        public bool HasItem(string itemName)
        {
            return inventory.Any(item => item.Name.ToLower() == itemName.ToLower());
        }

        public void MakeFriend(string friendName)
        {
            this.hasFriend = true;
            this.friendName = friendName;
            Console.WriteLine($"You have befriended {friendName}!");
        }

        public void ShowInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                Console.WriteLine("Inventory:");
                foreach (var item in inventory)
                {
                    Console.WriteLine($"- {item.Name}: {item.Description}");
                }
            }
        }
    }