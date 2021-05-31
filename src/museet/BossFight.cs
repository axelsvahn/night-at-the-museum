using System;
using System.Collections.Generic;
using System.Threading;

namespace museet
{
    ///<summary>
    ///Adds boss fight for extra fun
    ///</summary>
    class BossFight
    {
        ///<summary>
        ///Generates random type of counter attack
        ///</summary>
        static int RandomAttack()
        {
            Random attackGenerator = new Random();
            int attackRand = attackGenerator.Next(0, 3);
            return attackRand;
        }

        ///<summary>
        ///Prints HP and MP of combatants
        ///</summary>
        static void PrintStatus(Hero hero1, Boss boss1)
        {
            Console.Clear();
            System.Console.WriteLine("Besökarens status:");
            Console.WriteLine($"Namn: {hero1.Name}");
            Console.WriteLine($"Nuvarande hälsopoäng (HP): {hero1.HP} / 100"); //this is hardcoded but could be maxHP vs. currentHP variables
            Console.WriteLine($"Nuvarande magipoäng (MP): {hero1.MP} / 30");
            System.Console.WriteLine("-----------------------------------");
            Console.WriteLine("Bossens status:");
            Console.WriteLine($"Namn: {boss1.Name}");
            Console.WriteLine($"Nuvarande hälsopoäng (HP): {boss1.HP} / 200");
            Console.WriteLine($"Nuvarande magipoäng (MP): {boss1.MP} / 50");
        }

        ///<summary>
        ///Handles user input and game loop for boss fight
        ///</summary>
        public static bool Run() //is static to make boss fight more self-contained with respect to rest of application
        {
            bool bossIsDefeated = false;
            System.Console.WriteLine("Nu börjar en Boss-strid!");
            Thread.Sleep(2000);

            List<Entity> EntityList = new List<Entity>();
            //This is used to make sure that attacker [0] and defender [1] 
            //can be different entities depending on choice of attacker for each iteration of fight loop

            Console.Write("Vad heter du? ");
            string heroName = Console.ReadLine();
            if (heroName.Length < 2) //handles empty or single-character names
            {
                heroName = "Besökaren";
            }
            Hero hero1 = new Hero(100, 30, heroName, true); 

            Console.Write("Vad ska bossen heta? ");
            string bossName = Console.ReadLine();
            if (bossName.Length < 2) //handles empty or single-character names
            {
                bossName = "Bossen";
            }
            Boss boss1 = new Boss(200, 50, bossName, true); //boss should win most of the time

            Console.Clear();

            //fight loop while both are alive
            while (boss1.IsAlive && hero1.IsAlive)
            {
                // 1.1 select first attacker
                Console.WriteLine("\nVem ska anfalla, " + hero1.Name + " eller " + boss1.Name + "? ");
                Console.WriteLine("Tryck annars enter för att se kämparnas tillstånd.");

                string input = Console.ReadLine();
                if (input == hero1.Name)
                {
                    EntityList.Insert(0, hero1);
                    EntityList.Insert(1, boss1);
                }
                else if (input == boss1.Name)
                {
                    EntityList.Insert(0, boss1);
                    EntityList.Insert(1, hero1);
                }
                else if (input == "")
                {
                    PrintStatus(hero1, boss1);
                    continue; //restart main loop
                }
                else if (input != hero1.Name && input != boss1.Name)
                {
                    continue; //restart main loop
                }

                // 1.2 Select mode of attack for first attacker
                Console.WriteLine($"Ska {EntityList[0].Name} använda sitt vapen eller magi? (v/m)");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "v": //physical attack
                        EntityList[0].Attack(EntityList[1]);
                        break;
                    case "m": //magic attack 
                        EntityList[0].MagicAttack(EntityList[1]);
                        break;
                    default: //no attack
                        Console.WriteLine($"{EntityList[0].Name} bara står och tittar på {EntityList[1].Name}.");
                        break;
                }

                // 2. counter attack
                if (EntityList[1].IsAlive) //only if combatant is alive
                {
                    int magicOrPhysicalAttack = RandomAttack();
                    if (magicOrPhysicalAttack == 0)
                    {
                        System.Console.WriteLine($"{EntityList[1].Name} gör ett motanfall...");
                        Thread.Sleep(2000);
                        EntityList[1].Attack(EntityList[0]);
                    }
                    else if (magicOrPhysicalAttack == 1 && EntityList[1].MP >= 10)
                    {
                        System.Console.WriteLine($"{EntityList[1].Name} förbereder en trollformel...");
                        Thread.Sleep(2000);
                        EntityList[1].MagicAttack(EntityList[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{EntityList[1].Name} misslyckas med sitt anfall mot {EntityList[0].Name}!"); //should add value for this
                    }
                }

                //3. clears list for each round, but object instances will remain since they are reference types
                EntityList.Clear();
            }

            //after main loop ends upon defeat of combatant
            if (boss1.IsAlive)
            {
                System.Console.WriteLine(boss1.Name + " har vunnit. Snyft...");
            }
            else if (hero1.IsAlive)
            {
                System.Console.WriteLine(hero1.Name + " har triumferat! Muséet är räddat för denna gång!");
                bossIsDefeated = true;
            }
            return bossIsDefeated;
        }
    }
}