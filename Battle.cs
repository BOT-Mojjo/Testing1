using System;
using System.IO;
public class Fight{
    static public bool ongoing = true;
    static public void inFight(){
        while (ongoing == true){
            string enemyName; // Names should always be 11 Characters long, no exceptions even if you have to just fill them with spaces.
            int enemyHealth;
            int maxEnemyHealth;
            string enemyAction;
            int enemy = valueConvert.genRandom.Next(0, 1);
            string[] enemyDbString = File.ReadAllLines(@"EnemySpecifics.txt");  //getting all of the enemy data into a variable 
            string[] currentEnemy = enemyDbString[1].Split('|');    //Splitting the data for the current enemy 
                                                                    //into usable chunks

            enemyHealth = int.Parse(currentEnemy[1]);
            maxEnemyHealth = enemyHealth;
            enemyAction = "Bite";
            enemyName = currentEnemy[0];
            while (enemyHealth > 0){
                Console.Clear();
                Console.WriteLine("+-------------------------+");
                Console.WriteLine($"|       {enemyName}       |");
                if (enemyHealth < 10){
                    Console.WriteLine($"|        0{enemyHealth}hp/0{maxEnemyHealth}hp        |");
                } else if (enemyHealth > 99){
                    Console.WriteLine($"|        {enemyHealth}hp/{maxEnemyHealth}hp          |");
                } else {
                    Console.WriteLine($"|        {enemyHealth}hp/{maxEnemyHealth}hp          |");
                }
                Console.WriteLine("+-------------------------+");
                    Console.WriteLine("They're preparing to use:");
                    Console.WriteLine("          " + enemyAction);
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine();
                }
                Console.WriteLine("+------------------------+");
                //                 |     Player    10hp      |
                Console.WriteLine($"|     Player    {player.health}hp      |");
                Console.WriteLine("|  1:Attack   2:Style     |");
                Console.WriteLine("|  3:Flee     4:Inventory |");
                Console.WriteLine("+-----------------------+");
                playerAction:
                int PlayerAction = valueConvert.StrToInt(Console.ReadLine());
                Console.Clear();
                switch (PlayerAction){
                    case 0:
                        Console.WriteLine("Write a number");
                        goto playerAction;

                    case 1:
                        actionAttack();
                        break;

                    case 2:
                        FightingStyles.figthingStylesMeny();
                        FightingStyles.actionStyleChange();
                        break;

                    case 3:
                        //actionFlee();
                        break;

                    case 4:
                        Inventory.actionInventory();    
                        break;
                }
                //enemyAction();
            }
            if (enemyHealth == 0){
                Console.WriteLine($"You've defeated {enemyName},");
                Console.WriteLine($"Earning you {currentEnemy[3]}xp");
                ongoing = false;
            }

            void actionAttack(){ //tar hand om matten och attack id för attaken
                int attackUsed = valueConvert.StrToInt(Console.ReadLine());
                int attackRoll = valueConvert.genRandom.Next(5, 20);
                if (attackRoll < int.Parse(currentEnemy[2])){
                    Console.WriteLine("You Missed");
                    Console.ReadLine();
                } else {
                   // enemyHealth -= equipedAttacks[attackUsed - 1] * (fightingStyle[0] / 100);
                   // Console.WriteLine("You hit! Dealing " + equipedAttacks[attackUsed - 1] * (fightingStyle[0] / 100) + " dmg!");
                    Console.ReadLine();
                }
            }
        }
    }
}