using System;
using System.Collections.Generic;
class Shops {
    static string answer;
    static int windowWidth = 35;
    public static void actionGuild(int player){ 
        bool ongoing = true;
        while (ongoing){   //Standard Meny layout and function, template är kopierad från inventory 
            Console.Clear();
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("|     --==Mercenary Guild==--     |");
            Console.WriteLine("|       1:Sell Animal Parts       |");
            Console.WriteLine("|    2:Collect Monster Bounties   |"); 
            Console.WriteLine("|          3:Assignments          |");
            Console.WriteLine("+------------=========------------+");
            bool ongoing1 = true;
            answer = Console.ReadLine();
            switch(miscFunctions.StrToInt(answer)){
                default:
                case 0:
                    ongoing = miscFunctions.GoBack();
                    break;
                case 1:
                    while(ongoing1){
                        answer = miscFunctions.MiscInvList(windowWidth, "Sell Animal Parts", player, "AnimalPart", "", true, new string[] {"Type the Parts Number", "to sell it."});
                        List<int> animalPart = new List<int>();  
                        for(int i = 0; i < Inventory.InvLists[player].miscInventory.Count; i++){
                            if(Inventory.InvLists[player].FetchMiscType(i)=="AnimalPart"){
                                animalPart.Add(i);
                            }
                        }
                        //even though this code is technicaly redundant, i can't get the result from
                        //inside MiscInvList without annoying, though easily spaghetti fixable complications
                        if(miscFunctions.StrToInt(answer) > 0 && miscFunctions.StrToInt(answer) < animalPart.Count+1){
                            string answer2;
                            Console.Clear();
                            Console.WriteLine("+------------=========------------+");
                            Console.WriteLine("|"+miscFunctions.PadEqual("How many "+Inventory.InvLists[player].FetchMiscName(animalPart[int.Parse(answer)-1])+" do you", windowWidth-2)+"|");
                            Console.WriteLine("|          wish to sell?          |");
                            Console.WriteLine("|"+miscFunctions.PadEqual("1-"+Inventory.InvLists[player].FetchMiscAmount(animalPart[int.Parse(answer)-1]), windowWidth-2)+"|"); // 1-(amount of parts)
                            Console.WriteLine("+------------=========------------+");
                            answer2 = Console.ReadLine();
                            if(miscFunctions.StrToInt(answer2) > 0 && miscFunctions.StrToInt(answer2) <= Inventory.InvLists[player].FetchMiscAmount(animalPart[int.Parse(answer)-1])){ //if answer > 0 and < amount of parts
                                Inventory.partyCoins =+ (Inventory.InvLists[player].FetchMiscCost(animalPart[int.Parse(answer)-1])*miscFunctions.StrToInt(answer2))/2;  //curent gold + cost of part*amount of parts / 2
                                Console.Clear();
                                Console.WriteLine("+------------=========------------+");
                                Console.WriteLine("|"+miscFunctions.PadEqual($"You sold {int.Parse(answer2)} {Inventory.InvLists[player].FetchMiscName(animalPart[int.Parse(answer)-1])} for", windowWidth-2)+"|");
                                Console.WriteLine("|"+miscFunctions.PadEqual($"{Inventory.InvLists[player].FetchMiscCost(animalPart[int.Parse(answer)-1])*miscFunctions.StrToInt(answer2)/2} gold.", windowWidth-2)+"|");
                                Console.WriteLine("+------------=========------------+");
                                Inventory.InvLists[player].RemoveMiscItem(animalPart[int.Parse(answer)-1], int.Parse(answer2));
                                Console.ReadLine();
                            }
                        } else {
                            ongoing1 = miscFunctions.GoBack();
                        }
                    }
                    break;
            }
        }
    }
}