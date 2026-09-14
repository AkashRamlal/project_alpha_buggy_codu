class Program
{
    static void Main(string[] args)
    {
        if (currentLocation.QuestAvailableHere != null)
        {
            Quest quest = currentLocation.QuestAvailableHere;
            Console.WriteLine($"Quest available: {quest.Name}");
            Console.WriteLine(quest.Description);
            Console.WriteLine("Do you want to accept the quest? (y/n)");

            string input = Console.ReadLine();

            if(input.ToLower() == "y")
            {
                player.Quests.Add(currentLocation.QuestAvailableHere);
                Console.WriteLine($"You have accepted the quest: {quest.Name}");
            }
            else
            {
                Console.WriteLine("You have declined the quest.");
                // add logic that the player can go back to the previous location.
            }
        }
        else
        {
            Console.WriteLine("Quest is not available.");
        }
    }
}
