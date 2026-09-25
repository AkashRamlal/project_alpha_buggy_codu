class Program
{
    public static void Main()
    {
        bool gameIsRunning = true;
        Location startingLocation = World.Locations[0];

        List<(string Name, string[] Contributions)> team = new()
        {
            ("Dalal", new[] { "Welcome screen", "Credits", "Rewards" }),
            ("Akash", new[] { "Battle a monster", "Battle info" }),
            ("Vivesh", new[] { "Quest gate", "Start a quest" }),
            ("Sem", new[] { "Move Location", "Inventory management", "Menu fine tunen" })
        };


        //Welcome screen code here pls :D
        Console.WriteLine(@"
,--.   ,--.              ,--.   ,--.            ,---.     ,-----.                          ,--.
|  |   |  | ,---. ,--.--.|  | ,-|  |     ,---. /  .-'    '  .-.  '  ,--.,--. ,---.  ,---.,-'  '-. ,---.
|  |.'.|  || .-. ||  .--'|  |' .-. |    | .-. ||  `-,    |  | |  |  |  ||  || .-. :(  .-''-.  .-'(  .-'
|   ,'.   |' '-' '|  |   |  |\ `-' |    ' '-' '|  .-'    '  '-'  '-.'  ''  '\   --..-'  `) |  |  .-'  `)
'--'   '--' `---' `--'   `--' `---'      `---' `--'       `-----'--' `----'  `----'`----'  `--'  `----'
");

        Console.WriteLine("===========================================================================================================");
        Console.WriteLine();

        string text = "Welcome, adventurer!\n" +
                      "Explore the town and its surroundings, accept quests\n" +
                      "defeat the monsters that threaten the land and earn\n" +
                      "stronger weapons along the way.";

        foreach (char letter in text)
        {
            Console.Write(letter);
            Thread.Sleep(30);
        }

        Console.WriteLine();
        Console.WriteLine();

        // Ask for hero's name
        string input1;

        while (true)
        {
            Console.Write("Enter your Hero's name: ");
            input1 = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input1))
            {
                input1 = input1.Trim();
                break;
            }

            Console.WriteLine("You must enter a name to start the game.");
        }

        // Create a new player with the provided name and starting location
        Player player = new Player(
            200,
            200,
            startingLocation,
            World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD)
        );
        Inventory inventory = new Inventory([World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD)]);
        input1 = input1?.Trim() ?? "Hero";
        Console.WriteLine($"Welcome, {input1}!");
        player.Name = input1;

        Console.WriteLine();
        Console.WriteLine($"Welcome, {player.Name}!");
        Console.WriteLine();

        Console.WriteLine(
            $"Your name is {player.Name}. You live in a town called Riverbend.\n" +
            "You always dreamed to be a hero. And now when you heard that your town is being terrorized by big spiders.\n" +
            "You decided to do all you can to help your town.\n" +
            "In a chest in your home there is a rusty sword that once your father fought with.\n" +
            "You take it and from now on you swear to protect the people of your town."
        );
        Console.WriteLine();

        while (gameIsRunning)
        {
            Tuple<String, Object> actionToPerform = player.CurrentLocation.Main(player);

            //USE actionToPerform.Item2 to get the appropriate parameter
            switch (actionToPerform.Item1)
            {
                case "Travel":
                    player.MoveTo((Location)actionToPerform.Item2);
                    break;

                case "OpenInventory":
                inventory.InvMenu(player);
                    break;

                case "EnterBattle":
                    Monster monsterToUse = (Monster)actionToPerform.Item2;

                    bool battleWon = Battle.Start(player, monsterToUse);

                    if (battleWon && player.CurrentQuest != null && player.CurrentQuest.RequiredMonsterID == monsterToUse.ID)
                    {
                        Quest completedQuest = player.CurrentQuest;

                        player.CompletedQuests.Add(completedQuest);
                        player.CurrentQuest = null;

                        Console.WriteLine();
                        Console.WriteLine($"Quest complete: {completedQuest.Name}!");

                        if (completedQuest.Reward != null)
                        {
                            inventory.AddWp(completedQuest.Reward);
                            Console.WriteLine($"You received a reward: {completedQuest.Reward.Name} ({completedQuest.Reward.MaximumDamage} max damage)!");
                            Console.WriteLine("Do you want to equip it? Y/N");
                            string input = Console.ReadLine()!.ToLower();
                            if (input == "y")
                            {
                                player.CurrentWeapon = completedQuest.Reward;
                                Console.WriteLine($"You have equipped the {completedQuest.Reward.Name}.");
                            } else
                            {
                                Console.WriteLine($"The {completedQuest.Reward.Name} was moved to your inventory.");
                            }
                        }


                        if (completedQuest.ID == World.QUEST_ID_COLLECT_SPIDER_SILK)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);

                            Console.Clear();

                            Console.WriteLine("-------------- CREDITS --------------");
                            Console.WriteLine();
                            Thread.Sleep(1000);

                            foreach (var teamMember in team)
                            {
                                Console.WriteLine(teamMember.Name);

                                foreach (string contribution in teamMember.Contributions)
                                {
                                    Console.WriteLine($"    - {contribution}");
                                    Thread.Sleep(400);
                                }

                                Console.WriteLine();
                                Thread.Sleep(800);
                            }

                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to exit...");
                            Console.ReadKey(true);

                            gameIsRunning = false;
                        }
                    }

                    break;
                // Accept the quest if available and start a battle if there's a monster in the location
                case "TakeQuest":
                    if (player.CurrentQuest != null)
                    {
                        Console.WriteLine($"You are already on a quest: {player.CurrentQuest.Name}");
                        break;
                    }

                    if (player.CurrentLocation.QuestAvailableHere != null)
                    {
                        Quest quest = player.CurrentLocation.QuestAvailableHere;

                        Console.WriteLine($"Quest available: {quest.Name}");
                        Console.WriteLine(quest.Description);
                        Console.WriteLine("Do you want to accept the quest? (y/n)");

                        string input = Console.ReadLine();

                        // Check if the player accepts the quest
                        if (input.ToLower() == "y")
                        {
                            player.CurrentQuest = quest;
                            Console.WriteLine($"You have accepted the quest: {quest.Name}");

                            // Start a battle if there's a monster in the location
                            if (player.CurrentLocation.MonsterLivingHere != null)
                            {
                                Battle.Start(player, player.CurrentLocation.MonsterLivingHere);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You are about to abort the Quest are you really not man enough to take it?");
                            Console.WriteLine("yes / no");
                            string choice_2 = Console.ReadLine().ToLower();

                            if (choice_2 == "yes" || choice_2 == "y")
                            {
                                player.CurrentQuest = quest;
                                Console.WriteLine($"Thats what we like to see you Quest start now. {player.CurrentQuest.Name}");
                            }
                            else
                            {
                                Console.WriteLine("You canceled the Quest chicken");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no quest available here.");
                    }

                    break;
            }
        }
    }
}