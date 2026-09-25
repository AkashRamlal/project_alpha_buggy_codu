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

            // Fight this monster
            while (player.CurrentHitPoints > 0 &&
                   monster.CurrentHitPoints > 0)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Press ENTER to attack or E to escape."
                );

                ConsoleKey key = Console.ReadKey(true).Key;

                // Escape from battle
                if (key == ConsoleKey.E)
                {
                    Console.WriteLine(
                        "You escaped from the battle!"
                    );

                    return false;
                }

                // Only ENTER attacks
                if (key != ConsoleKey.Enter)
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                // Player attacks
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

                // Monster attacks
                int monsterDamage =
                    World.RandomGenerator.Next(
                        1,
                        monster.MaximumDamage + 1
                    );

                player.CurrentHitPoints -= monsterDamage;

                // Prevent health from going below 0
                if (player.CurrentHitPoints < 0)
                {
                    player.CurrentHitPoints = 0;
                }

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
                    Console.WriteLine();
                    Console.WriteLine("You died!");
                    Console.WriteLine("GAME OVER");

                    Environment.Exit(0);
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
        }

        return false;
    }
}