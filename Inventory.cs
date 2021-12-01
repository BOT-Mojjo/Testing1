using System;
using System.IO;
using System.Collections.Generic;

public class Inventory{
    static string answer = "";
    static bool acted = false;

    static public void actionInventory(){
        bool ongoing = true;
        while (ongoing == true){
            Console.Clear();
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
                case 2:
                    actionArmourInventory();
                    break;
                case 3:
                    actionPotionsInventory();
                    break;
            } 
        }
    }

    static void drawInventory(){
        string tempCoins = player.coins.ToString();
        while (tempCoins.Length < 4){
            tempCoins = tempCoins.Insert(0, "0");
        }
        Console.WriteLine("+------------=========------------+");
        Console.WriteLine("|        --==Inventory==--        |");
        Console.WriteLine("|     1:Weapons     2:Armour      |");
        Console.WriteLine("|   3:Potions  4:Miscellaneous    |");
        Console.WriteLine("|   5:Magicks      Coins: " + tempCoins + "    |");
        Console.WriteLine("+------------=========------------+");
        Console.WriteLine();
            }

    static void actionWeaponsInventory(){
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
            Console.WriteLine();
            answer = Console.ReadLine().ToLower();
            if(answer == "y" || answer =="yes"){  
                if(acted == true && Fight.ongoing == true){
                    Console.Clear();
                    Console.WriteLine("You've already used the inventory this turn.");
                    Console.WriteLine("         Your time is running out.");
                    Console.ReadLine();
                } else {
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
                        } else {
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
                            } else {
                                Console.Clear();
                                goto wepChg;
                            }
                        } else {
                            temp2[0]=temp-1;
                            temp2[1]++;
                            temp2[2]=InventoryLists.weaponInventory[temp2[0]];
                            InventoryLists.weaponInventory[temp2[0]]=InventoryLists.weaponInventory[temp2[1]];
                            InventoryLists.weaponInventory[temp2[1]]=temp2[2];
                            acted=true;
                        }
                    }
                }
            } else {
                Console.WriteLine("Go back? y/n");
                answer = Console.ReadLine().ToLower();
                if(answer == "y" || answer == "yes"){
                    ongoing = false;
                }        
            }
        }
    }


    static void actionArmourInventory(){
        if(Fight.ongoing==true){
            Console.WriteLine();
            Console.WriteLine("You're in a fight, trying to change armour could be fatal.");
            Console.ReadLine();
        } else{
            bool ongoing = true;
            while(ongoing==true){
                Console.Clear();  
                Console.WriteLine("+------------=========------------+");
                Console.WriteLine("|     --=Armours Inventory=--     |");
                if(true){                                                     // to make the variable "linefiller" local
                    string linefiller = "                                 ";        
                    linefiller = linefiller.Substring(0, 16 - InventoryLists.FetchArmourName(0).Length);      //2nd number is linefiller length - what is already there
                    Console.WriteLine($"| Equiped Armour: {InventoryLists.FetchArmourName(0)}{linefiller}|");
                    linefiller = "                                 ";        
                    linefiller = linefiller.Substring(0, 18 - InventoryLists.FetchArmourName(1).Length);
                    Console.WriteLine($"| Spare Armour: {InventoryLists.FetchArmourName(1)}{linefiller}|");
                }
                Console.WriteLine("+------------=========------------+");
                Console.WriteLine("        Change Armour? y/n");
                Console.WriteLine();
                answer=Console.ReadLine().ToLower();
                if(answer == "y" || answer == "yes"){
                    int[] temp = new int[3];
                    for(int i = 0; i < 3; i++){        //Switches the data places around for the armour
                        temp[i]=InventoryLists.armourInventory[0,i];
                        InventoryLists.armourInventory[0,i]=InventoryLists.armourInventory[1,i];
                        InventoryLists.armourInventory[1,i]=temp[i];
                    }
                } else {
                   Console.WriteLine("Go back? y/n");
                    answer = Console.ReadLine().ToLower();
                    if(answer == "y" || answer == "yes"){
                        ongoing = false;
                    }
                }
            }
        }
    }


    static void actionPotionsInventory(){
        bool ongoing = true;
        while(ongoing == true){
            Console.Clear();
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("|        --=Potion Belt=--        |");
            for(int i = 0; i < 7; i++){
                string linefiller = "                                 ";
                linefiller = linefiller.Substring(0, 17 - InventoryLists.FetchPotionName(i,InventoryLists.potionInventory[i,1]).Length);
                Console.WriteLine($"| Potion slot {i+1}: {InventoryLists.FetchPotionName(i,InventoryLists.potionInventory[i,1])}{linefiller}|");
            }
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("   'Move' to move potions around");
            Console.WriteLine("       'Use' to use a potion");
            Console.WriteLine();
            Console.Write("               ");
            answer=Console.ReadLine().ToLower();
            if(answer == "move"){
                int[] temp = new int[4];
                Console.Clear();
                Console.WriteLine("+------------=========------------+");
                Console.WriteLine("|        --=Potion Belt=--        |");
                for(int i = 0; i < 7; i++){
                    string linefiller = "                                 ";
                    linefiller = linefiller.Substring(0, 17 - InventoryLists.FetchPotionName(i,InventoryLists.potionInventory[i,1]).Length);
                    Console.WriteLine($"| Potion slot {i+1}: {InventoryLists.FetchPotionName(i,InventoryLists.potionInventory[i,1])}{linefiller}|");
                }
                Console.WriteLine("+------------=========------------+");
                Console.WriteLine();
                Console.WriteLine("            Move Potion");
                Console.Write("                 ");
                temp[0]=valueConvert.StrToInt(Console.ReadLine())-1;
                Console.WriteLine("              To Slot");
                Console.Write("                 ");
                temp[1]=valueConvert.StrToInt(Console.ReadLine())-1;
                temp[2]=InventoryLists.potionInventory[temp[0],0];  //puts pot 1 into temp storage
                temp[3]=InventoryLists.potionInventory[temp[0],1];
                InventoryLists.potionInventory[temp[0],0] = InventoryLists.potionInventory[temp[1],0]; //moves pot 2 into pot 1s old place
                InventoryLists.potionInventory[temp[0],1] = InventoryLists.potionInventory[temp[1],1];
                InventoryLists.potionInventory[temp[1],0] = temp[2];  // moves pot 1 from storage int pot 2s old place
                InventoryLists.potionInventory[temp[1],1] = temp[3];


            } else if(acted == true && answer=="use" && Fight.ongoing == true){
                Console.Clear();
                Console.WriteLine("You've already used the inventory this turn.");
                Console.WriteLine("         Your time is running out.");
                Console.ReadLine();
            } else if(answer == "use"){   // using potions
                bool ongoing1 = true;
                while(ongoing1 == true){
                    Console.Clear();
                    Console.WriteLine("+------------=========------------+");
                    Console.WriteLine("|  --=What potion do you Use?=--  |");
                    for(int i = 0; i < 7; i++){
                        string linefiller = "                                 ";
                        linefiller = linefiller.Substring(0, 17 - InventoryLists.FetchPotionName(i,InventoryLists.potionInventory[i,1]).Length);
                        Console.WriteLine($"| Potion slot {i+1}: {InventoryLists.FetchPotionName(i,InventoryLists.potionInventory[i,1])}{linefiller}|");
                    }
                    Console.WriteLine("+------------=========------------+");
                    Console.WriteLine();
                    Console.Write("                 ");
                    int potionUsed = valueConvert.StrToInt(Console.ReadLine());
                    if(potionUsed>0 && potionUsed<8){  //a potion is used
                        potionUsed--; //nudges the variable so it lines up with the array, since it starts at 0 and the meny at 1.
                        if(InventoryLists.FetchPotionName(potionUsed,InventoryLists.potionInventory[potionUsed,1])=="Empty"){
                            Console.WriteLine("That vial is empty.");
                            Console.ReadLine();
                        } else {
                            int temp2;
                            switch(InventoryLists.potionInventory[potionUsed,1]){  //differentiates what happens based on potion type
                                case 0:
                                    temp2 = player.health;
                                    player.health = player.health + InventoryLists.FetchHealpotAmount(potionUsed);
                                    if(player.health>player.maxHealth){
                                        player.health=player.maxHealth;
                                    }
                                    temp2 = player.health - temp2;
                                    Console.WriteLine("You Regained "+temp2+"Hp!");
                                    break;
                                case 1:
                                    temp2 = player.mana;
                                    player.mana = player.mana + InventoryLists.FetchManapotAmount(potionUsed);
                                    if(player.mana>player.maxMana){
                                        player.mana=player.maxMana;
                                    }
                                    temp2 = player.mana - temp2;
                                    Console.WriteLine("Your Replenished "+temp2+"Mp!");
                                    break;
                                case 2:
                                    int[] temp3 = new int[2];
                                    temp3 = InventoryLists.FetchBuffPotEffect(potionUsed);
                                    player.atkBuff = player.atkBuff+temp3[0];
                                    player.defBuff = player.defBuff+temp3[1];
                                    Console.WriteLine("You feel strength surge through you.");
                                    break;
                                default:   //Only fires if there is a potion with a type outside of the Health/Mana/Buff Trifecta, and the array doesn't spit out a failure
                                    Console.WriteLine("  Error: Potion type Corrupted/Manipulated.");  //Honsetly this is just a failsafe and i don't see how this could ever occur
                                    Console.WriteLine("          Potion has been removed.");
                                    Console.WriteLine();
                                    Console.WriteLine("Some enteties in this game are really fragile.");
                                    Console.WriteLine("Therefore when modifying the game files please");
                                    Console.WriteLine("                  be careful.");
                                    break;
                            }
                            InventoryLists.potionInventory[potionUsed,0] = 0;  //Removes the potion from the inventory
                            InventoryLists.potionInventory[potionUsed,1] = 0;
                            Console.ReadLine();
                            acted=true;
                            ongoing1=false;
                        } 
                    } else {
                        ongoing1=false;
                        Console.WriteLine("Go back? y/n");
                        answer = Console.ReadLine().ToLower();
                        if(answer == "y" || answer == "yes"){
                            ongoing1 = false;
                        } else {

                        }
                    }
                }
            } else {
                Console.WriteLine("Go back? y/n");
                answer = Console.ReadLine().ToLower();
                if(answer == "y" || answer == "yes"){
                    ongoing = false;
                }
            }
        }
    }
}

