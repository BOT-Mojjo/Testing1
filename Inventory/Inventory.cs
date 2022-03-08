using System;
using System.IO;
using System.Collections.Generic;

public class Inventory{
    static public int partyCoins = miscFunctions.genRandom.Next(5,15);
    string answer = "";
    bool acted = false;
    static public int windowWidth = 35;
    static public List<player> Characters = new List<player>();
    static public List<InventoryLists> InvLists = new List<InventoryLists>();

    public void actionInventory(int player){
        bool ongoing = true;
        while (ongoing == true){
            Console.Clear();
            drawInventory(player);
            int openedInventory = miscFunctions.StrToInt(Console.ReadLine());
            if(openedInventory>5 || openedInventory<1){                    
                ongoing = miscFunctions.GoBack(windowWidth);
            }
            Console.Clear();
            switch (openedInventory){
                case 1:
                    actionWeaponsInventory(player);
                    break;
                case 2:
                    actionArmourInventory(player);
                    break;
                case 3:
                    actionPotionsInventory(player);
                    break;
                case 4:
                    actionMiscellaneousInv(player);
                    break;
                case 5:
                    actionSpellInventory(player);
                    break;
            } 
        }
    }

    void drawInventory(int player){
        string tempCoins = partyCoins.ToString();
        while (tempCoins.Length < 5){
            tempCoins = tempCoins.Insert(0, "0");
        }
        miscFunctions.TextBox("(--==Inventory==--) 1:Weapons 2:Armour 3:Potions 4:Miscellaneous 5:Spells Coins:" + tempCoins, windowWidth, "equal");
        // miscFunctions.BoxLine("1:Weapons 2:Armour", windowWidth, "spread");
        // miscFunctions.BoxLine("3:Potions 4:Miscellaneous", windowWidth, "spread");
        // miscFunctions.BoxLine("5:Spells Coins:" + tempCoins, windowWidth, "spread");
        // miscFunctions.BoxBorder(windowWidth);
        // Console.WriteLine();
    }

