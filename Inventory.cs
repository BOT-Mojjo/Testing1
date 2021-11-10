using System;
using System.IO;
using System.Collections.Generic;

public class Inventory{
    static string answer = "";
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
                    actionWeaponsInventory();
                    break;
            }
        }
    }

    static public void actionWeaponsInventory(){
        while(true){
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("|     --=Weapons Inventory=--     |");
            Console.WriteLine("|     -----------------------     |");
            Console.WriteLine("|        -Equiped Weapons-        |");
            for(int i = 0; i < 2; i++){
                string linefiller = "                                 ";        //Change window lenght to something bigger
                linefiller = linefiller.Substring(0, 16 - InventoryLists.FetchWeaponName(i).Length);
                Console.WriteLine($"| Weapons slot {i+1}: {InventoryLists.FetchWeaponName(i)}{linefiller}|");
            }
            Console.WriteLine("|     -----------------------     |");
            Console.WriteLine("|       -UnEquiped Weapons-       |");
            for(int i = 0; i < 5; i++){
                string linefiller = "                                 ";        //Change window lenght to something bigger
                linefiller = linefiller.Substring(0, 16 - InventoryLists.FetchWeaponName(i+2).Length);
                Console.WriteLine($"| Weapons slot {i+1}: {InventoryLists.FetchWeaponName(i+2)}{linefiller}|");
            }
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("");
            Console.WriteLine("         Inspect Weapon? y/n");
            answer = Console.ReadLine().ToLower();
            if(answer == "y" || answer =="yes"){
                
            }


        }   
    }
}

public class InventoryLists{
    static public int[] weaponInventory = new int[7];
    static List<MeleeWeapon> weapons = new List<MeleeWeapon>();

    static public void inventorySetup(){
        //Weaponry Setup
        string[] equipmentDbString = File.ReadAllLines(@"Weaponry.txt"); //loading ALL Weapons data into a variable

        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                string[] weaponData = line.Split('|');

                weapons.Add(new MeleeWeapon() {
                    name = weaponData[0],
                    dmg = int.Parse(weaponData[1]),
                    AcModifier = int.Parse(weaponData[2]),
                    cost = int.Parse(weaponData[5])

                });
            }
        }
        weaponInventory[0] = 1;
        
    }
    static public string FetchWeaponName(int InventoryID){
        return weapons[weaponInventory[InventoryID]].name;
    }
}