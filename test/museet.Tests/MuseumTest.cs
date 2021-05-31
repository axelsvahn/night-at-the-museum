using System;
using Xunit;
using System.Collections.Generic;

namespace museet.Tests
{
    public class MuseumTest
    {
        [Fact]
        public void CanPopulateRoomInMuseum()
        {
            //arrange
            Museum testMuseum = new Museum();
            var artwork2_1 = new Artwork("Skriet", "Edvard Munch", "En tavla på en skrikande figur som står på en bro");
            var artwork2_2 = new Artwork("Dogs Playing Poker", "Cassius Marcellus Coolidge", "En tavla på hundar som spelar poker");
            var artworks2 = new List<Artwork> { artwork2_1, artwork2_2 };
            var navigationList2 = new List<int> { 1, 3, 4 };
            Room room2 = new Room("Gröna rummet", artworks2, navigationList2);

            //act
            testMuseum.Rooms.Add(room2);

            //assert
            Assert.Equal("Gröna rummet", testMuseum.Rooms[0].RoomName);
            Assert.Equal("Skriet", testMuseum.Rooms[0].Artworks[0].Title);
            Assert.Equal(1, testMuseum.Rooms[0].NavigationOptions[0]);
        }

        [Fact]
        public void CanPopulateEntireMuseum()
        {
            //arrange
            Museum testMuseum = new Museum();
            DataRepository testRepository = new DataRepository();

            //act
            testRepository.PopulateMuseum1(testMuseum);

            //assert (test first, "average" and last room)
            Assert.Equal("Entrén", testMuseum.Rooms[0].RoomName);

            Assert.Equal("Gröna rummet", testMuseum.Rooms[2].RoomName);
            Assert.Equal("Skriet", testMuseum.Rooms[2].Artworks[0].Title);
            Assert.Equal(1, testMuseum.Rooms[2].NavigationOptions[0]);

            Assert.Equal("Vita rummet", testMuseum.Rooms[7].RoomName);
            Assert.Equal("Pablo Picasso", testMuseum.Rooms[7].Artworks[0].Creator);
            Assert.Equal(4, testMuseum.Rooms[7].NavigationOptions[0]);
        }
        [Fact]
        public void CanUseOtherMuseum()
        {
            //arrange
            Museum testMuseum = new Museum();
            DataRepository testRepository = new DataRepository();

            //act
            testRepository.PopulateMuseum2(testMuseum);

            //assert (test first, "average" and last room)

            Assert.Equal("Ingången", testMuseum.Rooms[0].RoomName);

            Assert.Equal("Gula hallen", testMuseum.Rooms[2].RoomName);
            Assert.Equal("Den tittande geten", testMuseum.Rooms[2].Artworks[0].Title);
            Assert.Equal(3, testMuseum.Rooms[2].NavigationOptions[1]);

            Assert.Equal("Violetta paviljongen", testMuseum.Rooms[5].RoomName);
            Assert.Equal("Gun-Britt Johansson", testMuseum.Rooms[5].Artworks[0].Creator);
            Assert.Equal(4, testMuseum.Rooms[5].NavigationOptions[1]);
        }

        [Fact]
        public void CanNavigateToConnectedRoom()
        {
            //arrange
            Museum testMuseum = new Museum();
            DataRepository testRepository = new DataRepository();
            testRepository.PopulateMuseum1(testMuseum);

            int currentRoom = FakeNavigation1(5);
            //Rooms 5 (current room) and 4 (user input in FakeNavigation1 below) are connected; should be able to move

            //assert 
            Assert.Equal(4, currentRoom);
        }

        public int FakeNavigation1(int currentRoom)
        {
            Museum testMuseum = new Museum();
            DataRepository TestRepository = new DataRepository();
            TestRepository.PopulateMuseum1(testMuseum);

            //in real application: loops until input corresponds to room accessible from current room

            int nextRoom = 0;
            bool loop = true;
            while (loop)
            {
                nextRoom = 4; //variable assignment stands in for user console input
                              //Rooms 5 and 4 are connected; should be able to navigate between 5 and 4

                //Like it says below: you will move to the specified room if the navigation options of
                //the current room contain the specified room; otherwise the loop goes on
                if (testMuseum.Rooms[currentRoom].NavigationOptions.Contains(nextRoom))
                {
                    loop = false;
                }
            }
            return nextRoom;
        }

        [Fact]
        public void CannotNavigateToUnconnectedRoom()
        {
            //arrange
            Museum testMuseum = new Museum();
            DataRepository testRepository = new DataRepository();
            testRepository.PopulateMuseum1(testMuseum);

            //You cannot move from room 3 to room 4 (user input), so currentRoom should remain "3". 

            int currentRoom = FakeNavigation2(3);

            //assert 
            Assert.Equal(3, currentRoom);
        }

        public int FakeNavigation2(int currentRoom)
        {
            Museum testMuseum = new Museum();
            DataRepository TestRepository = new DataRepository();
            TestRepository.PopulateMuseum1(testMuseum);

            //in real application: loops until input corresponds to a room accessible from current room

            int nextRoom = 0;
            bool loop = true;
            while (loop)
            {
                //variable assignment stands in for user console input
                //Rooms 5 and 4 are connected; should be able to navigate between 5 and 4

                //Like it says below: you will move to the specified room if the navigation options of
                //the current room contain the specified room; otherwise the loop goes on (in the real program)

                nextRoom = 4; //variable assignment fakes user input
                if (testMuseum.Rooms[currentRoom].NavigationOptions.Contains(nextRoom))
                {
                    loop = false;
                }
                //unlike in the real program we have to break the loop in order to have a working test
                //so this basically just tests if the if statement above is doing its job
                else 
                {
                    nextRoom = currentRoom;
                    loop = false;
                }
            }
            return nextRoom;
        }
    }
}