public class InventoryLists{
    static public int[] weaponInventory = new int[7];            //Actual weapon inventory
    static List<MeleeWeapon> weapons = new List<MeleeWeapon>();  //Acts as a database fromwhere to draw weapon stats
    
    static public int[,] armourInventory = new int[2,3];
    static List<Armour> armour = new List<Armour>();

    static public int[,] potionInventory = new int[7,2];
    static List<healingItem> healingItem = new List<healingItem>();
    static List<manaItem> manaItem = new List<manaItem>();
    static List<buffItem> buffItem = new List<buffItem>();
    
    static public string FetchWeaponName(int InventoryID){
        return weapons[weaponInventory[InventoryID]].name;
    }
    static public string FetchArmourName(int InventoryID){
        return armour[armourInventory[InventoryID,0]].name;
    }
    static public string FetchPotionName(int InventoryID,int type){
        switch(type){
            case 0:
                return healingItem[potionInventory[InventoryID,0]].name;
            case 1:
                return manaItem[potionInventory[InventoryID,0]].name;
            case 2:
                return manaItem[potionInventory[InventoryID,0]].name;
            default:
                return "PotionName";
        }
    }
    static public int FetchHealpotAmount(int InventoryID){
        return healingItem[potionInventory[InventoryID,0]].healing;
    }
    static public int FetchManapotAmount(int InventoryID){
        return manaItem[potionInventory[InventoryID,0]].manaReplenished;
    }
    static public int[] FetchBuffPotEffect(int InventoryID){
        int[] temp = new int[2];
        temp[0] = buffItem[potionInventory[InventoryID,0]].atkEffect;
        temp[1] = buffItem[potionInventory[InventoryID,0]].defEffect;
        return temp;
    }
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
        //armour

