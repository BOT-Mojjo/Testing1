using System;
class Shops {
    string answer;
    int windowWidth = 35;
    public void actionGuild(){ 
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
                    ongoing1 = miscFunctions.GoBack();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("+------------=========------------+");
                    Console.WriteLine("|     --==Mercenary Guild==--     |");
                    Console.WriteLine("|       -Sell Animal Parts-       |");
                    for(int i = 0; i < InventoryLists.miscInventory.Count; i++){
                        if(InventoryLists.FetchMiscType(i)=="AnimalPart"){
                            Console.WriteLine("|"+miscFunctions.PadEqual(
                                InventoryLists.FetchMiscName(i)+"*"+InventoryLists.FetchMiscAmount(i)
                            , windowWidth-2)+"|");
                        }
                    }
                    Console.WriteLine("+------------=========------------+");
                    break;
            }
        }
    }
}