using System.Data.Common;
using System.Data.SqlTypes;

namespace FirstThing.RPG; 

public static class RPG {
    // enums for weapons/armors etc.
    public enum Weapons {
        WoodenSword = 5,
        BronzeSword = 7,
        SilverSword = 14,
        GoldSword = 20,
        DiamondSword = 30,
        DragonSword = 50,
        Fish = 99999999,
    }
    
    public enum Armors {
        WoodenArmor = 5,
        BronzeArmor = 7,
        SilverArmor = 13,
        GoldArmor = 17,
        DiamondArmor = 20,
        DragonArmor = 35,
        Bucket = 99999999,
    }

    public enum Potions {
        HealingPotion,
        DamagePotion,
        ArmorPotion,
        RetreatPotion,
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
        Console.WriteLine("2. Into catacombs");
        Console.WriteLine("3. Challenge the dragon!");
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
            case 2:
                Catacombs.BeginFight();
                break;
            case 3:
                Dragon.BeginFight();
                break;
        }
    }
    
    // Fighting state
    public static void Fight(Enemy enemy, Random rnd) {
        Console.WriteLine("Uh-oh, you've encountered a {0}!", enemy.Name);
        Console.WriteLine("It has {0} hp, deals somewhere around {1} damage", enemy.Health, enemy.Damage);
        Console.WriteLine("Blocks {0} damage, but reward is {1} gold", enemy.Armor, enemy.Reward);
        Console.WriteLine("The battle begins!");

        int healingPotions = 0; int damagePotions = 0;
        int armorPotions = 0;   int retreatPotions = 0;
        int addDamage = 0;      int addArmor = 0;
        
        // check for potions
        foreach (var potion in Player.PotionsList) {
            switch (potion) {
                case Potions.HealingPotion:
                    healingPotions++;
                    break;
                case Potions.DamagePotion:
                    damagePotions++;
                    break;
                case Potions.ArmorPotion:
                    armorPotions++;
                    break;
                case Potions.RetreatPotion:
                    retreatPotions++;
                    break;
            }
        }
        
        while (true) {
            Console.WriteLine("What will be your next move?");
            Console.WriteLine("You have {0} hp left, your armor blocks {1} damage, your weapon deals {2} damage",
                Player.Health, (int)Player.Armor, (int)Player.Weapon);
            Console.WriteLine("You have {0} damage from potions and {1} armor from potions", addDamage, addArmor);
            Console.WriteLine("1. Attack!");
            Console.WriteLine("2. Use a potion!");
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
                    // attack is little randomized, in favor of more damage
                    int damage = (int)Player.Weapon + addDamage + rnd.Next((int)(-(int)Player.Weapon / 7), (int)((int)Player.Weapon / 5)) - enemy.Armor;
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine("You charge at enemy dealing {0} damage! And...", damage);
                    enemy.Health -= damage;
                    if (enemy.Health <= 0 ) {
                        Console.WriteLine("...the enemy is dead! Battle successful!");
                        Reward(enemy);
                        return;
                    }
                    Console.WriteLine("...the enemy is still standing with {0} hp! Battle goes on!", enemy.Health);
                    EnemyAttack(enemy, rnd, addArmor);
                    break;
                case 2:
                    //potions
                    Console.WriteLine("What potion will you use?");
                    Console.WriteLine("1. Healing (+50hp)");
                    Console.WriteLine("2. Damage (+20dmg for this fight)");
                    Console.WriteLine("3. Armor (+15arm for this fight)");
                    Console.WriteLine("4. Retreat (100% run)");
                    Console.WriteLine("0. Go back");
                    
                    choice = 0;
                    try {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e) {
                        Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
                    }

                    switch (choice) {
                        case 1:
                            if (healingPotions > 0) {
                                healingPotions--;
                                Player.PotionsList.Remove(Potions.HealingPotion);
                                Player.Health += 50;
                                Console.WriteLine("You healed for 50hp");
                            } else {
                                Console.WriteLine("You dont have any potions of this type!");
                                break;
                            }

                            EnemyAttack(enemy, rnd, addArmor);
                            break;
                        case 2:
                            if (damagePotions > 0) {
                                damagePotions--;
                                Player.PotionsList.Remove(Potions.DamagePotion);
                                addDamage += 20;
                                Console.WriteLine("You feel stronger!");
                            } else {
                                Console.WriteLine("You dont have any potions of this type!");
                                break;
                            }

                            EnemyAttack(enemy, rnd, addArmor);
                            break;
                        case 3:
                            if (armorPotions > 0) {
                                armorPotions--;
                                Player.PotionsList.Remove(Potions.ArmorPotion);
                                addArmor += 15;
                                Console.WriteLine("You feel tankier!");
                            } else {
                                Console.WriteLine("You dont have any potions of this type!");
                                break;
                            }

                            EnemyAttack(enemy, rnd, addArmor);
                            break;
                        case 4:
                            if (retreatPotions > 0) {
                                Player.PotionsList.Remove(Potions.RetreatPotion);
                                Console.WriteLine("You disappeared from this battle!");
                                return;
                            }

                            Console.WriteLine("You dont have any potions of this type!");
                            break;
                    }
                    break;
                case 0:
                    //you have 25% chance to run away
                    Console.WriteLine("You try to escape! You have 25% chance to escape!");
                    int chance = rnd.Next(1, 4);

                    if (chance == 1) {
                        Console.WriteLine("Success!");
                        return;
                    }
                    Console.WriteLine("Fail! Well at least you tried...");
                    EnemyAttack(enemy, rnd, addArmor);
                    break;
                default:
                    Console.WriteLine("Try again!");
                    break;
            }
        }
    }

    // Enemy attack
    static void EnemyAttack(Enemy enemy, Random rnd, int addArmor) {
        // enemy attacks are randomized less
        int damage = enemy.Damage + rnd.Next((int)(-enemy.Damage / 10), (int)(enemy.Damage / 10)) - (int)Player.Armor - addArmor;
        // enemy cant deal <0 damage
        if (damage < 0)
            damage = 0;
        Console.WriteLine("Enemy charges at you and deals {0} damage! And... ", damage);
        Player.Health -= damage;
        if (Player.Health <= 0) {
            Console.WriteLine("... you died.");
            // this is one life game, definitely not being lazy to write dead state :)
            Environment.Exit(0);
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