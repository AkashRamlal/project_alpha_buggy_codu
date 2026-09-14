public static class Battle
{
    public static void Start(Player player, Monster monster)
    {
        monster.CurrentHitPoints = monster.MaximumHitPoints;

        while (player.CurrentHitPoints > 0 && monster.CurrentHitPoints > 0)
        {
            int playerDamage =
                World.RandomGenerator.Next(1, player.CurrentWeapon.MaximumDamage + 1);

            monster.CurrentHitPoints -= playerDamage;

            Console.WriteLine(
                $"You hit the {monster.Name} for {playerDamage} damage."
            );

            if (monster.CurrentHitPoints <= 0)
            {
                Console.WriteLine($"You defeated the {monster.Name + "s"}!");
                break;
            }

            int monsterDamage =
                World.RandomGenerator.Next(1, monster.MaximumDamage + 1);

            player.CurrentHitPoints -= monsterDamage;

            Console.WriteLine(
                $"The {monster.Name} hits you for {monsterDamage} damage."
            );

            if (player.CurrentHitPoints <= 0)
            {
                Console.WriteLine("You died!");
                break;
            }
        }
    }
}