    void actionWeaponsInventory(int player){
        bool ongoing = true;
        while(ongoing == true){
            Console.Clear();
            miscFunctions.BoxBorder(windowWidth);
            miscFunctions.BoxLine("--=Weapons Inventory=--", windowWidth, "equal");
            miscFunctions.BoxLine("-----------------------", windowWidth, "equal");
            miscFunctions.BoxLine("-Equiped Weapons-", windowWidth, "equal");
            for(int i = 0; i < 2; i++){
                miscFunctions.BoxLine($"Weapons slot {i+1}: {InvLists[player].FetchWeaponName(i)}", windowWidth);
            }
            miscFunctions.BoxLine("-----------------------", windowWidth, "equal");
            miscFunctions.BoxLine("-Unequiped Weapons-", windowWidth, "equal");
            for(int i = 0; i < 5; i++){
                miscFunctions.BoxLine($"Weapons slot {i+1}: {InvLists[player].FetchWeaponName(i+2)}", windowWidth);
            }
            miscFunctions.BoxBorder(windowWidth);
            Console.WriteLine();
            Console.WriteLine(miscFunctions.PadEqual("Change Weapon? y/n", windowWidth));
            Console.WriteLine();
            answer = Console.ReadLine().ToLower();
            if(answer == "y" || answer =="yes"){  
                if(acted == true && Fight.ongoing == true){
                    Console.Clear();
                    miscFunctions.TextBox("You've alredy Used the Inventory this turn. Your time is running out.", windowWidth);
                    // Console.WriteLine("You've already used the inventory this turn.");
                    // Console.WriteLine("         Your time is running out.");
                    Console.ReadLine();
                } else {
                    bool ongoing1  = true;
                    while(ongoing1){                                                 //Let's you change equipped weapon
                        Console.Clear();
                        int temp = 0;       //Used to know what weapon slot is gonna change
                        miscFunctions.BoxBorder(windowWidth);       // during the change since i'll be 
                        miscFunctions.BoxLine("-=Equiped Weapons=-", windowWidth, "equal");       // overwriting the old one
                        for(int i = 0; i < 2; i++){
                            miscFunctions.BoxLine($"Weapons slot {i+1}: {InvLists[player].FetchWeaponName(i)}", windowWidth);
                        }
                        miscFunctions.BoxBorder(windowWidth);
                        Console.WriteLine();
                        miscFunctions.BoxLine("What weapon do you want to change?", windowWidth, "equal");
                        Console.WriteLine();
                        temp = miscFunctions.StrToInt(Console.ReadLine());               // Input from user, what weapon slot to change
                        if(temp!=1 && temp !=2){                    
                            ongoing1 = miscFunctions.GoBack(windowWidth);
                        }else{
                            miscFunctions.BoxBorder(windowWidth);       //Choosig what weapon to switch to.
                            miscFunctions.BoxLine("-=UnEquiped Weapons=-", windowWidth, "equal");
                            for(int i = 0; i < 5; i++){
                                miscFunctions.BoxLine($"Weapons slot {i+1}: {InvLists[player].FetchWeaponName(i+2)}", windowWidth);
                            }
                            miscFunctions.BoxBorder(windowWidth);
                            Console.WriteLine();
                            miscFunctions.TextBox("What weapon do you want to switch to?", windowWidth);
                            // Console.WriteLine("    What weapon do you want to");
                            // Console.WriteLine("            switch to?");
                            Console.WriteLine();
                            int[] temp2 = new int[3];
                            temp2[1] = miscFunctions.StrToInt(Console.ReadLine());
                            if(temp2[1] == 0 || temp2[1] > 5){
                                ongoing1 = miscFunctions.GoBack(windowWidth);
                            } else {
                                temp2[0]=temp-1;
                                temp2[1]++;
                                temp2[2]=InvLists[player].weaponInventory[temp2[0]];
                                InvLists[player].weaponInventory[temp2[0]]=InvLists[player].weaponInventory[temp2[1]];
                                InvLists[player].weaponInventory[temp2[1]]=temp2[2];
                                acted=true;
                                ongoing1 = false;
                            }
                        }
                    }
                }
            } else {
                ongoing = miscFunctions.GoBack(windowWidth);       
            }
        }
    }


    void actionArmourInventory(int player){
        if(Fight.ongoing==true){
            Console.WriteLine();
            miscFunctions.TextBox("You're in a fight. Changeing armour could be fatal.", windowWidth);
            Console.ReadLine();
        } else{
            bool ongoing = true;
            while(ongoing==true){
                Console.Clear();  
                miscFunctions.BoxBorder(windowWidth);
                miscFunctions.BoxLine("--=Armours Inventory=--", windowWidth, "equal");
                if(true){
                    miscFunctions.BoxLine("Equiped Armour:"+InvLists[player].FetchArmourName(0), windowWidth, "equal");
                    miscFunctions.BoxLine("Spare Armour: "+InvLists[player].FetchArmourName(1), windowWidth, "equal");
                }
                miscFunctions.BoxBorder(windowWidth);
                Console.WriteLine(miscFunctions.PadEqual("Change Armour? y/n", windowWidth));
                Console.WriteLine();
                answer=Console.ReadLine().ToLower();
                if(answer == "y" || answer == "yes"){
                    int[] temp = new int[3];
                    for(int i = 0; i < 3; i++){        //Switches the data places around for the armour
                        temp[i]=InvLists[player].armourInventory[0,i];
                        InvLists[player].armourInventory[0,i]=InvLists[player].armourInventory[1,i];
                        InvLists[player].armourInventory[1,i]=temp[i];
                    }
                } else {
                    ongoing = miscFunctions.GoBack(windowWidth);
                }
            }
        }
    }


