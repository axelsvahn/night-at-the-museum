using System;

namespace museet
{
    ///<summary>
    ///Handles the majority of user interactions and console printouts
    ///</summary>
    public class View
    {
        //View stores its own museum instance to make it easily accessible
        private Museum myMuseum = new Museum();

        public Museum MyMuseum
        {
            set { myMuseum = value; }
            get { return myMuseum; }
        }

        ///<summary>
        ///Handles the "game loop" and calls other functions within View
        ///</summary>
        public void ViewRoom(int currentRoom)
        {
            //only displayed once
            Console.Clear();
            System.Console.WriteLine($"---Välkommen till {MyMuseum.MuseumName}!---\n");

            //it does not make so much sense to provide a quit functionality, since the console is supposed to
            //be placed inside the museum and be available to visitors

            while (true) //main loop
            {
                //describe current room
                System.Console.WriteLine($"Du befinner dig nu i {MyMuseum.Rooms[currentRoom].RoomName}.");
                MyMuseum.Rooms[currentRoom].ListArtworks();
                CheckForBoss(currentRoom);
                ListNavigationOptions(currentRoom);

                //switch to next room
                int nextRoom = ChooseNavigation(currentRoom);
                currentRoom = nextRoom;
                Console.Clear();
            }
        }

        ///<summary>
        ///Allows user to navigate the museum
        ///</summary>
        public int ChooseNavigation(int currentRoom)
        {
            //loops until input corresponds to room accessible from current room
            int nextRoom = 0;
            bool loop = true;
            while (loop)
            {
                nextRoom = ParseInput.ParseIntegerInput();
                if (MyMuseum.Rooms[currentRoom].NavigationOptions.Contains(nextRoom))
                {
                    loop = false;
                }
            }
            return nextRoom;
        }

        ///<summary>
        ///Prints list of the navigation options available within each room
        ///</summary>
        public void ListNavigationOptions(int currentRoom)
        {
            foreach (int option in MyMuseum.Rooms[currentRoom].NavigationOptions)
            {
                System.Console.WriteLine($"Skriv {option} för att gå till {MyMuseum.Rooms[option].RoomName}.");
            };
        }
        ///<summary>
        ///Checks for presence of boss in current room and removes boss after defeat
        ///</summary>
        public void CheckForBoss(int currentRoom)
        {
            if (MyMuseum.Rooms[currentRoom].HasBoss)
            {
                System.Console.WriteLine("Här finns en boss! Vill du slåss mot bossen? Skriv j och tryck enter för att slåss, \neller skriv något annat för att ignorera bossen.");
                string answer = Console.ReadLine();
                if (answer == "j" || answer == "J")
                {
                    bool bossIsDefeated = BossFight.Run();
                    if (bossIsDefeated)
                    {
                        MyMuseum.Rooms[currentRoom].HasBoss = false;
                    }
                }
            }
        }

        ///<summary>
        ///Prints instructions at application start
        ///</summary>
        public void WriteInstructions()
        {
            Console.Clear();
            System.Console.WriteLine("--- En Natt på Museet--- \n");
            System.Console.WriteLine("Hej och välkommen till ”En Natt på Museet.” Så här fungerar det: \n");
            System.Console.WriteLine("Gå runt i de olika rummen och titta på konstverken som finns där genom att");
            System.Console.WriteLine("välja vart du vill gå (skriv in som heltal) och trycka på enterknappen. ");
            System.Console.Write("Men först måste du välja museum.\n");
        }
    }
}