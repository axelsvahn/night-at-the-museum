using System.Collections.Generic;
using System.Threading;

namespace museet
{
    ///<summary>
    ///Stores data for populating museum, provides dialogue for choosing which museum to visit
    ///</summary>
    public class DataRepository
    {
        ///<summary>
        ///Allows the user to choose a museum
        ///</summary>
        public void SelectMuseumContent(Museum museum)
        {
            System.Console.WriteLine("\nVilket museum vill du besöka?");
            System.Console.WriteLine("1. Konstmuseum (Alla konstverk finns i verkligheten!)");
            System.Console.WriteLine("2. Påhittade museet (Extra museum. Alla konstverk är påhittade utom ett!)\n");

            switch (ParseInput.ParseIntegerInput())
            {
                case 1:
                    PopulateMuseum1(museum);
                    break;
                case 2:
                    PopulateMuseum2(museum);
                    break;
                default: //if the user does not input 1 or 2;  to avoid having a loop here
                    System.Console.WriteLine("Du svarade inte 1 eller 2.");
                    System.Console.WriteLine("Då får du det ordinarie museet.");
                    PopulateMuseum1(museum);
                    Thread.Sleep(3000);
                    break;
            }
        }

        ///<summary>
        ///Populates an instance of the standard museum
        ///</summary>
        public void PopulateMuseum1(Museum museum)
        {
            //add name of museum
            museum.MuseumName = "Konstmuseet";

            //add room 0
            var navigationList0 = new List<int> { 1 };
            Room room0 = new Room("Entrén", navigationList0);
            museum.Rooms.Add(room0);

            //add room 1
            var navigationList1 = new List<int> { 0, 2 };
            Room room1 = new Room("Korridoren", navigationList1);
            museum.Rooms.Add(room1);

            //add room 2
            var artwork2_1 = new Artwork("Skriet", "Edvard Munch", "En tavla på en figur som står på en bro.");
            var artwork2_2 = new Artwork("Dogs Playing Poker", "Cassius Marcellus Coolidge", "En tavla på hundar som spelar poker.");
            var artworks2 = new List<Artwork> { artwork2_1, artwork2_2 };

            var navigationList2 = new List<int> { 1, 3, 4 };

            Room room2 = new Room("Gröna rummet", artworks2, navigationList2);
            museum.Rooms.Add(room2);

            //add room 3
            var artwork3_1 = new Artwork("Fountain", "Marcel Duchamp", "En inrättning med signaturen \"R. Mutt\".");
            var artwork3_2 = new Artwork("Monogram", "Robert Rauschenberg", "En get i ett bildäck.");
            var artwork3_3 = new Artwork("Grindslanten", "August Malmström", "En tavla med barn som vill ha en slant.");
            var artworks3 = new List<Artwork> { artwork3_1, artwork3_2, artwork3_3 };

            var navigationList3 = new List<int> { 2, 5 };

            Room room3 = new Room("Röda rummet", artworks3, navigationList3);
            museum.Rooms.Add(room3);

            //add room 4
            var artwork4_1 = new Artwork("Study after Velazquez's Portrait of Pope Innocent X", "Francis Bacon", "Ett porträtt på en påve.");
            var artworks4 = new List<Artwork> { artwork4_1 };

            var navigationList4 = new List<int> { 2, 5, 6, 7 };

            Room room4 = new Room("Blåa rummet", artworks4, navigationList4);
            museum.Rooms.Add(room4);

            //add room 5
            var artwork5_1 = new Artwork("Portrait de l'artiste sous les traits d'un moqueur", "Joseph Ducreux", "En tavla på en man i peruk som pekar med fingret mot betraktaren.");
            var artwork5_2 = new Artwork("Le Fils de l'homme", "René Magritte", "En tavla på ett grönt äpple som svävar i luften framför en man i kostym.");
            var artwork5_3 = new Artwork("L'Homme qui marche I", "Alberto Giacometti", "En staty på en mycket smal gubbe.");
            var artwork5_4 = new Artwork("La familia presidencial", "Fernando Botero", "En tavla på en familj.");
            var artworks5 = new List<Artwork> { artwork5_1, artwork5_2, artwork5_3, artwork5_4 };

            var navigationList5 = new List<int> { 3, 4 };

            Room room5 = new Room("Lila rummet", artworks5, navigationList5);
            museum.Rooms.Add(room5);

            //add room 6 with boss = true
            var navigationList6 = new List<int> { 4 };
            Room room6 = new Room("Svarta rummet", true, navigationList6); //true = this room has a boss
            museum.Rooms.Add(room6);

            //add room 7
            var artwork7_1 = new Artwork("Gråtande kvinna", "Pablo Picasso", "En tavla på en gråtande kvinna.");
            var artworks7 = new List<Artwork> { artwork7_1 };

            var navigationList7 = new List<int> { 4 };
            Room room7 = new Room("Vita rummet", artworks7, navigationList7);
            museum.Rooms.Add(room7);
        }