    void actionPotionsInventory(int player){
        bool ongoing = true;
        while(ongoing == true){
            Console.Clear();
            // miscFunctions.BoxBorder(windowWidth);
            // miscFunctions.BoxLine("--=Potion Belt=--", windowWidth, "equal");
            // for(int i = 0; i < 7; i++){
            //     Console.WriteLine($"| Potion slot {i+1}: {InvLists[player].FetchPotionName(i)}".PadRight(windowWidth-1)+"|");
            // }
            // miscFunctions.BoxBorder(windowWidth);
            Console.WriteLine(miscFunctions.PadEqual("'Move' to move potions around", windowWidth));
            Console.WriteLine(miscFunctions.PadEqual("'Use' to use a potion", windowWidth));
            answer=Console.ReadLine().ToLower();
            if(answer == "move"){
                int[] temp = new int[4];
                Console.Clear();
                miscFunctions.BoxBorder(windowWidth);
                Console.WriteLine("|        --=Potion Belt=--        |");
                for(int i = 0; i < 7; i++){
                    Console.WriteLine($"| Potion slot {i+1}: {InvLists[player].FetchPotionName(i)}".PadRight(windowWidth-1)+"|");
                }
                miscFunctions.BoxBorder(windowWidth);
                Console.WriteLine();
                Console.WriteLine("            Move Potion");
                temp[0]=miscFunctions.StrToInt(Console.ReadLine())-1;
                Console.WriteLine("              To Slot");
                temp[1]=miscFunctions.StrToInt(Console.ReadLine())-1;
                temp[2]=InvLists[player].potionInventory[temp[0],0];  //puts pot 1 into temp storage
                temp[3]=InvLists[player].potionInventory[temp[0],1];
                InvLists[player].potionInventory[temp[0],0] = InvLists[player].potionInventory[temp[1],0]; //moves pot 2 into pot 1s old place
                InvLists[player].potionInventory[temp[0],1] = InvLists[player].potionInventory[temp[1],1];
                InvLists[player].potionInventory[temp[1],0] = temp[2];  // moves pot 1 from storage int pot 2s old place
                InvLists[player].potionInventory[temp[1],1] = temp[3];


            } else if(acted == true && answer=="use" && Fight.ongoing == true){
                Console.Clear();
                miscFunctions.TextBox("You've already used the inventory this turn. Your time is running out.", windowWidth);
                Console.ReadLine();
            } else if(answer == "use"){   // using potions
                bool ongoing1 = true;
                Console.Clear();
                miscFunctions.BoxBorder(windowWidth);
                Console.WriteLine("|  --=What potion do you Use?=--  |");
                for(int i = 0; i < 7; i++){
                    Console.WriteLine($"| Potion slot {i+1}: {InvLists[player].FetchPotionName(i)}".PadRight(windowWidth-1)+"|");
                }
                miscFunctions.BoxBorder(windowWidth);
                while(ongoing1){
                    int potionUsed = miscFunctions.StrToInt(Console.ReadLine());
                    if(potionUsed>0 && potionUsed<8){  //a potion is used
                        potionUsed--; //nudges the variable so it lines up with the array, since it starts at 0 and the meny at 1.
                        if(InvLists[player].FetchPotionName(potionUsed)=="Empty"){
                            miscFunctions.TextBox("That vial is empty.", windowWidth);
                            Console.ReadLine();
                            ongoing1 = false;
                        } else {
                            int temp2;
                            switch(InvLists[player].potionInventory[potionUsed,1]){  //differentiates what happens based on potion type
                                case 0:
                                    temp2 = Characters[player].health;
                                    Characters[player].health = Characters[player].health + InvLists[player].FetchHealpotAmount(potionUsed);
                                    if(Characters[player].health>Characters[player].maxHealth){
                                        Characters[player].health=Characters[player].maxHealth;
                                    }
                                    temp2 = Characters[player].health - temp2;
                                    miscFunctions.TextBox("You Regained "+temp2+"Hp!", windowWidth);
                                    break;
                                case 1:
                                    temp2 = Characters[player].mana;
                                    Characters[player].mana = Characters[player].mana + InvLists[player].FetchManapotAmount(potionUsed);
                                    if(Characters[player].mana>Characters[player].maxMana){
                                        Characters[player].mana=Characters[player].maxMana;
                                    }
                                    temp2 = Characters[player].mana - temp2;
                                    miscFunctions.TextBox("Your Replenished "+temp2+"Mp!", windowWidth);
                                    break;
                                case 2:
                                    int[] temp3 = new int[2];
                                    temp3 = InvLists[player].FetchBuffPotEffect(potionUsed);
                                    Characters[player].atkBuff = Characters[player].atkBuff+temp3[0];
                                    Characters[player].defBuff = Characters[player].defBuff+temp3[1];
                                    miscFunctions.TextBox("You feel strength surge through you.", windowWidth);
                                    break;
                                default:   
                                    //Only fires if there is a potion with a type outside of the Health/Mana/Buff Trifecta, and the array doesn't spit out a failure
                                    //honsetly never expect this to work since the file data list will throw an out of array exeption and crash
                                    Console.WriteLine("potions are malfunctioning?");
                                    Console.WriteLine("what did you even do?");
                                    break;
                            }
                            InvLists[player].potionInventory[potionUsed,0] = 0;  //Removes the potion from the inventory
                            InvLists[player].potionInventory[potionUsed,1] = 0;
                            Console.ReadLine();
                            acted=true;
                            ongoing1=false;
                        } 
                    } else {
                        ongoing1 = miscFunctions.GoBack(windowWidth);
                    }
                }
            } else {
                ongoing = miscFunctions.GoBack(windowWidth);
            }
        }
    }


