


    // Game engine class managing game state
    public class GameEngine
    {
        private Player player;
        private Location currentLocation;
        private Dictionary<string, Location> locations;
        private bool gameRunning;

        public GameEngine()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            Console.WriteLine("=== PRISON BREAK ADVENTURE ===");
            Console.Write("Enter your prisoner name: ");
            string playerName = Console.ReadLine();
            
            player = new Player(playerName);
            locations = new Dictionary<string, Location>
            {
                {"cell", new Cell()},
                {"corridor", new Corridor()},
                {"guardroom", new GuardRoom()},
                {"courtyard", new Courtyard()}
            };
            
            currentLocation = locations["cell"];
            gameRunning = true;
        }

        public void StartGame()
        {
            Console.WriteLine($"\nWelcome, {player.Name}!");
            Console.WriteLine("You've been wrongly imprisoned and must escape!");
            Console.WriteLine("Type 'help' for available commands.\n");

            while (gameRunning && player.IsAlive)
            {
                currentLocation.DisplayLocation();
                ProcessPlayerInput();
            }
        }

        private void ProcessPlayerInput()
        {
            Console.Write("\n> ");
            string input = Console.ReadLine().ToLower().Trim();
            string[] commands = input.Split(' ');

            switch (commands[0])
            {
                case "help":
                    ShowHelp();
                    break;
                case "look":
                    LookAround();
                    break;
                case "inventory":
                    player.ShowInventory();
                    break;
                case "take":
                    if (commands.Length > 1)
                        TakeItem(string.Join(" ", commands.Skip(1)));
                    else
                        Console.WriteLine("Take what?");
                    break;
                case "talk":
                    if (commands.Length > 1)
                        TalkToNPC(string.Join(" ", commands.Skip(1)));
                    else
                        Console.WriteLine("Talk to whom?");
                    break;
                case "befriend":
                    if (commands.Length > 1)
                        BefriendNPC(string.Join(" ", commands.Skip(1)));
                    else
                        Console.WriteLine("Befriend whom?");
                    break;
                case "move":
                case "go":
                    if (commands.Length > 1)
                        MoveToLocation(commands[1]);
                    else
                        Console.WriteLine("Move where?");
                    break;
                case "escape":
                    AttemptEscape();
                    break;
                case "quit":
                    gameRunning = false;
                    break;
                default:
                    Console.WriteLine("I don't understand that command. Type 'help' for available commands.");
                    break;
            }
        }

        private void ShowHelp()
        {
            Console.WriteLine("\nAvailable commands:");
            Console.WriteLine("look - Look around the current location");
            Console.WriteLine("inventory - Check your inventory");
            Console.WriteLine("take [item] - Pick up an item");
            Console.WriteLine("talk [person] - Talk to someone");
            Console.WriteLine("befriend [person] - Try to befriend someone");
            Console.WriteLine("move/go [location] - Move to a different location");
            Console.WriteLine("escape - Attempt to escape from the current location");
            Console.WriteLine("quit - Exit the game");
        }

        private void LookAround()
        {
            Console.WriteLine($"\n{currentLocation.Description}");
            
            if (currentLocation.Items.Count > 0)
            {
                Console.WriteLine("\nItems here:");
                foreach (var item in currentLocation.Items)
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }

            if (currentLocation.NPCs.Count > 0)
            {
                Console.WriteLine("\nPeople here:");
                foreach (var npc in currentLocation.NPCs)
                {
                    Console.WriteLine($"- {npc.Name}");
                }
            }
        }

        private void TakeItem(string itemName)
        {
            var item = currentLocation.Items.FirstOrDefault(i => 
                i.Name.ToLower().Contains(itemName.ToLower()));

            if (item != null)
            {
                player.AddItem(item);
                currentLocation.RemoveItem(item);
            }
            else
            {
                Console.WriteLine("There's no such item here.");
            }
        }

        private void TalkToNPC(string npcName)
        {
            var npc = currentLocation.NPCs.FirstOrDefault(n => 
                n.Name.ToLower().Contains(npcName.ToLower()));

            if (npc != null)
            {
                Console.WriteLine($"{npc.Name}: \"{npc.Speak()}\"");
                if (npc.CanBefriend && !player.HasFriend)
                {
                    Console.WriteLine($"(You can try to 'befriend {npc.Name.Split(' ')[0]}')");
                }
            }
            else
            {
                Console.WriteLine("There's no one here by that name.");
            }
        }

        private void BefriendNPC(string npcName)
        {
            var npc = currentLocation.NPCs.FirstOrDefault(n => 
                n.Name.ToLower().Contains(npcName.ToLower()));

            if (npc != null && npc.CanBefriend && !player.HasFriend)
            {
                player.MakeFriend(npc.Name);
                Console.WriteLine($"{npc.Name}: \"Together we can get out of here!\"");
            }
            else if (player.HasFriend)
            {
                Console.WriteLine("You already have a friend helping you escape.");
            }
            else if (npc != null)
            {
                Console.WriteLine($"{npc.Name} doesn't seem interested in being friends.");
            }
            else
            {
                Console.WriteLine("There's no one here by that name.");
            }
        }

        private void MoveToLocation(string locationName)
        {
            string currentLocationName = currentLocation.GetType().Name.ToLower();
            
            // Simple movement logic based on current location
            switch (currentLocationName)
            {
                case "cell":
                    if (locationName == "corridor" && player.HasItem("rusty spoon"))
                    {
                        currentLocation = locations["corridor"];
                        Console.WriteLine("You use the rusty spoon to loosen the stones and squeeze through!");
                    }
                    else if (locationName == "corridor")
                    {
                        Console.WriteLine("You need something to help you break out of this cell.");
                    }
                    else
                    {
                        Console.WriteLine("You can't go there from here.");
                    }
                    break;

                case "corridor":
                    if (locationName == "guardroom" || locationName == "guard")
                    {
                        currentLocation = locations["guardroom"];
                        Console.WriteLine("You sneak into the guard room...");
                    }
                    else if (locationName == "courtyard" || locationName == "yard")
                    {
                        currentLocation = locations["courtyard"];
                        Console.WriteLine("You make your way to the courtyard...");
                    }
                    else if (locationName == "cell")
                    {
                        currentLocation = locations["cell"];
                        Console.WriteLine("You go back to your cell.");
                    }
                    else
                    {
                        Console.WriteLine("You can't go there from here. Try 'guardroom' or 'courtyard'.");
                    }
                    break;

                case "guardroom":
                    if (locationName == "corridor")
                    {
                        currentLocation = locations["corridor"];
                        Console.WriteLine("You return to the corridor.");
                    }
                    else
                    {
                        Console.WriteLine("You can only go back to the corridor from here.");
                    }
                    break;

                case "courtyard":
                    if (locationName == "corridor")
                    {
                        currentLocation = locations["corridor"];
                        Console.WriteLine("You return to the corridor.");
                    }
                    else
                    {
                        Console.WriteLine("You can only go back to the corridor from here.");
                    }
                    break;

                default:
                    Console.WriteLine("You can't go there from here.");
                    break;
            }
        }

        private void AttemptEscape()
        {
            string locationName = currentLocation.GetType().Name.ToLower();
            
            if (locationName == "courtyard")
            {
                if (player.HasItem("wire cutters"))
                {
                    EndGame(true);
                }
                else
                {
                    Console.WriteLine("The fence is too high and covered in razor wire. You need something to cut through it.");
                }
            }
            else
            {
                Console.WriteLine("This doesn't seem like a good place to escape from. Look for a way outside.");
            }
        }

        private void EndGame(bool escaped)
        {
            gameRunning = false;
            Console.WriteLine("\n" + new string('=', 50));
            
            if (escaped)
            {
                Console.WriteLine("🎉 FREEDOM! 🎉");
                Console.WriteLine($"Congratulations, {player.Name}! You successfully escaped from prison!");
                
                if (player.HasFriend)
                {
                    Console.WriteLine($"\nYour friend {player.FriendName} escaped with you!");
                    Console.WriteLine("Together, you both start new lives as free people.");
                    Console.WriteLine("The friendship you formed in the darkest of places lights your path forward.");
                    Console.WriteLine("\n🌟 BEST ENDING: Friendship and Freedom! 🌟");
                }
                else
                {
                    Console.WriteLine("\nYou made it out alone, but at what cost?");
                    Console.WriteLine("Freedom feels bittersweet when you have no one to share it with.");
                    Console.WriteLine("You wonder about the people you left behind...");
                    Console.WriteLine("\n⭐ GOOD ENDING: Solo Freedom ⭐");
                }
            }
            else
            {
                Console.WriteLine("💀 GAME OVER 💀");
                Console.WriteLine("Your escape attempt failed. Better luck next time!");
            }
            
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Thanks for playing Prison Break Adventure!");
        }
    }