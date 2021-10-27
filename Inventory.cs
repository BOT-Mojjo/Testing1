using System;
using System.IO;
using System.Collections.Generic;

public class Inventory{
    static void drawInventory(){
        string tempCoins = player.coins.ToString();
        while (tempCoins.Length < 4){
            tempCoins = tempCoins.Insert(0, "0");
        }
        Console.WriteLine("+-------------------------+");
        Console.WriteLine("|    --==Inventory==--    |");
        Console.WriteLine("|  1:Weapons    2:Armour  |");
        Console.WriteLine("|  3:Consumables          |");
        Console.WriteLine("|  4:Miscellaneous        |");
        Console.WriteLine("|  5:Magicks  Coins:" + tempCoins + "  |");
        Console.WriteLine("+-------------------------+");
    }

    static public void actionInventory(){
        bool ongoing = true;
        while (ongoing == true){
            int openedInventory = valueConvert.StrToInt(Console.ReadLine());
            switch (openedInventory){
                case 0:
                    drawInventory();
                    break;

                case 1:
                    actionWeaponsInvenotry();
                    break;
            }
        }
    }

    static void actionWeaponsInvenotry(){
        while(true){
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("|  -=Weapons Inventory=-  |");
            Console.WriteLine("|                         |");
            for(int i = 0; i < 2; i++){

                Console.WriteLine($"| Weapon slot{i+1}: {i}");
            }
        }
    }
}

public class InventoryLists{
    static public void inventorySetup(){
        //Weaponry Setup
        string[] equipmentDbString = File.ReadAllLines(@"Weaponry.txt"); //loading ALL Weapons data into a variable

        List<MeleeWeapon> weapons = new List<MeleeWeapon>();

        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                string[] weaponData = line.Split('|');

                weapons.Add(new MeleeWeapon() {
                    name = weaponData[0],
                    dmg = int.Parse(weaponData[1]),
                    AcModifier = int.Parse(weaponData[2]),

                });
            }
        }
    }
}