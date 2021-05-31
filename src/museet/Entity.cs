using System;
using System.Threading;

namespace museet
{
    ///<summary>
    ///Parent class of "Boss" and "Hero", handles damage logic
    ///</summary>
    abstract class Entity
    {
        private int hP;

        private int mP;

        private string name;
        private bool isAlive;

        public int HP { get => hP; set => hP = value; }

        public int MP { get => mP; set => mP = value; }
        public string Name { get => name; set => name = value; }
        public bool IsAlive { get => isAlive; set => isAlive = value; }

        ///<summary>
        ///logic for physical attacks
        ///</summary>
        public void Attack(Entity x)
        {
            Random damageGenerator = new Random();
            int damage = damageGenerator.Next(0, 100);

            Console.WriteLine(this.Name + " träffar " + x.Name + " för " + damage + " i skada!");

            if (damage > 80)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("En KRITISK ATTACK!! " + x.Name + " får problem nu!");
                Console.ResetColor();
            }
            else if (damage > 50)
            {
                Console.WriteLine("En kraftfull attack!");
            }
            else if (damage < 15)
            {
                System.Console.WriteLine("En misslyckad attack! " + this.Name + " skäms.");

            }
            x.HP -= damage;
            x.CheckAlive();
        }

        ///<summary>
        ///logic for magical attacks
        ///</summary>
        public void MagicAttack(Entity x)
        {
            Random damageGenerator = new Random();

            if (this.MP >= 10)
            {
                int damage = damageGenerator.Next(0, 50);
                Console.ForegroundColor = ConsoleColor.Cyan;
                System.Console.WriteLine(this.Name + " träffar " + x.Name + " för " + damage + " i skada med sin trollformel!");
                Console.ResetColor();
                if (damage > 40)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("En KRITISK ATTACK! " + x.Name + " är illa ute!");
                    Console.ResetColor();
                }
                else if (damage > 30)
                {
                    System.Console.WriteLine("En kraftfull attack!");
                }
                else if (damage < 15)
                {
                    System.Console.WriteLine("Det var inte mycket till magi! " + this.Name + " hänger skamset med huvudet.");
                }
                x.HP -= damage;
                this.MP -= 10;

                System.Console.WriteLine($"{this.Name} har använt 10 MP.");

                x.CheckAlive();
            }
            else if (this.MP < 10)
            {
                System.Console.WriteLine($"{this.name} har inte nog med MP för att trolla.");
            }
        }

        ///<summary>
        ///Checks whether a combatant is still alive
        ///</summary>
        public void CheckAlive()
        {
            System.Console.WriteLine(this.Name + " har " + this.HP + " HP kvar.");
            Thread.Sleep(2000);
            if (this.HP < 1)
            {
                this.IsAlive = false;

                if (this.HP < -40)
                {
                    System.Console.WriteLine(this.Name + " har fått rejält på nöten!");
                }
                else if (this.HP < -30)
                {
                    System.Console.WriteLine(this.Name + " trillar omkull.");
                }
                else if (this.HP < -20)
                {
                    System.Console.WriteLine(this.Name + " ramlar omkull.");
                }
                else if (this.HP < -10)
                {
                    System.Console.WriteLine(this.Name + " måste gå och vila sig en stund.");
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine(this.Name + " är besegrad!");
                Console.ResetColor();
            }
            else if (this.hP > 0 && this.hP < 20)
            {
                System.Console.WriteLine(this.Name + " klarar sig, men är i dåligt skick!");
            }
            else
            {
                System.Console.WriteLine(this.Name + " klarar sig!");
            }
        }
    }
}
