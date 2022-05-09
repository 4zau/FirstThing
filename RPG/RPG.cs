using System.Data.Common;
using System.Data.SqlTypes;

namespace FirstThing.RPG; 

public class RPG {

    public enum Weapons {
        Nothing = 0,
        WoodenSword = 5,
        BronzeSword = 7,
        SilverSword = 14,
        Fish = 99999999
    }
    
    int[] weaponPrices = new [] {1, 100, 200, 300};
    
    public enum Armors {
        Nothing = 0,
        WoodenArmor = 3,
        BronzeArmor = 5,
        SilverArmor = 10,
        Bucket = 99999999
    }
    
    int[] armorPrices = new [] {1, 50, 150, 400};
    
    static Player player = new Player();
    public static void Execute() {
        Console.WriteLine("Welcome, adventurer!");
        while (true) {
            Console.WriteLine("What will you do next?");
            Console.WriteLine("hint: better go to store and get some weapon, otherwise you have 0 chances");
            Console.WriteLine("1. Go out of the city");
            Console.WriteLine("2. Check out local shop");
            Console.WriteLine("0. Suicide");
            
            int choice = int.Parse(Console.ReadLine());
            switch (choice) {
                case 1:
                    Outside();
                    break;
                case 2:
                    Shop();
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

    static void Outside() {
        Console.WriteLine("You are standing at gates.");
        Console.WriteLine("Where exactly you wish to go?");
        Console.WriteLine("1. Into forest");
        
        Console.WriteLine("0. Go back");
        
        int choice = int.Parse(Console.ReadLine());
        switch (choice) {
            case 1:
                player.Health = -1;
                break;
            default:
                Console.WriteLine("Try again");
                break;
        }
    }

    static void Shop() {
        Console.WriteLine("As you step into a door, a voice greets you:");
        Console.WriteLine("'Welcome, Stranger!'");
        Console.WriteLine("'What brought you here? Weapons? Armor?'");
        Console.WriteLine("1. Weapons");
        Console.WriteLine("2. Armor");
        int choice = int.Parse(Console.ReadLine());
        switch (choice) {
            case 1:
                
                break;
            case 2:
                
                break;
            case 0:
                Console.WriteLine("Saying goodbye, you leave this place");
                return;
            default:
                Console.WriteLine("Try again");
                break;
        }
    }
}