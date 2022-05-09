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
                
                break;
        }
    }

    
}