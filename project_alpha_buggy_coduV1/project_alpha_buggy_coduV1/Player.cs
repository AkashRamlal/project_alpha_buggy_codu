public class Player
{
    public string Name { get; set; }
    public int CurrentHitPoints { get; set; }
    public int MaximumHitPoints { get; set; }
    public Weapon CurrentWeapon { get; set; }
    //public Location CurrentLocation { get; set; }

    public Player(string name, int currentHitPoints, int maximumHitPoints, Weapon currentWeapon /*Location currentLocation*/)
    {
        Name = name;
        CurrentHitPoints = currentHitPoints;
        MaximumHitPoints = maximumHitPoints;
        CurrentWeapon = currentWeapon;
        //CurrentLocation = currentLocation;
    }
}