public class Monster
{
    public int ID;
    public string Name;
    public int MaximumDamage;
    public int CurrentHitPoints;
    public int MaximumHitPoints;

    public Monster(int a, string b, int c, int d, int e) => (ID, Name, MaximumDamage, CurrentHitPoints, MaximumHitPoints) = (a, b, c, d, e);
}
