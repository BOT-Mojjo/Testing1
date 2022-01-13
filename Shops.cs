using System;
using System.Collections.Generic;
class Shops {
    static string answer;
    static int windowWidth = 35;
    public static void actionGuild(){ 
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
                    while(ongoing1){
                        int page = 0;
                        int pageTotal=0;
                        List<int> animalPart = new List<int>();
                        for(int i = 0; i < InventoryLists.miscInventory.Count; i++){
                            if(InventoryLists.FetchMiscType(i)=="AnimalPart"){
                                animalPart.Add(i);
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("+------------=========------------+");
                        Console.WriteLine("|     --==Mercenary Guild==--     |");
                        Console.WriteLine("|       -Sell Animal Parts-       |");
                        if(animalPart.Count == 0){
                            Console.WriteLine("|         -=Parts Empty=-         |");
                        } else {
                            Console.WriteLine("| Page: "+(page+1)+"                         |");
                            if(animalPart.Count<10){
                                for(int i = 0; i < animalPart.Count; i++){
                                    Console.WriteLine("|"+miscFunctions.PadEqual((i+1)+": "+
                                        InventoryLists.FetchMiscName(animalPart[i])+"*"+InventoryLists.FetchMiscAmount(animalPart[i])
                                    , windowWidth-2)+"|");
                                }
                            } else {
                                for(int i = 0; i < animalPart.Count-(page*10)-1; i++){
                                    Console.WriteLine("|"+miscFunctions.PadEqual((i+1+(page*10))+": "+
                                        InventoryLists.FetchMiscName(animalPart[i])+"*"+InventoryLists.FetchMiscAmount(animalPart[i])
                                    , windowWidth-2)+"|");
                                }
                            }
                        }
                        Console.WriteLine("+------------=========------------+");
                        Console.WriteLine("");
                        Console.ReadLine();
                        if(InventoryLists.miscInventory.Count == 0){
                            answer="0";
                        } else if(pageTotal>0){
                            Console.WriteLine("        Move between pages");
                            Console.WriteLine("       by typing '<' or '>'");
                            Console.WriteLine("    Sell an Item by inputting");
                            Console.WriteLine("       it's number instead.");
                            answer=Console.ReadLine();
                        }
                        if(pageTotal>0 && (answer == "<" || answer == ">")){
                            if(answer == "<"){
                                if(page==0){
                                    Console.WriteLine("You're on the first page.");
                                    Console.ReadKey();
                                } else {
                                    page--;
                                }
                            } else if(answer == ">"){
                                if(page==pageTotal){
                                    Console.WriteLine("You're on the last page.");
                                    Console.ReadKey();
                                } else {
                                    page++;
                                }
                            }
                        } else if(miscFunctions.StrToInt(answer) != 0 && miscFunctions.StrToInt(answer) !> animalPart.Count){
                            Console.Clear();
                            Console.WriteLine("+------------=========------------+");
                            Console.WriteLine("|"+miscFunctions.PadEqual("How many "+InventoryLists.FetchMiscName(int.Parse(answer)-1)+" do you", windowWidth-2)+"|");
                            Console.WriteLine("|          wish to sell?          |");
                            Console.WriteLine("+------------=========------------+");
                            answer = Console.ReadLine();
                            
                        } else {
                            ongoing1 = miscFunctions.GoBack();
                        }
                    }
                    break;
            }
        }
    }
}