using System;
using System.IO;
using System.Collections.Generic;
Fight.ongoing=false;
string playerName;
bool game = true;
bool ongoing = true;
Inventory Inv = new Inventory();
string answer;
int windowWidth = 35;
Inventory.InvLists.Add(new InventoryLists());
Inventory.InvLists[0].inventorySetup();
// Inv.actionInventory(0);
// Console.ReadLine();
FightingStyles.fightingStyleSetup();
// Shops.actionGuild();

Console.Clear();
while(ongoing){
    miscFunctions.TextBox("Please Choose a Textbox size. Recommended 35-55. Size is measured in the amount of characters. Note: Anything that isn't a number will be treated as a 0.", 20);
    windowWidth = miscFunctions.StrToInt(Console.ReadLine());
    if(windowWidth < 15){
        miscFunctions.TextBox("A size less than 15 may cause runtime issues. Understood? y/n");
        answer = Console.ReadLine().ToLower();
        if(answer == "y" || answer == "yes"){

        } else {
            windowWidth = 35;
        }
    }
    miscFunctions.TextBox("Is this size acceptable? y/n", windowWidth);
    answer = Console.ReadLine().ToLower();
    if(answer == "y" || answer == "yes"){
        ongoing = false;
    } else {
        windowWidth = 35;
    }
        
}

Console.WriteLine("RPG adventure of the CMD");
Console.WriteLine("  Write Start to Begin");
Console.WriteLine();
Console.ReadLine();
//Console.WriteLine("Write Rules to learn how to play");

Console.WriteLine("What is your name Adventurer?");
Inventory.Characters[0].name = Console.ReadLine();
Console.WriteLine();
while(Inventory.Characters[0].name.Length>15){
    Console.WriteLine("Would you happen to have a shorter nickname?");
    Console.WriteLine();
    playerName=Console.ReadLine();
}

//tutorial
Console.WriteLine("I see. Good luck on your Journey, " + Inventory.Characters[0].name + ".");
Console.ReadLine();
Console.Clear();
Console.WriteLine("As you set out on your Journey, your first steps lead you to The Peaceful Plains");
Console.WriteLine("Before you a little Bunny's jumping around.");
Console.ReadLine();


//Game loop.
while(game==true){

}
Console.ReadLine();