    void actionSpellInventory(int player){
        bool ongoing = true;
        while(ongoing==true){
            Console.Clear();
            miscFunctions.BoxBorder(windowWidth);
            Console.WriteLine("|     --=Spells Inventory=--      |");
            Console.WriteLine("|        -Readied Spells-         |");
            for(int i = 0; i < 2; i++){
                Console.WriteLine($"| Spell slot {i+1}: {InvLists[player].FetchSpellName(i)}".PadRight(windowWidth-1)+"|");
            }
            Console.WriteLine("|     -----------------------     |");
            Console.WriteLine("|         -Known Spells-          |");
            for(int i = 0; i < 5; i++){ 
                Console.WriteLine($"| Spell slot {i+1}: {InvLists[player].FetchSpellName(i+2)}".PadRight(windowWidth-1)+"|");
            }
            miscFunctions.BoxBorder(windowWidth);
            Console.WriteLine("");
            Console.WriteLine("     Change readied spell? y/n");
            answer=Console.ReadLine().ToLower();
            if(answer == "y" || answer =="yes"){  
                if(acted == true && Fight.ongoing == true){
                    Console.Clear();
                    miscFunctions.TextBox("You've alredy Used the Inventory this turn. Your time is running out.", windowWidth);
                    Console.ReadLine();
                } else { 
                    bool ongoing1 = true;
                     while(ongoing1){
                        int[] temp = new int[4];       //Used to know what weapon slot is gonna change
                        Console.Clear();    //Let's you change equipped weapon
                        miscFunctions.BoxBorder(windowWidth);       // during the change since i'll be 
                        Console.WriteLine("|        -=Redied Spells=-        |");       // overwriting the old one
                        for(int i = 0; i < 2; i++){
                            Console.WriteLine($"| Spell slot {i+1}: {InvLists[player].FetchSpellName(i)}".PadRight(windowWidth-1)+"|");
                        }
                        miscFunctions.BoxBorder(windowWidth);
                        Console.WriteLine();
                        Console.WriteLine(" What spell do you want to change?");
                        Console.WriteLine();
                        temp[0] = miscFunctions.StrToInt(Console.ReadLine())-1;               // Input from user, what weapon slot to change
                        if(temp[0] !=0 && temp[0] !=1){                    
                            ongoing = miscFunctions.GoBack(windowWidth);
                        }else{
                            miscFunctions.BoxBorder(windowWidth);       //Choosig what weapon to switch to.
                            Console.WriteLine("|         -=Known Spells=-        |");       
                            for(int i = 0; i < 5; i++){
                                Console.WriteLine($"| Spell slot {i+1}: {InvLists[player].FetchSpellName(i+2)}".PadRight(windowWidth-1)+"|");
                            }
                            miscFunctions.BoxBorder(windowWidth);
                            Console.WriteLine();
                            Console.WriteLine("     What Spell do you want to");
                            Console.WriteLine("            switch to?");
                            Console.WriteLine();
                            temp[1] = miscFunctions.StrToInt(Console.ReadLine());
                            if(temp[1] == 1 || temp[1] > 5){
                                ongoing1 = miscFunctions.GoBack(windowWidth);
                            } else {
                                temp[1]++;
                                temp[2]=InvLists[player].spellInventory[temp[0],0];  //puts pot 1 into temp storage
                                temp[3]=InvLists[player].spellInventory[temp[0],1];
                                InvLists[player].spellInventory[temp[0],0] = InvLists[player].spellInventory[temp[1],0]; //moves pot 2 into pot 1s old place
                                InvLists[player].spellInventory[temp[0],1] = InvLists[player].spellInventory[temp[1],1];
                                InvLists[player].spellInventory[temp[1],0] = temp[2];  // moves pot 1 from storage int pot 2s old place
                                InvLists[player].spellInventory[temp[1],1] = temp[3];
                                ongoing1=false;
                                acted=true;
                            }
                        }
                    }
                }
            } else {
                ongoing = miscFunctions.GoBack(windowWidth);
            }
        }
    }
                /*Console.WriteLine("   Inspect an Item by inputting");
                Console.WriteLine("       it's number instead.");*/