        equipmentDbString = File.ReadAllLines(@"Armour.txt"); //loading ALL of Armour data into a variable
        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                string[] data = line.Split('|');

                armour.Add(new Armour() {
                    name = data[0],
                    AC = int.Parse(data[1]),
                    dodge = int.Parse(data[2]),
                    def = int.Parse(data[3]),
                    cost = int.Parse(data[6])
                });
            }
        }
        armourInventory[0,0]=1;
        armourInventory[0,1]=20;
        armourInventory[0,2]=1;
        //Potions

        equipmentDbString = File.ReadAllLines(@"Potions.txt"); //loading ALL of Armour data into a variable
        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                if(line[0]=='h'){
                    string[] data = line.Split('|');

                    healingItem.Add(new healingItem() {
                        name = data[1],
                        healing = int.Parse(data[2]),
                        cost = int.Parse(data[3])
                    });
                }
                if(line[0]=='m'){
                    string[] data = line.Split('|');

                    manaItem.Add(new manaItem() {
                        name = data[1],
                        manaReplenished = int.Parse(data[2]),
                        cost = int.Parse(data[3])
                    });
                }
                if(line[0]=='b'){
                    string[] data = line.Split('|');

                    buffItem.Add(new buffItem() {
                        name = data[1],
                        atkEffect = int.Parse(data[2]),
                        defEffect = int.Parse(data[3]),
                        cost = int.Parse(data[4])
                    });
                }
            }
        }
        potionInventory[0,0]=1; //*,0 is the id of the potion
        potionInventory[0,1]=3; //*,1 is the type of potion. 0 = healing, 1 = mana, 2 = buff.
        potionInventory[1,0]=1;
        potionInventory[0,1]=0;
        potionInventory[2,0]=0;
        potionInventory[2,1]=1;
    }
}