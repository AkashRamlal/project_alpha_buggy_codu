class Program{

    
    public static void Main(){
        bool gameIsRunning = true;
        Location startingLocation = World.Locations[0];
        Player player = new Player("AAA", 200, 200, startingLocation, null);
        while(gameIsRunning)
        {
            Tuple<String, Object> actionToPerform = player.CurrentLocation.Main(player);
            //USE actionToPerform.Item2 to get the appropriate parameter
            switch(actionToPerform.Item1)
            {
                case "Travel":
                    player.CurrentLocation = (Location)actionToPerform.Item2;
                break;
                case "OpenInventory":
                
                break;
                case "EnterBattle":
                    Monster monsterToUse = (Monster)actionToPerform.Item2;
                
                break;
                case "TakeQuest":
                    Quest quest = (Quest)actionToPerform.Item2;
                    Console.WriteLine($"Quest available: {quest.Name}");
                    Console.WriteLine(quest.Description);
                    Console.WriteLine("Do you want to accept the quest? (y/n)");

                    string input = Console.ReadLine();

                    if(input.ToLower() == "y")
                    {
                        player.Quests.Add(quest);
                        Console.WriteLine($"You have accepted the quest: {quest.Name}");
                    }
                    else
                    {
                        Console.WriteLine("You have declined the quest.");
                        // add logic that the player can go back to the previous location.
                    }
                        break;
            }
        }
    }

}