    void actionMiscellaneousInv(int player){
        bool ongoing = true;
        if(Fight.ongoing){
            Console.Clear();
            miscFunctions.TextBox("You don't have time to ruffle around in your bag!", windowWidth);
            ongoing = false;
            Console.ReadLine();
        } else {                                                            //Keeps track of what page you're on
            int pageTotal=(InventoryLists.miscInventory.Count/12);                  //Keeps track of how many pages your inventory has
            while (ongoing){
                answer = miscFunctions.MiscInvList(windowWidth, "Miscellaneous Inventory", "all", "", false, new string[] {"Inspect an Item by inputting", "it's number instead"});
                if(miscFunctions.StrToInt(answer)==0 || miscFunctions.StrToInt(answer) > InventoryLists.miscInventory.Count+1){
                    ongoing = miscFunctions.GoBack(windowWidth);
                } else {
                    int i = miscFunctions.StrToInt(answer)-1;
                    Console.Clear();
                    miscFunctions.BoxBorder(windowWidth);
                    string name = InventoryLists.FetchMiscName(i);
                    Console.WriteLine("|"+miscFunctions.PadEqual("--="+name+"=--", windowWidth-2)+"|");
                    Console.WriteLine("|"+miscFunctions.PadEqual("Count: "+InventoryLists.FetchMiscAmount(i), windowWidth-2)+"|");
                    string[] tempDescription = InventoryLists.FetchMiscDesc(i);
                    foreach(string line in tempDescription){
                        Console.WriteLine("|"+miscFunctions.PadEqual(line, windowWidth-2)+"|");
                    }
                    miscFunctions.BoxBorder(windowWidth);
                    Console.ReadLine();
                }
            }
        }
    }
}

/*              Misc name & equalPad Legacy code
                string linefiller = "                                 ";
                string name = InventoryLists.FetchMiscName(miscFunctions.StrToInt(answer)-1);
                linefiller = linefiller.Substring(0, 27 - name.Length);
                if(linefiller.Length % 2 == 1){
                    linefiller = linefiller.Substring(0, linefiller.Length/2); //delar "linefiller på 2
                    Console.WriteLine("|"+linefiller+"--="+name+"=--"+linefiller+" |"); // skriver "mellanrum ordsträk mellanrum
                } else {
                    linefiller = linefiller.Substring(0, linefiller.Length/2); // den andra biten finns ifall orden är jämna
                    Console.WriteLine("|"+linefiller+"--="+name+"=--"+linefiller+"|");  // då skulle man behöva olika längd av mellanrum
                }
*/
public class InventoryLists{
    public int[] weaponInventory = new int[7];            //Actual weapon inventory
    static List<MeleeWeapon> weapons = new List<MeleeWeapon>();  //Acts as a database fromwhere to draw weapon stats
    
    public int[,] armourInventory = new int[2,3];         //armour inv
    static List<Armour> armour = new List<Armour>();             //armour db

