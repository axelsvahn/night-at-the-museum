using System.Collections.Generic;

namespace museet
{
    ///<summary>
    ///Represents the contents of a room: name and artworks inside
    ///</summary>
    public class Room
    {
        public string RoomName { get; set; }

        public bool HasBoss { get; set; }

        private List<Artwork> artworks = new List<Artwork>();
        public List<Artwork> Artworks
        {
            set { artworks = value; }
            get { return artworks; }
        }

        private List<int> navigationOptions = new List<int>();
        public List<int> NavigationOptions
        {
            set { navigationOptions = value; }
            get { return navigationOptions; }
        }

        //several constructors are provided to allow input in DataRepository.cs to be flexible for rooms with 
        //combinations of artworks/no artworks, boss/no boss etc.
        public Room(string roomname, List<int> options) //for rooms with no artworks
        {
            RoomName = roomname;
            HasBoss = false;
            Artworks = null;
            NavigationOptions = options;
        }

        public Room(string roomname, bool hasBoss, List<int> options ) //for rooms with no artworks
        {
            RoomName = roomname;
            HasBoss = hasBoss;
            Artworks = null;
            NavigationOptions = options;
        }
        public Room(string roomname, List<Artwork> artworks, List<int> options) //artworks but no boss
        {
            RoomName = roomname;
            HasBoss = false;
            Artworks = artworks;
            NavigationOptions = options;
        }

        public Room(string roomname, bool hasBoss, List<Artwork> artworks, List<int> options) //artworks and boss
        {
            RoomName = roomname;
            HasBoss = hasBoss;
            Artworks = artworks;
            NavigationOptions = options;
        }

        public void ListArtworks()
        {
            if (Artworks != null)
            {
                System.Console.WriteLine("\nHär finns följande konstverk:");
                foreach (Artwork artwork in Artworks)
                {
                    System.Console.WriteLine(artwork.ToString());
                }
            }
            else
            {
                System.Console.WriteLine("Här finns inga konstverk.");
            }
        }
    }
}
