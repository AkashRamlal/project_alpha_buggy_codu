class Program
{
    public static void Main()
    {
        bool gameIsRunning = true;
        Location startingLocation = World.Locations[0];

        Console.WriteLine("Enter your Hero's name:");
        string input1 = Console.ReadLine();

        // If the user doesn't enter a name, default to "Hero"
        if (string.IsNullOrWhiteSpace(input1))
        {
            input1 = "Hero";
        }
        else
        {
            input1 = input1.Trim();
        }

        Player player = new Player(
            200,
            200,
            startingLocation,
            World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD)
        );

        Console.WriteLine($"Welcome, {input1}!");
        player.Name = input1;

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
                    player.CurrentLocation = (Location)actionToPerform.Item2;
                    break;

                case "OpenInventory":
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
                            player.CurrentWeapon = completedQuest.Reward;
                            Console.WriteLine($"You received a reward: {completedQuest.Reward.Name} ({completedQuest.Reward.MaximumDamage} max damage)!");
                            Console.WriteLine($"You have equipped the {completedQuest.Reward.Name}.");
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
                            Console.WriteLine("You have declined the quest.");
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