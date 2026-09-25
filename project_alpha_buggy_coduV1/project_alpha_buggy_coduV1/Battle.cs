public static class Battle
{
    public static bool Start(Player player, Monster monster)
    {
        int monstersDefeated = 0;

        while (monstersDefeated < 3 && player.CurrentHitPoints > 0)
        {
            Console.Clear();
            // Reset monster health for the next fight
            monster.CurrentHitPoints = monster.MaximumHitPoints;

            Console.WriteLine();
            Console.WriteLine(
                $"A {monster.Name} appears! " +
                $"({monstersDefeated + 1}/3)"
            );

            Console.WriteLine("Press ENTER to fight or E to escape.");

            string input = Console.ReadLine()!.Trim().ToLower();

            // Escape from battle
            if (input == "e")
            {
                Console.WriteLine("You escaped from the battle!");
                return false;
            }

            // Only ENTER starts the fight
            if (input != "")
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            // Fight this monster
            while (player.CurrentHitPoints > 0 &&
                   monster.CurrentHitPoints > 0)
            {
                int playerDamage =
                    World.RandomGenerator.Next(
                        1,
                        player.CurrentWeapon!.MaximumDamage + 1
                    );

                monster.CurrentHitPoints -= playerDamage;

                Console.WriteLine(
                    $"You hit the {monster.Name} " +
                    $"for {playerDamage} damage."
                );

                // Monster defeated
                if (monster.CurrentHitPoints <= 0)
                {
                    monstersDefeated++;

                    Console.WriteLine(
                        $"You defeated the {monster.Name}!"
                    );

                    Console.WriteLine(
                        $"Monsters defeated: {monstersDefeated}/3"
                    );

                    break;
                }

                int monsterDamage =
                    World.RandomGenerator.Next(
                        1,
                        monster.MaximumDamage + 1
                    );

                player.CurrentHitPoints -= monsterDamage;

                Console.WriteLine(
                    $"The {monster.Name} hits you " +
                    $"for {monsterDamage} damage."
                );

                Console.WriteLine(
                    $"Your health: " +
                    $"{player.CurrentHitPoints}/" +
                    $"{player.MaximumHitPoints}"
                );

                // Player died
                if (player.CurrentHitPoints <= 0)
                {
                    Console.WriteLine("You died!");
                    return false;
                }
            }

            // All 3 monsters defeated
            if (monstersDefeated == 3)
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"You defeated all 3 {monster.Name}s!"
                );

                return true;
            }

            Console.WriteLine();
            Console.WriteLine(
                "Press ENTER to fight the next monster " +
                "or E to escape."
            );
        }

        return false;
    }
}