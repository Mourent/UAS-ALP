using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_project_AP
{
    class Player
    {
        public string name;
        public int coins = 0;
        public int health = 10;
        public int damage = 1;
        public int armorvalue = 0;
        public int potion = 5;
        public int weaponvalue = 2;
    }

    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
        }
        private static bool random;
        private static string name;
        private static int power;
        public static int health;
        public static int potionV;
        private static void Start(bool power, bool name)
        {
            throw new NotImplementedException();
        }

        static void Start()
        {
            Console.WriteLine("Ender's Dungeon");
            Console.WriteLine("Name");
            currentPlayer.name = Console.ReadLine();
            Console.WriteLine("You awake in a cold, stone, dark room. You feel dazed and are having trouble remembering");
            Console.WriteLine("Anything about your past");
            if (currentPlayer.name == "")
                Console.WriteLine("You can't even remember you own name...");
            else
                Console.WriteLine("You know your name is " + currentPlayer.name);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You grope around in the darkness until you find a door handle. You feel some resistance as");
            Console.WriteLine("you turn the handle, but the rusty lock breaks with little effort. You see your captor");
            Console.WriteLine("Standing with his back to you outside the door");
        }
        class Encounters
        {
            static Random rand = new Random();

            public static void FirstEncounter()
            {
                Console.WriteLine("You open the door and take a sword and charge toward your captor");
                Console.WriteLine();
                Console.ReadKey();
                Combat(false, "Human Rogue", 1, 4);
            }
            public static void BasicFightEncounter()
            {
                Console.WriteLine("You turn the corner and there you see a hulking beast...");
                Console.ReadKey();
                Combat(true, "", 0, 0);
            }
            // encounter tools
            public static void RandomEncounter()
            {
                switch (rand.Next(0, 1))
                {
                    case 0:
                        BasicFightEncounter();
                        break;
                }
            }
            public static void Combat(bool random, string name, int power, int health)
            {
                string n = "";
                int p = 0;
                int h = 0;
                if (random)
                {
                    n = getName();
                    p = rand.Next(1, 5);
                    h = rand.Next(1, 8);
                }
                else
                {
                    n = name;
                    p = power;
                    h = health;
                }
                while (h > 0)
                {
                    Console.Clear();
                    Console.WriteLine(n);
                    Console.WriteLine(p + "/" + h);
                    Console.WriteLine("=====================");
                    Console.WriteLine("| (A)ttack (D)efend |");
                    Console.WriteLine("| (R)un      (H)eal |");
                    Console.WriteLine("=====================");
                    Console.WriteLine("potions: " + Program.currentPlayer.potion + " Health: " + Program.currentPlayer.health);
                    string input = Console.ReadLine();
                    if (input.ToLower() == "a" || input.ToLower() == "attack")
                    {
                        //Attack
                        Console.WriteLine("How dare you attack me, Die you foul creature! As you pass, the " + n + " strikes you back ");
                        int damage = p - Program.currentPlayer.armorvalue;
                        if (damage < 0)
                            damage = 0;
                        int attack = rand.Next(0, currentPlayer.weaponvalue) + rand.Next(1, 4);
                        Console.WriteLine("You lose " + damage + "health and deal " + attack + " damage");
                        Program.currentPlayer.health -= damage;
                        h -= attack;
                    }
                    else if (input.ToLower() == "d" || input.ToLower() == "defend")
                    {
                        //Defend
                        Console.WriteLine("As the " + n + "its impossible to hurt me with your attacks!");
                        int damage = (p / 4) - Program.currentPlayer.armorvalue;
                        if (damage < 0)
                            damage = 0;
                        int attack = rand.Next(0, currentPlayer.weaponvalue) / 2;
                        Console.WriteLine("You lose " + damage + "health and deal " + attack + " damage");
                        Program.currentPlayer.health -= damage;
                        h -= attack;
                    }
                    else if (input.ToLower() == "r" || input.ToLower() == "run")
                    {
                        //Run
                        if (rand.Next(0, 2) == 0)
                        {
                            Console.WriteLine("When you sprint aways from the " + n + ", Its strike cathes you in the back, now is the perfect time to run!");
                            int damage = p - Program.currentPlayer.armorvalue;
                            if (damage < 0)
                                damage = 0;
                            Console.WriteLine("You lose " + damage + "health and are unable to escape.");
                            Console.ReadKey();
                            //go to store
                        }
                        else
                        {
                            Console.WriteLine("You use your agile ninja moves to evade the " + n + " and you succesfully escape!");

                        }
                    }
                    else if (input.ToLower() == "h" || input.ToLower() == "heal")
                    {
                        //Heal
                        if (Program.currentPlayer.potion == 0)
                        {
                            Console.WriteLine("As you desperately grasp for a potion in your bag, all that you can do is using performanace of a 1000 healing priestess!");
                            int damage = p - Program.currentPlayer.armorvalue;
                            if (damage < 0)
                                damage = 0;
                            Console.WriteLine("The " + n + " strikes you with a heavy hit and you lose" + damage + " health!");
                        }
                        else
                        {
                            Console.WriteLine("You can reach into your bag and pull out a glowing , black flask. You take a long drink.");
                            int potionV = 5;
                            Console.WriteLine(value: $"You obtain {potionV} health");
                            Program.currentPlayer.health += potionV;
                            Console.WriteLine("As you are occupied, the " + n + " advanced and struck.");
                            int damage = (p / 2) - Program.currentPlayer.armorvalue;
                            if (damage < 0)
                                damage = 0;
                            Console.WriteLine("You lose " + damage + "health.");
                        }
                        Console.ReadKey();
                    }
                    if (Program.currentPlayer.health <= 0)
                    {
                        //Death code
                        Console.WriteLine("As the "+n+" stands tall and comes down to strike. You have been slayn by the mighty "+n);
                        Console.ReadKey();
                    }
                    Console.ReadKey();
                }
                int c = rand.Next(10, 50);
                Console.WriteLine("As you stand victorious over the " + n + ", its body dissolves into "+c+" gold coins!");
                Program.currentPlayer.coins += c;
                Console.ReadKey();
            }
            public static string getName()
            {
                switch (rand.Next(0, 4))
                {
                    case 0:
                        return "Skeleton";
                    case 1:
                        return "Zombie";
                    case 2:
                        return "Human Cultist";
                    case 3:
                        return "Grave RObber";
                }
                return "Human Rogue";
            }
        }
    }
}