    public int[,] potionInventory = new int[7,2];
    static List<healingItem> healingItem = new List<healingItem>();
    static List<manaItem> manaItem = new List<manaItem>();
    static List<buffItem> buffItem = new List<buffItem>();

    public int[,] spellInventory = new int[7,2];
    static List<offensiveSpell> offensiveSpell = new List<offensiveSpell>();
    static List<utilitySpell> utilitySpell = new List<utilitySpell>();

    public static  List<string> miscInventory = new List<string>();
    static List<misc> miscItem = new List<misc>();
    
    public string FetchWeaponName(int InventoryID){
        return weapons[weaponInventory[InventoryID]].name;
    }
    public int FetchWeaponDmg(int InventoryID){
        return weapons[weaponInventory[InventoryID]].dmg;
    }

    public string FetchArmourName(int InventoryID){
        return armour[armourInventory[InventoryID,0]].name;   //<List of data>[array of player inventory[what position item has in invenotry,if it's id or type]]
    }
    public string FetchPotionName(int InventoryID){
        switch(potionInventory[InventoryID,1]){
            case 0:
                return healingItem[potionInventory[InventoryID,0]].name;    //<List of data>[array of player inventory[what position item has in invenotry,if it's id or type]]
            case 1:
                return manaItem[potionInventory[InventoryID,0]].name;
            case 2:
                return manaItem[potionInventory[InventoryID,0]].name;
            default:
                return "PotionName";
        }
    }
    public string FetchSpellName(int InventoryID){
        if(spellInventory[InventoryID,1] == 0){
            return offensiveSpell[spellInventory[InventoryID,0]].name; //<List of data>[array of player inventory[what position item has in invenotry,if it's id or type]]
        } else {
            return utilitySpell[spellInventory[InventoryID,0]].name;
        }
    }

    public int FetchHealpotAmount(int InventoryID){
        return healingItem[potionInventory[InventoryID,0]].healing;
    }
    public int FetchManapotAmount(int InventoryID){
        return manaItem[potionInventory[InventoryID,0]].manaReplenished;
    }
    public int[] FetchBuffPotEffect(int InventoryID){
        int[] temp = new int[2];
        temp[0] = buffItem[potionInventory[InventoryID,0]].atkEffect;
        temp[1] = buffItem[potionInventory[InventoryID,0]].defEffect;
        return temp;
    }
    public static void AddMiscItem(int itemID, int itemCount){
        int listID = 0;
        bool exists = false;
        foreach(string item in miscInventory){
            string[] temp = item.Split("|");
            if(itemID==int.Parse(temp[0])){
                string newItem = $"{itemID}|{int.Parse(temp[1])+itemCount}";  //Items ID| amount of items
                miscInventory.RemoveAt(listID);
                miscInventory.Add(newItem);
                exists = true;
                break;
            }
            listID++;
        }
        if (exists==false){
            miscInventory.Add($"{itemID}|{itemCount}");
        }
    }
    public static void RemoveMiscItem(int ID, bool itemID, int itemCount){ 
        if(itemID){                                                        
            int listID = 0;
            foreach(string item in miscInventory){
                string[] temp = item.Split("|");
                if(ID==int.Parse(temp[0])){
                    //string newItem = $"{itemID}|{int.Parse(temp[1])-itemCount}";  //Items ID| amount of items redundant
                    temp[1] = $"{int.Parse(temp[1])-itemCount}";  //temp serves the same function as "item" in the inventoryID version
                    if(int.Parse(temp[1]) <= 0){
                        miscInventory.RemoveAt(listID);
                    } else {
                        miscInventory[ID] = $"{temp[0]}|{temp[1]}";
                    }
                    break;
                }
                listID++;
            }
        } else {
            string[] item = miscInventory[ID].Split("|");
            item[1] = $"{int.Parse(item[1])-itemCount}";
            if(int.Parse(item[1]) <= 0){
                miscInventory.RemoveAt(ID);
            } else {
                miscInventory[ID] = $"{item[0]}|{item[1]}";
            }
        }
    }

