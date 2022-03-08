using System;
using System.IO;
using System.Collections.Generic;
// Console.WriteLine("Starting; Loading");  // needed to show frined how this shit is made. Damn facked loading scrrens are funny though.
// for(int i = 0; i<100; i++){
//     if(i%10==0){
//         Console.Write(i+"%");
//     } else if(i%2==0){
//         Console.Write(".");
//     }
//     System.Threading.Thread.Sleep(200);
// }
// Console.WriteLine("Finished!");
// Console.ReadLine();

Fight.ongoing=false;
string playerName;
bool game = true;
bool ongoing = true;
Inventory Inv = new Inventory();
string answer;
int windowWidth = 35;
Inventory.InvLists.Add(new InventoryLists());
Inventory.InvLists[0].inventorySetup();
FightingStyles.fightingStyleSetup();

Console.Clear();
while(ongoing){
    miscFunctions.TextBox("Please Choose a Textbox size. Recommended 35-55. Size is measured in the amount of characters. Note: Anything that isn't a number will be treated as a 0.", 35);
    windowWidth = miscFunctions.StrToInt(Console.ReadLine());
    if(windowWidth < 20){
        miscFunctions.TextBox("A size less than 20 may cause runtime issues. The game will break, skipping the offending textbox. Understood? y/n");
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
        Shops.windowWidth = windowWidth;
        Inventory.windowWidth = windowWidth;
        Fight.windowWidth = windowWidth;
    } else {
        windowWidth = 35;
    }   
}
Inv.actionInventory(0);
// Console.ReadLine();
Shops.actionGuild();

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