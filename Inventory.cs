using System;
using System.IO;
using System.Collections.Generic;

public class Inventory{
    static string answer = "";

    static public void actionInventory(){
        bool ongoing = true;
        while (ongoing == true){
            drawInventory();
            int openedInventory = valueConvert.StrToInt(Console.ReadLine());
            if(openedInventory>5 || openedInventory<1){                    
                Console.WriteLine("Go back? y/n");
                answer = Console.ReadLine().ToLower();
                if(answer == "y" || answer == "yes"){
                    ongoing=false;
                }
            }
            Console.Clear();
            switch (openedInventory){
                case 1:
                    actionWeaponsInventory();
                    break;
            } 
        }
    }

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
        Console.WriteLine();
    }

    static public void actionWeaponsInventory(){
        bool ongoing = true;
        while(ongoing == true){
            wepInv:
            Console.Clear();
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("|     --=Weapons Inventory=--     |");
            Console.WriteLine("|     -----------------------     |");
            Console.WriteLine("|        -Equiped Weapons-        |");
            for(int i = 0; i < 2; i++){
                string linefiller = "                                 ";
                linefiller = linefiller.Substring(0, 16 - InventoryLists.FetchWeaponName(i).Length);
                Console.WriteLine($"| Weapons slot {i+1}: {InventoryLists.FetchWeaponName(i)}{linefiller}|");
            }
            Console.WriteLine("|     -----------------------     |");
            Console.WriteLine("|       -UnEquiped Weapons-       |");
            for(int i = 0; i < 5; i++){
                string linefiller = "                                 ";
                linefiller = linefiller.Substring(0, 16 - InventoryLists.FetchWeaponName(i+2).Length);  //Changes the linefiller so that the window 
                Console.WriteLine($"| Weapons slot {i+1}: {InventoryLists.FetchWeaponName(i+2)}{linefiller}|"); // is the correct witdth, like i did with FightingStyles
            }
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("");
            Console.WriteLine("         Change Weapon? y/n");
            answer = Console.ReadLine().ToLower();
            Console.WriteLine();
            if(answer == "y" || answer =="yes"){  
                wepChg:                                                 //Let's you change equipped weapon
                Console.Clear();
                int temp = 0;       //Used to know what weapon slot is gonna change
                Console.WriteLine("+------------=========------------+");       // during the change since i'll be 
                Console.WriteLine("|       -=Equiped Weapons=-       |");       // overwriting the old one
                for(int i = 0; i < 2; i++){
                    string linefiller = "                                 ";        //Change window lenght to something bigger
                    linefiller = linefiller.Substring(0, 16 - InventoryLists.FetchWeaponName(i).Length);
                    Console.WriteLine($"| Weapons slot {i+1}: {InventoryLists.FetchWeaponName(i)}{linefiller}|");
                }
                Console.WriteLine("+------------=========------------+");
                Console.WriteLine();
                Console.WriteLine("What weapon do you want to change?");
                Console.WriteLine();
                temp = valueConvert.StrToInt(Console.ReadLine());               // Input from user, what weapon slot to change
                if(temp!=1 && temp !=2){                    
                    Console.WriteLine("Go back? y/n");
                    answer = Console.ReadLine().ToLower();
                    if(answer == "y" || answer == "yes"){
                        goto wepInv;
                    } else if (answer == "n" || answer == "no"){
                        goto wepChg;
                    }
                }else{
                    Console.WriteLine("+------------=========------------+");       //Choosig what weapon to switch to.
                    Console.WriteLine("|      -=UnEquiped Weapons=-      |");       
                    for(int i = 0; i < 5; i++){
                        string linefiller = "                                 ";        
                        linefiller = linefiller.Substring(0, 16 - InventoryLists.FetchWeaponName(i+2).Length);
                        Console.WriteLine($"| Weapons slot {i+1}: {InventoryLists.FetchWeaponName(i+2)}{linefiller}|");
                    }
                    Console.WriteLine("+------------=========------------+");
                    Console.WriteLine();
                    Console.WriteLine("    What weapon do you want to");
                    Console.WriteLine("            switch to?");
                    Console.WriteLine();
                    int[] temp2 = new int[3];
                    temp2[1] = valueConvert.StrToInt(Console.ReadLine());
                    if(temp2[1] == 0 || temp2[1] > 5){
                        Console.WriteLine("Go back? y/n");
                        answer = Console.ReadLine().ToLower();
                        if(answer == "y" || answer == "yes"){
                            goto wepInv;
                        } else if (answer == "n" || answer == "no"){
                            Console.Clear();
                            goto wepChg;
                        }
                    } else {
                        temp2[0]=temp-1;
                        temp2[1]++;
                        temp2[2]=InventoryLists.weaponInventory[temp2[0]];
                        InventoryLists.weaponInventory[temp2[0]]=InventoryLists.weaponInventory[temp2[1]];
                        InventoryLists.weaponInventory[temp2[1]]=temp2[2];
                    }
                }
            } else {
                Console.WriteLine("Go back? y/n");
                answer = Console.ReadLine().ToLower();
                if(answer == "y" || answer == "yes"){
                    ongoing = false;
                } else if (answer == "n" || answer == "no"){
                    goto wepInv;
                }              
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