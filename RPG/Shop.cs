namespace FirstThing.RPG; 

public class Shop {
    
    // Prices
    static readonly int[] _weaponPrices = new [] {1, 100, 200, 300, 700, 2000};
    static readonly int[] _armorPrices = new [] {1, 50, 150, 400, 1000, 2200};
    static readonly int[] _potionPrices = new[] {200, 300, 300, 100};
    
    // choose category
    public static void Begin() {
        while (true) {
            Console.WriteLine("As you step into a door, a voice greets you:");
            Console.WriteLine("'Welcome, Stranger!'");
            Console.WriteLine("'What brought you here? Weapons? Armor?'");
            Console.WriteLine("1. I need weapons");
            Console.WriteLine("2. I need armor");
            Console.WriteLine("3. I need potions");
            Console.WriteLine("0. Leave.");
            int choice = -1;
            try {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
            }
            switch (choice) {
                case 1:
                    ShopWeapons();
                    break;
                case 2:
                    ShopArmor();
                    break;
                case 3:
                    ShopPotions();
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
    
    // shop for weapons
    static void ShopWeapons() {
        Console.WriteLine("Here's what i've got:");
        Console.WriteLine("1. WoodenSword, price: {0}", _weaponPrices[0]);
        Console.WriteLine("2. BronzeSword, price: {0}", _weaponPrices[1]);
        Console.WriteLine("3. SilverSword, price: {0}", _weaponPrices[2]);
        Console.WriteLine("4. GoldSword, price: {0}", _weaponPrices[3]);
        Console.WriteLine("5. DiamondSword, price: {0}", _weaponPrices[4]);
        Console.WriteLine("6. DragonSword, price: {0}", _weaponPrices[5]);
        Console.WriteLine("0 (or anything). No");
        Console.WriteLine("Something caught your eye? (your money: {0})", Player.Money);
        int choice = 0;
        try {
            choice = int.Parse(Console.ReadLine());
        }
        catch (Exception e) {
            Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
        }
        switch (choice) {
            case 1:
                Buy(RPG.Weapons.WoodenSword, _weaponPrices[0]);
                break;
            case 2:
                Buy(RPG.Weapons.BronzeSword, _weaponPrices[1]);
                break;
            case 3:
                Buy(RPG.Weapons.SilverSword, _weaponPrices[2]);
                break;
            case 4:
                Buy(RPG.Weapons.GoldSword, _weaponPrices[3]);
                break;
            case 5:
                Buy(RPG.Weapons.DiamondSword, _weaponPrices[4]);
                break;
            case 6:
                Buy(RPG.Weapons.DragonSword, _weaponPrices[5]);
                break;
            default:
                Console.WriteLine("No.");
                break;
        }
    }
    
    // shop for armors
    static void ShopArmor() {
        Console.WriteLine("Here's what i've got:");
        Console.WriteLine("1. WoodenArmor, price: {0}", _armorPrices[0]);
        Console.WriteLine("2. BronzeArmor, price: {0}", _armorPrices[1]);
        Console.WriteLine("3. SilverArmor, price: {0}", _armorPrices[2]);
        Console.WriteLine("4. GoldArmor, price: {0}", _armorPrices[3]);
        Console.WriteLine("5. DiamondArmor, price: {0}", _armorPrices[4]);
        Console.WriteLine("6. DragonArmor, price: {0}", _armorPrices[5]);
        Console.WriteLine("0 (or anything). No");
        Console.WriteLine("Something caught your eye? (your money: {0})", Player.Money);
        int choice = 0;
        try {
            choice = int.Parse(Console.ReadLine());
        }
        catch (Exception e) {
            Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
        }
        switch (choice) {
            case 1:
                Buy(RPG.Armors.WoodenArmor, _armorPrices[0]);
                break;
            case 2:
                Buy(RPG.Armors.BronzeArmor, _armorPrices[1]);
                break;
            case 3:
                Buy(RPG.Armors.SilverArmor, _armorPrices[2]);
                break;
            case 4:
                Buy(RPG.Armors.GoldArmor, _armorPrices[3]);
                break;
            case 5:
                Buy(RPG.Armors.DiamondArmor, _armorPrices[4]);
                break;
            case 6:
                Buy(RPG.Armors.DragonArmor, _armorPrices[5]);
                break;
            default:
                Console.WriteLine("No.");
                break;
        }
    }

    static void ShopPotions() {
        Console.WriteLine("Here's what i've got:");
        Console.WriteLine("1. HealingPotion (+50hp), price: {0}", _potionPrices[0]);
        Console.WriteLine("2. DamagePotion (+20dmg for 1 fight), price: {0}", _potionPrices[1]);
        Console.WriteLine("3. ArmorPotion (+15arm for 1 fight), price: {0}", _potionPrices[2]);
        Console.WriteLine("4. RetreatPotion (100% run), price: {0}", _potionPrices[3]);
        Console.WriteLine("0 (or anything). No.");
        Console.WriteLine("Something caught your eye? (your money: {0})", Player.Money);
        int choice = 0;
        try {
            choice = int.Parse(Console.ReadLine());
        }
        catch (Exception e) {
            Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
        }
        switch (choice) {
            case 1:
                Buy(RPG.Potions.HealingPotion, _potionPrices[0]);
                break;
            case 2:
                Buy(RPG.Potions.DamagePotion, _potionPrices[1]);
                break;
            case 3:
                Buy(RPG.Potions.ArmorPotion, _potionPrices[2]);
                break;
            case 4:
                Buy(RPG.Potions.RetreatPotion, _potionPrices[3]);
                break;
            default:
                Console.WriteLine("No.");
                break;
        }
    }
    
    // buy a weapon
    static void Buy(RPG.Weapons item, int cost) {
        if (Player.Money < cost) {
            Console.WriteLine("Check your purse");    
        } else if (Player.Weapon == item) {
            Console.WriteLine("You already have this");
        } else {
            Player.Money -= cost;
            Player.Weapon = item;
        }
        Console.WriteLine("Deal! You know own this weapon!");
    }
    
    // buy a armor
    static void Buy(RPG.Armors item, int cost) {
        if (Player.Money < cost) {
            Console.WriteLine("Check your purse");    
        } else if (Player.Armor == item) {
            Console.WriteLine("You already have this");
        } else {
            Player.Money -= cost;
            Player.Armor = item;
        }
        Console.WriteLine("Deal! You know own this armor!");
    }
    
    static void Buy(RPG.Potions item, int cost) {
        if (Player.Money < cost) {
            Console.WriteLine("Check your purse");
        } else {
            Player.Money -= cost;
            Player.PotionsList.Add(item);
        }
        Console.WriteLine("Deal! You know own this potion!");
    }
}