    static public string FetchMiscName(int InventoryID){
        string[] temp = miscInventory[InventoryID].Split("|");
        return miscItem[int.Parse(temp[0])].name;
    }
    static public int FetchMiscAmount(int InventoryID){
        string[] temp = miscInventory[InventoryID].Split("|");
        return int.Parse(temp[1]);
    }
    static public string[] FetchMiscDesc(int InventoryID){
        string[] temp = miscInventory[InventoryID].Split("|");
        return miscItem[int.Parse(temp[0])].description.Split("#");
    }
    static public string FetchMiscType(int InventoryID){
        string[] temp = miscInventory[InventoryID].Split("|");
        return miscItem[int.Parse(temp[0])].type;
    }
    static public int FetchMiscCost(int InventoryID){
        string[] temp = miscInventory[InventoryID].Split("|");
        return miscItem[int.Parse(temp[0])].cost;
    }


    public void inventorySetup(){
        //Weaponry Setup
        string[] equipmentDbString = File.ReadAllLines(@"Inventory\Weaponry.txt"); //loading ALL Weapons data into a variable
        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                string[] weaponData = line.Split('|');

                weapons.Add(new MeleeWeapon() {
                    name = weaponData[0],
                    dmg = int.Parse(weaponData[1]),
                    AcModifier = int.Parse(weaponData[2]),
                    ManaCostReduction = int.Parse(weaponData[3]),
                    SpellEffectModifier = int.Parse(weaponData[4]),
                    cost = int.Parse(weaponData[5])

                });
            }
        }
        weaponInventory[0] = 1;
        //armour

        equipmentDbString = File.ReadAllLines(@"Inventory\Armour.txt"); //loading ALL of Armour data into a variable
        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                string[] data = line.Split('|');

                armour.Add(new Armour() {
                    name = data[0],
                    AC = int.Parse(data[1]),
                    dodge = int.Parse(data[2]),
                    def = int.Parse(data[3]),
                    repairCost = int.Parse(data[4]),
                    cost = int.Parse(data[5]),
                    durability = int.Parse(data[6]),
                    repairCostModifier = int.Parse(data[7])
                });
            }
        }
        armourInventory[0,0]=1;
        armourInventory[0,1]=20;
        armourInventory[0,2]=1;
        //Potions

        equipmentDbString = File.ReadAllLines(@"Inventory\Potions.txt"); //loading ALL of Potion data into a variable
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

        equipmentDbString = File.ReadAllLines(@"Inventory\Spells.txt"); //loading ALL of Spell data into a variable
        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                if(line[0]=='o'){
                    string[] data = line.Split('|');

                    offensiveSpell.Add(new offensiveSpell() {
                        name = data[1],
                        dmg = int.Parse(data[2]),
                        aoe = bool.Parse(data[3]),
                        manaCost = int.Parse(data[4]),
                        cost = int.Parse(data[5])
                    });
                }
                if(line[0]=='u'){
                    string[] data = line.Split('|');

                    utilitySpell.Add(new utilitySpell() {
                        name = data[1],
                        atkModifier = int.Parse(data[2]),
                        defModifier = int.Parse(data[3]),
                        acModifier = int.Parse(data[4]),
                        healing = int.Parse(data[5]),
                        duration = int.Parse(data[6]),
                        manaCost = int.Parse(data[7]),
                        cost = int.Parse(data[8])
                    });
                }
            }
        }
        spellInventory[0,0]=1;
        spellInventory[0,1]=0;
        spellInventory[1,0]=0;
        spellInventory[1,1]=1;
        spellInventory[2,0]=1;
        spellInventory[2,1]=1;
        spellInventory[3,0]=2;
        spellInventory[3,1]=1;


        equipmentDbString = File.ReadAllLines(@"Inventory\Miscellaneous.txt"); //loading ALL of Misc data into a variable
        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                string[] data = line.Split('|');

                miscItem.Add(new misc() {
                    type = data[0],
                    name = data[1],
                    description = data[2],
                    cost = int.Parse(data[3])
                });
            }
        }
        for(int i = 0; i < miscItem.Count; i++){
            AddMiscItem(i,5);
        }
        Inventory.Characters.Add(new player());
    }
}