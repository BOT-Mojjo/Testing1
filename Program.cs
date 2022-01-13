using System;
using System.IO;
using System.Collections.Generic;
Fight.ongoing=false;
string playerName;
bool game = true;


InventoryLists.inventorySetup();
for(int i =0; i < 13; i++){
    InventoryLists.AddMiscItem(i,5);
}
InventoryLists.RemoveMiscItem(1,3);
InventoryLists.RemoveMiscItem(3,5);
FightingStyles.fightingStyleSetup();
Shops.actionGuild();
Inventory.actionInventory();

Console.WriteLine("RPG adventure of the CMD");
Console.WriteLine("  Write Start to Begin");
Console.WriteLine();
Console.ReadLine();
//Console.WriteLine("Write Rules to learn how to play");

Console.Clear();
Console.WriteLine("What is your name Adventurer?");
player.name = Console.ReadLine();
Console.WriteLine();
while(player.name.Length>15){
    Console.WriteLine("Would you happen to have a shorter nickname?");
    Console.WriteLine();
    playerName=Console.ReadLine();
}

//tutorial
Console.WriteLine("I see. Good luck on your Journey, " + player.name + ".");
Console.ReadLine();
Console.Clear();
Console.WriteLine("As you set out on your Journey, your first steps lead you to The Peaceful Plains");
Console.WriteLine("Before you a little Bunny's jumping around.");
Console.ReadLine();


//Game loop.
while(game==true){

}
Console.ReadLine();