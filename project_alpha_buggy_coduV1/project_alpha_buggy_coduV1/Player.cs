public class Player
{
    public string Name { get; set; }
    public int CurrentHitPoints { get; set; }
    public int MaximumHitPoints { get; set; }
    public Weapon? CurrentWeapon { get; set; }
    public Location CurrentLocation { get; set; }
    public Quest? CurrentQuest { get; set; }
    public List<Quest> CompletedQuests { get; set; } = new List<Quest>();

    public Player(int currentHitPoints, int maximumHitPoints, Location currentLocation, Weapon? currentWeapon = null)
    {
        CurrentHitPoints = currentHitPoints;
        MaximumHitPoints = maximumHitPoints;
        CurrentWeapon = currentWeapon;
        CurrentLocation = currentLocation;
    }

    public void MoveTo(Location newLocation)
    {
        if (newLocation.ID == World.LOCATION_ID_BRIDGE && CompletedQuests.Count < 2)
        {
            Console.WriteLine("\nThe guard stops you.");
            Console.WriteLine("\"You cannot cross the bridge yet.\"");
            Console.WriteLine("\"Come back after you complete 2 quests for the town.\"");
            return;
        }

        if (newLocation.ID == World.LOCATION_ID_BRIDGE && CompletedQuests.Count == 2)
        {
            Console.WriteLine("\nGuard: \"I see you've helped the town. You may pass.\"");
        }
        CurrentLocation = newLocation;
    }
}