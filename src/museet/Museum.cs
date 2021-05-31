using System.Collections.Generic;

namespace museet
{
    ///<summary>
    ///Represents a museum with an identifying name, containing various rooms stored in a list
    ///</summary>
    public class Museum
    {
        public string MuseumName { get; set; }

        private List<Room> rooms = new List<Room>();

        public List<Room> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        //explicit constructor is not used; fields are populated by DataRepository
        //after "empty" museum instance is created
    }
}
