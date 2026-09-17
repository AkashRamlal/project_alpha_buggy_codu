class Program
{
    public static void Main()
    {
        bool gameIsRunning = true;
        Location startingLocation = World.Locations[0];

        Player player = new Player(
            "AAA",
            200,
            200,
            startingLocation,
            World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD)
        );

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