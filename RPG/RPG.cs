using System.Data.Common;
using System.Data.SqlTypes;

namespace FirstThing.RPG; 

public class RPG {
    // enums for weapons/armors etc.
    public enum Weapons {
        Nothing = 0,
        WoodenSword = 5,
        BronzeSword = 7,
        SilverSword = 14,
        Fish = 99999999
    }
    
    public enum Armors {
        Nothing = 0,
        WoodenArmor = 3,
        BronzeArmor = 5,
        SilverArmor = 10,
        Bucket = 99999999
    }
    
    // City choices
    public static void Execute() {
        Console.WriteLine("Welcome, adventurer!");
        while (true) {
            Console.WriteLine("What will you do next?");
            Console.WriteLine("1. Go out of the city");
            Console.WriteLine("2. Check out local shop");
            Console.WriteLine("8. Rest (+25 HP)");
            Console.WriteLine("9. Stats");
            Console.WriteLine("0. Suicide");
            
            int choice = -1;
            try {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
            }
            switch (choice) {
                case 1:
                    Outside();
                    break;
                case 2:
                    Shop.Begin();
                    break;
                case 8:
                    Console.WriteLine("You take a nap...");
                    Player.Health += 25;
                    
                    break;
                case 9:
                    Player.OutputStats();
                    break;
                case 0:
                    Console.WriteLine("You decide that you're tired of all this");
                    return;
                default:
                    Console.WriteLine("Try again");
                    break;
            }
        }
    }

    // outside choices
    static void Outside() {
        Console.WriteLine("You are standing at gates.");
        Console.WriteLine("Where exactly you wish to go?");
        Console.WriteLine("1. Into forest");
        
        Console.WriteLine("0 (or anything). Go back");
        
        int choice = 0;
        try {
            choice = int.Parse(Console.ReadLine());
        }
        catch (Exception e) {
            Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
        }
        switch (choice) {
            case 1:
                Forest.BeginFight();
                break;
        }
    }
    
    // Fighting state
    public static void Fight(Enemy enemy, Random rnd) {
        Console.WriteLine("Uh-oh, you've encountered a {0}!", enemy.Name);
        Console.WriteLine("It has {0} hp, deals somewhere around {1} damage", enemy.Health, enemy.Damage);
        Console.WriteLine("Blocks {0} damage, but reward is {1} gold", enemy.Armor, enemy.Reward);
        Console.WriteLine("The battle begins!");

        while (true) {
            Console.WriteLine("What will be your next move?");
            Console.WriteLine("You have {0} hp left, your armor blocks {1} damage, your weapon deals {2} damage",
                Player.Health, (int)Player.Armor, (int)Player.Weapon);
            Console.WriteLine("1. Attack!");
            Console.WriteLine("0. Retreat! (20% chance to escape)");

            int choice = -1;
            try {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
            }

            switch (choice) {
                case 1:
                    int damage = (int)Player.Weapon  + rnd.Next((int)(-(int)Player.Weapon / 7), (int)((int)Player.Weapon / 5));
                    Console.WriteLine("You charge at enemy dealing {0} damage! And...", damage);
                    enemy.Health -= damage;
                    if (enemy.Health <= 0 ) {
                        Console.WriteLine("...the enemy is dead! Battle successful!");
                        Reward(enemy);
                        return;
                    }
                    Console.WriteLine("...the enemy is still standing with {0} hp! Battle goes on!", enemy.Health);
                    EnemyAttack(enemy, rnd);
                    break;
                case 0:
                    Console.WriteLine("You try to escape! You have 20% chance to escape!");
                    int chance = rnd.Next(1, 5);

                    if (chance == 1) {
                        Console.WriteLine("Success!");
                        return;
                    } else {
                        Console.WriteLine("Fail! Well at least you tried...");
                    }

                    EnemyAttack(enemy, rnd);
                    break;
                default:
                    Console.WriteLine("Try again!");
                    break;
            }
        }
    }

    // Enemy / Player attacks
    static void EnemyAttack(Enemy enemy, Random rnd) {
        int damage = enemy.Damage + rnd.Next((int)(-enemy.Damage / 10), (int)(enemy.Damage / 10));
        Console.WriteLine("Enemy charges at you and deals {0} damage! And... ", damage);
        Player.Health -= damage;
        if (Player.Health <= 0) {
            Console.WriteLine("... you died.");
            System.Environment.Exit(0);
        } else {
            Console.WriteLine("... you are still standing! With {0} hp left", Player.Health);
        }
    }

    // Reward for winning fight
    static void Reward(Enemy enemy) {
        Console.WriteLine("After your victory, you got {0} gold!", enemy.Reward);
        Player.Money += enemy.Reward;
        Console.WriteLine("You return back to city.");
    }
}