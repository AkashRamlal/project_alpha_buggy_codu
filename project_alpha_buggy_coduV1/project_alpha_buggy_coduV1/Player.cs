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
}