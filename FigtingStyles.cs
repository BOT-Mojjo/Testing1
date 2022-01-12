using System;
using System.IO;
//fighting styles setup:
static public class FightingStyles{
    static public string[,] fightingStylesLearned = new string[4, 3];                          //current learned fighting style
    static public string[] fightingStylesDBString = File.ReadAllLines(@"FightingStyles.txt");  //all fighting styles
    static public int[] fightingStyle = new int[2];  //currently equiped fighting style, with what it does math wise 
    static public void fightingStyleSetup(){
        for (int i = 0; i < 8; i++){                                                 //filling all spots in the string to prevent NULL exceptions
            string[] fightingStylesTemp = fightingStylesDBString[0].Split("|");      //making the db string usable temporarily,
            //fightingStylesLearned[i/2,i%2]=fightingStylesDBString[0];            
            if (i % 2 == 0){
                fightingStylesLearned[i / 2, i % 2] = fightingStylesTemp[0];  //fills in the name
                fightingStylesLearned[i / 2, 2] = "1";                        //fills in the id, 1 for "none" in this case
            } else {
                fightingStylesLearned[i / 2, i % 2] = "0";                    //fills in the lvl for the Style, 1 for lvl 1
            }
            if (i == 7){                                        //Equiping the starter fighting style, manually and hardcoded
                fightingStylesLearned[0, 0] = "Self-Taught";    //First Column stores the name of the style
                fightingStylesLearned[0, 1] = "1";              //Second column stores the level of the style
                fightingStylesLearned[0, 2] = "2";              //Third stores Fighting Style id, the line number it's stored on in FightingStyles.txt
            }
        }
        fightingStyle[0] = 4;              //[0]=+atk%
        fightingStyle[1] = 4;              //[1]=+def%
    }
    static public void actionStyleChange(){      //gör skälva bytet av fightingStyle
        int styleChangedTo = miscFunctions.StrToInt(Console.ReadLine());
        if (styleChangedTo == 0){
        } else {
            string[] tempStyleData = fightingStylesDBString[int.Parse(fightingStylesLearned[styleChangedTo - 1, 2])].Split("|");    //DBstring[idnummer från Learned[vadman vill byta till, id nummer plats i array]]
            //ger data i ett {"namn","x1,y1","x2,y2","x3,y2"} format.
            string tempStyleDatalevel = tempStyleData[int.Parse(fightingStylesLearned[styleChangedTo - 1, 1])];
            int tempNum = tempStyleDatalevel.IndexOf(",");
            fightingStyle[0] = int.Parse(tempStyleDatalevel.Substring(0, tempStyleDatalevel.Length - tempNum));
            fightingStyle[1] = int.Parse(tempStyleDatalevel.Substring(tempNum + 1));
         }
    }

    static public void figthingStylesMeny(){                    //Gör menyn som visar vad man den innehåller --kan attakera med--
        int useless;                              //Variable needed for int.TryParse, not used anywhere else but to make it happy
        int i3 = 0;                               //i3 används för att hålla koll på vilket namn den jobbar med just  nu.
        int i4 = 1;                               //Används för menyn nummerna, int i3, håller koll på vilka namn den har redan gått över
        for (int i = 0; i < 4; i++){                   // Lägger till lvl i roman nummer i slutet av namnen, funkar inte för mer än 3
            string TempStyleLvl = " ";
            for (int i2 = 0; i2 < int.Parse(fightingStylesLearned[i, 1]); i2++){
                TempStyleLvl = TempStyleLvl.Insert(TempStyleLvl.Length, "I");
            }
            fightingStylesLearned[i, 0] = fightingStylesLearned[i, 0].Insert(fightingStylesLearned[i, 0].Length, TempStyleLvl);  //Adds the lvl values to the end of the name temporarily for the purpose of the meny
        }

        //Console.Clear();
        Console.WriteLine("+-------------------------+");
        Console.WriteLine("|   -=Fighting Styles=-   |");
        Console.WriteLine("|                         |");
        //for(int menyLine = 0; menyLine != fightingStylesLearned.Length-1; menyLine++){
        //string[] tempEquip = DBString[idString[menyLine]].Split('|');                //tar alla equiped attacker och gör dem användbara
        foreach (string menyLine in fightingStylesLearned){
            if (int.TryParse(menyLine, out useless) == false){     //int.TryParse used to filter the names of the styles from thier levels
                string lineFiller = "                      ";
                lineFiller = lineFiller.Substring(0, 22 - menyLine.Length);                //checks lenght of equipment name
                Console.WriteLine("| " + i4 + ":" + menyLine + lineFiller + "|");        // loads the name of the equipment from the DBstring with the id from equipedattacks string
                i4++;
            }
        }
        Console.WriteLine("|                         |");
        Console.WriteLine("+-------------------------+");
        foreach (string menyLine in fightingStylesLearned){  //städar upp namnen när menyn är klar
            if (int.TryParse(menyLine, out useless) == false){  //kollar om det är ett namn som den har i minne just nu
                fightingStylesLearned[i3, 0] = menyLine.Remove(menyLine.Length - int.Parse(fightingStylesLearned[i3, 1]) - 1);
                i3++;                                        //^tar bort lvl+1 antal charaktärer i slutet av namnet, som borde bara var ett mällenslag och lvl
            }
        }
    }

}