        ///<summary>
        ///Populates an instance of the extra museum
        ///</summary>
        public void PopulateMuseum2(Museum museum)
        {
            //add name of museum
            museum.MuseumName = "Påhittade museet";

            //add room 0
            var navigationList0 = new List<int> { 1 };
            Room room0 = new Room("Ingången", navigationList0);
            museum.Rooms.Add(room0);

            //add room 1
            var navigationList1 = new List<int> { 0, 2 };
            var artwork1_1 = new Artwork("Den sjungande abborren", "Bengt Knutsson", "En sjungande abborre på en trofétavla.");
            var artworks1 = new List<Artwork> { artwork1_1 };
            Room room1 = new Room("Passagen", artworks1, navigationList1);
            museum.Rooms.Add(room1);

            //add room 2
            var artwork2_1 = new Artwork("Den tittande geten", "Karl Karlsson", "En tavla på en get som tittar på en ko.");
            var artwork2_2 = new Artwork("Den tittande kon", "Britta Persson", "En tavla på en ko som tittar på en get.");
            var artworks2 = new List<Artwork> { artwork2_1, artwork2_2 };

            var navigationList2 = new List<int> { 1, 3, 4 };

            Room room2 = new Room("Gula hallen", artworks2, navigationList2);
            museum.Rooms.Add(room2);

            //add room 3
            var artwork3_1 = new Artwork("Programmet som inte ville kompilera", "Nils Bengtsson", "En tavla på en terminal med en massa felmeddelanden.");
            var artwork3_2 = new Artwork("Cats Playing Snooker", "John Smith Jr.", "En tavla på katter som spelar snooker.");
            var artworks3 = new List<Artwork> { artwork3_1, artwork3_2 };

            var navigationList3 = new List<int> { 2, 5 };

            Room room3 = new Room("Grå salen", artworks3, navigationList3);
            museum.Rooms.Add(room3);

            //add room 4
            var artwork4_1 = new Artwork("Luftskulptur Nr. 59", "Per Persson", "En tom piedestal.");
            var artworks4 = new List<Artwork> { artwork4_1 };

            var navigationList4 = new List<int> { 2, 5 };

            Room room4 = new Room("Purpurgalleriet", artworks4, navigationList4);
            museum.Rooms.Add(room4);

            //add room 5
            var artwork5_1 = new Artwork("Den mystiska clownen", "Gun-Britt Johansson", "En tavla på en mystisk clown.");
            var artwork5_2 = new Artwork("Den skrattande bävern", "Sven Svensson", "En tavla på en skrattande bäver med partyhatt.");
            var artwork5_3 = new Artwork("Five Invisible Clowns Playing Poker", "Mary Smith", "En skulpturgrupp med fem osynliga clowner som spelar poker.\nInget syns förutom spelkorten som ligger på golvet.\nEtt mästerverk!");
            var artworks5 = new List<Artwork> { artwork5_1, artwork5_2, artwork5_3 };

            var navigationList5 = new List<int> { 3, 4, 6 };

            Room room5 = new Room("Violetta paviljongen", artworks5, navigationList5);
            museum.Rooms.Add(room5);

            //add room 6 with boss = true

            var navigationList6 = new List<int> { 5 };

            Room room6 = new Room("Spökrummet", true, navigationList6);
            museum.Rooms.Add(room6);
        }
    }
}
